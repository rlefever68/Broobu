using System;
using System.IO;
using System.Transactions;
using Pms.Diagnostics.Business.Interfaces;
using Pms.Diagnostics.Business.Mappers;
using Pms.Diagnostics.Contract.Domain;
using Pms.Diagnostics.Repository.Contract.Agent;
using Pms.Framework.Domain;
using Pms.Components.SharpZLib;

namespace Pms.Diagnostics.Business
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    class DiagnosticsProvider : IDiagnosticsProvider
    {
        /// <summary>
        /// Adds the diagnostics package.
        /// </summary>
        /// <param name="package">The package.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public Result AddDiagnosticsPackage(byte[] package)
        {
            using (Stream sIn = new MemoryStream(package))
            {
                sIn.Seek(0, SeekOrigin.Begin);
                var sZipIn = new ZipInputStream(sIn);
                var entry = sZipIn.GetNextEntry();
                while (entry != null)
                {

                    entry = sZipIn.GetNextEntry();
                }
            }
            return new Result();
        }

        /// <summary>
        /// Runs the diagnostics.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public Result RunDiagnostics()
        {
            var eng = new DiagnosticsEngine();
            return eng.RunDiagnostics();
        }


        /// <summary>
        /// Gets the diagnostics run items for date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DiagnosticsRunItem[] GetDiagnosticsRunItemsForDate(DateTime date)
        {
            using (var scp = new TransactionScope())
            {
                var res = DiagnosticsRepositoryAgentFactory
                    .CreateDiagnosticsRunRepositoryAgent()
                    .SelectByDate(date);
                scp.Complete();
                var map = new DiagnosticsRunItemMapper();
                return map.MapFromServiceToBusiness(res);
            }
        }

        /// <summary>
        /// Gets the diagnostics details for run.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DiagnosticsRunDetailItem[] GetDiagnosticsDetailsForRun(string id)
        {
            using (var scp = new TransactionScope())
            {
                var res = DiagnosticsRepositoryAgentFactory
                    .CreateDiagnosticsRunDetailRepositoryAgent()
                    .SelectByRunId(id);
                scp.Complete();
                var map = new DiagnosticsRunDetailItemMapper();
                return map.MapFromServiceToBusiness(res);
            }
        }


        /// <summary>
        /// Saves the run.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DiagnosticsRunItem SaveRun(DiagnosticsRunItem item)
        {
            var map = new DiagnosticsRunItemMapper();
            var it = map.MapFromBusinessToService(item);
            try
            {
                using (var scp = new TransactionScope())
                {
                    if (FindRun(item.Id)==null)
                    {
                        DiagnosticsRepositoryAgentFactory
                            .CreateDiagnosticsRunRepositoryAgent()
                            .Insert(it);
                    }
                    else
                    {
                        DiagnosticsRepositoryAgentFactory
                            .CreateDiagnosticsRunRepositoryAgent()
                            .Update(it);
                    }
                    scp.Complete();
                }

            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    item.AddError(ex.InnerException.Message);
                item.AddError(ex.Message);
            }
            return item;
        }

        /// <summary>
        /// Finds the run item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DiagnosticsRunItem FindRun(string id)
        {
            var map = new DiagnosticsRunItemMapper();
            var res =  DiagnosticsRepositoryAgentFactory
                .CreateDiagnosticsRunRepositoryAgent()
                .SelectById(id);
            return (res!=null) ? map.MapFromServiceToBusiness(res) : null;
        }

        /// <summary>
        /// Saves the run detail.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DiagnosticsRunDetailItem SaveRunDetail(DiagnosticsRunDetailItem item)
        {
            var map = new DiagnosticsRunDetailItemMapper();
            try
            {
                using (var scp = new TransactionScope())
                {
                    if (FindRunDetail(item.Id)==null)
                    {
                        DiagnosticsRepositoryAgentFactory
                            .CreateDiagnosticsRunDetailRepositoryAgent()
                            .Insert(map.MapFromBusinessToService(item));
                    }
                    else
                    {
                        DiagnosticsRepositoryAgentFactory
                            .CreateDiagnosticsRunDetailRepositoryAgent()
                            .Update(map.MapFromBusinessToService(item));
                    }
                    scp.Complete();
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    item.AddError(ex.InnerException.Message);
                item.AddError(ex.Message);
            }
            return item;
        }

        /// <summary>
        /// Finds the run detail.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DiagnosticsRunDetailItem FindRunDetail(string id)
        {
            var map = new DiagnosticsRunDetailItemMapper();
            var res = DiagnosticsRepositoryAgentFactory
                .CreateDiagnosticsRunDetailRepositoryAgent()
                .SelectById(id);
            return res == null ? null : map.MapFromServiceToBusiness(res);
        }


    }
}
