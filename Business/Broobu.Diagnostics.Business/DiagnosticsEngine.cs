using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pms.Diagnostics.Contract.Domain;
using Pms.Framework.Domain;

namespace Pms.Diagnostics.Business
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    internal class DiagnosticsEngine
    {






        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        class DiagnosticsInfo
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DiagnosticsInfo"/> class.
            /// </summary>
            /// <param name="methodInfo">The method info.</param>
            /// <param name="type">The type.</param>
            /// <param name="assy">The assy.</param>
            /// <remarks></remarks>
            public DiagnosticsInfo(MethodInfo methodInfo, Type type, Assembly assy)
            {
                _methodInfo = methodInfo;
                _type = type;
                _assembly = assy;
                _id = Guid.NewGuid().ToString();
            }


            /// <summary>
            /// 
            /// </summary>
            private readonly MethodInfo _methodInfo;
            /// <summary>
            /// 
            /// </summary>
            private readonly Type _type;
            /// <summary>
            /// 
            /// </summary>
            private Assembly _assembly;
            /// <summary>
            /// 
            /// </summary>
            private string _id;


            /// <summary>
            /// Gets the diagnostics assembly.
            /// </summary>
            /// <remarks></remarks>
            public Assembly DiagnosticsAssembly
            {
                get { return _assembly; }
            }

            /// <summary>
            /// Gets the type of the diagnostics class.
            /// </summary>
            /// <remarks></remarks>
            public Type DiagnosticsClassType
            {
                get { return _type; }
            }

            /// <summary>
            /// Gets the diagnostics method info.
            /// </summary>
            /// <remarks></remarks>
            public MethodInfo DiagnosticsMethodInfo
            {
                get { return _methodInfo; }
            }



            /// <summary>
            /// Gets the id.
            /// </summary>
            /// <remarks></remarks>
            public string FullMethodName
            {
                get { return String.Format("{0}.{1}", _type.FullName, _methodInfo.Name); }
            }


            /// <summary>
            /// Gets the id.
            /// </summary>
            /// <remarks></remarks>
            public string Id
            {
                get { return _id; }
            }

        }



        /// <summary>
        /// 
        /// </summary>
        private readonly ILog _logger;
        /// <summary>
        /// 
        /// </summary>
        private object sync = new object();


        /// <summary>
        /// 
        /// </summary>
        private static readonly Dictionary<string, DiagnosticsInfo> ActiveTests = new Dictionary<string, DiagnosticsInfo>();


        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <remarks></remarks>
        public DiagnosticsEngine()
        {
            _logger = LogManager.GetLogger(GetType());
        }



        /// <summary>
        /// Loads the test assemblies.
        /// </summary>
        /// <remarks></remarks>
        private void LoadDiagnosticsAssemblies()
        {
            _logger.DebugFormat(">> Loading Test Packages");
            var folder = DiagnosticsConfigurationHelper.DiagnosticsLocation;
            _logger.DebugFormat("Start Loading Diagnostics Assemblies from folder [{0}]", folder);
            if (String.IsNullOrWhiteSpace(folder)) return;
            var nfo = Directory.EnumerateFiles(folder);
            if (nfo.Count() == 0) return;
            foreach (var s in nfo.Where(s => s.ToLower().Contains(".contract.test.dll")))
            {
                _logger.DebugFormat("Loading Diagnostics Module [{0}]", s);
                var assy = Assembly.LoadFrom(s);
                if (assy == null) continue;
                foreach (var t in assy.GetTypes())
                {
                    var attr = t.GetCustomAttributes(false);
                    var t1 = t;
                    foreach (var m in
                        attr.OfType<TestClassAttribute>().SelectMany(o => (from m in t1.GetMethods()
                                                                           let mattr =
                                                                               m.GetCustomAttributes(false)
                                                                           from o1 in
                                                                               mattr.OfType<TestMethodAttribute>
                                                                               ()
                                                                           select m)))
                    {
                        AddDiagnosticsInfo(new DiagnosticsInfo(m, t, assy));
                    }
                }
            }
        }



        /// <summary>
        /// Adds the test method.
        /// </summary>
        /// <param name="nfo">The nfo.</param>
        /// <remarks></remarks>
        private void AddDiagnosticsInfo(DiagnosticsInfo nfo)
        {
            if (ActiveTests.Keys.Contains(nfo.FullMethodName)) return;
            _logger.DebugFormat(String.Format("Adding Test Method {0}", nfo.FullMethodName));
            ActiveTests.Add(nfo.FullMethodName, nfo);
        }




        /// <summary>
        /// Runs the diagnostics.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public Result RunDiagnostics()
        {
            var r = new Result();
            try
            {
              Task.Factory.StartNew(RunDiagnosticsInternal);
            }
            catch (Exception ex)
            {
                r.AddError(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
            return r;
        }



        /// <summary>
        /// Runs the diagnostics.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private void RunDiagnosticsInternal()
        {
            _logger.DebugFormat("******************************************************");
            _logger.DebugFormat("**               Starting Diagnostics               **");
            _logger.DebugFormat("******************************************************");
            LoadDiagnosticsAssemblies();
            RegisterDiagnosticsBatch();
            foreach (var diagnosticsInfo in ActiveTests)
            {
                _logger.DebugFormat("Executing Method {0}",
                                    diagnosticsInfo.Value.FullMethodName);
                try
                {
                    var nfo = diagnosticsInfo.Value;
                    Task.Factory.StartNew(() => RunDiagnosticsMethod(nfo));
                }
                catch (Exception ex)
                {
                    var exs = ex.InnerException != null
                                  ? ex.InnerException.Message
                                  : ex.Message;
                    _logger.ErrorFormat(exs);
                    throw;
                }
            };
        }


        /// <summary>
        /// Registers the diagnostics batch.
        /// </summary>
        /// <remarks></remarks>
        private void RegisterDiagnosticsBatch()
        {
            try
            {
                var runId = Guid.NewGuid().ToString();
                var it = DiagnosticsDomainGenerator.CreateNewBatch(runId);
                DiagnosticsProviderFactory
                    .CreateProvider()
                    .SaveRun(it);
                foreach (var rdit in
                    ActiveTests.Select(
                        diagnosticsInfo =>
                        DiagnosticsDomainGenerator.CreateRunDetail(runId, diagnosticsInfo.Value.Id,
                                                                   diagnosticsInfo.Value.DiagnosticsAssembly.
                                                                       FullName,
                                                                   diagnosticsInfo.Value.DiagnosticsMethodInfo.
                                                                       Name)))
                {
                    DiagnosticsProviderFactory
                        .CreateProvider()
                        .SaveRunDetail(rdit);
                }
            }
            catch (Exception ex)
            {
                var msg = "Error Registering Diagnostics Batch: {0}";
                msg = String.Format(msg, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                _logger.ErrorFormat(msg);
            }

        }



        /// <summary>
        /// Runs the diagnostics method async.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <remarks></remarks>
        private void RunDiagnosticsMethodAsync(DiagnosticsInfo value)
        {
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) =>
                                  {
                                      try
                                      {
                                          RunDiagnosticsMethod(value);
                                      }
                                      catch (Exception)
                                      {
                                          wrk.Dispose();
                                      }
                                  };
                wrk.RunWorkerAsync();
            }
        }



        /// <summary>
        /// Runs the diagnostics method.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <remarks></remarks>
        private void RunDiagnosticsMethod(DiagnosticsInfo value)
        {
            var current = GetDiagnosticsDetailItem(value.Id);
            _logger.DebugFormat("Trying Method {0}", value.DiagnosticsMethodInfo.Name);
            current.StartedAt = DateTime.Now;
            current.Info = "Running";
            SaveDetailItem(current);
            try
            {
                var instance = Activator.CreateInstance(value.DiagnosticsClassType);
                value.DiagnosticsMethodInfo.Invoke(instance, null);
                current.Status = DiagnosticsStatus.Valid;
                current.Info = "Succeeded.";
                current.EndedAt = DateTime.Now;
            }
            catch (Exception ex)
            {
                current.Info = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                current.Status = DiagnosticsStatus.Error;
                _logger.ErrorFormat("An error occured executing method {0} - {1}", current.Method, current.Info);
                current.EndedAt = DateTime.Now;
            }
            finally
            {
                SaveDetailItem(current);
            }
            _logger.DebugFormat("Executed Method {0} - {1} => {2}", current.Method, current.Status, current.Info);
        }

        /// <summary>
        /// Saves the detail item.
        /// </summary>
        /// <param name="current">The current.</param>
        /// <remarks></remarks>
        private void SaveDetailItem(DiagnosticsRunDetailItem current)
        {
            lock (sync)
            {
                DiagnosticsProviderFactory
                    .CreateProvider()
                    .SaveRunDetail(current);
            }
        }

        /// <summary>
        /// Gets the diagnostics detail item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private DiagnosticsRunDetailItem GetDiagnosticsDetailItem(string id)
        {
            lock (sync)
            {
                return DiagnosticsProviderFactory
                    .CreateProvider()
                    .FindRunDetail(id);
            }
        }


    }
}
