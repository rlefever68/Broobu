using System;
using System.Activities;
using System.Activities.Core.Presentation;
using System.Activities.Presentation;
using System.Activities.Presentation.Toolbox;
using System.Activities.Statements;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Activities;
using System.ServiceModel.Description;
using System.Windows.Controls;
using Iris.Fx.Agent;
using Iris.Fx.Domain;
using Iris.Fx.Networking.Wcf;

namespace Broobu.CloudStudio.UI.Controls
{
    /// <summary>
    /// Interaction logic for SOAStudioView.xaml
    /// </summary>
    /// <remarks></remarks>
    public partial class SoaStudioView
    {
        /// <summary>
        /// 
        /// </summary>
        private WorkflowDesigner _wd;
        /// <summary>
        /// 
        /// </summary>
        private Flowchart _chrt;
        /// <summary>
        /// 
        /// </summary>
        private ToolboxControl _control;


        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Windows.Controls.UserControl"/> class.
        /// </summary>
        /// <remarks></remarks>
        public SoaStudioView()
        {
            InitializeComponent();
            RegisterMetadata();
            AddDesigner();
            AddPropertyInspector();
            AddToolBox();

        }


        /// <summary>
        /// Adds the designer.
        /// </summary>
        /// <remarks></remarks>
        private void AddDesigner()
        {
            //Create an instance of WorkflowDesigner class.
            _wd = new WorkflowDesigner();
            //Place the designer canvas in the middle column of the grid.
            Grid.SetColumn(_wd.View, 1);
            //Load a new Sequence as default.
            _chrt = new Flowchart();
            _wd.Load(_chrt);
            //Add the designer canvas to the grid.
            grdDesigner.Children.Add(_wd.View);
        }


        /// <summary>
        /// Registers the metadata.
        /// </summary>
        /// <remarks></remarks>
        private void RegisterMetadata()
        {
            DesignerMetadata dm = new DesignerMetadata();
            dm.Register();
        }


        /// <summary>
        /// Adds the tool box.
        /// </summary>
        /// <remarks></remarks>
        private void AddToolBox()
        {
            _control = new ToolboxControl();
            Grid.SetColumn(_control, 0);
            grdDesigner.Children.Add(_control);
            GetToolboxControlAsync(AddCategory);
        }


        /// <summary>
        /// Gets the toolbox control.
        /// </summary>
        /// <param name="getToolBoxControlCompleted">The get tool box control completed.</param>
        /// <remarks></remarks>
        private void GetToolboxControlAsync(Action<ToolboxCategoryItems> getToolBoxControlCompleted = null)
        {
            using (var wrk = new BackgroundWorker())
            {
                ToolboxCategoryItems lst = new ToolboxCategoryItems();
                wrk.DoWork += (s, e) =>
                {
                    ToolboxCategory catPredef = CreatePredefinedActivitiesCategory();
                    lst.Add(catPredef);
                    ToolboxCategory catService = CreateServiceModelActivitiesCategory();
                    lst.Add(catService);
                    CreateDiscoCategories(lst); // Auto discovery proves to be very very hard
                    // CreateContractCategories(lst); // Lets assumne that Pms.*.Contract assemblies are readily available
                };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    wrk.Dispose();
                    if (getToolBoxControlCompleted != null)
                        getToolBoxControlCompleted(lst);
                };
                wrk.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Creates the service model activities category.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private ToolboxCategory CreateServiceModelActivitiesCategory()
        {
            Assembly assy = Assembly.GetAssembly(typeof(Send));
            var cat = new ToolboxCategory("Service Activities");
            Type[] types = assy
                .GetTypes()
                .Where(t => (t.IsSubclassOf(typeof(Activity)) && (!t.IsAbstract) && (!t.ContainsGenericParameters)))
                .OrderBy(t => t.FullName)
                .ToArray();
            if (types != null)
            {

                foreach (var t in types)
                {
                    Activity inst;
                    try
                    {
                        inst = (Activity)Activator.CreateInstance(t);
                        if (t.IsVisible)
                        {
                            var wrp = new ToolboxItemWrapper(t, inst.DisplayName);
                            cat.Add(wrp); ;
                        }
                    }
                    catch
                    {

                    }
                    finally
                    {
                        inst = null;
                    }
                }
            };
            return cat;
        }


      

        /// <summary>
        /// Creates the disco categories.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <remarks></remarks>
        private void CreateDiscoCategories(ToolboxCategoryItems items)
        {
            var disco = DiscoPortal
                         .Disco
                         .GetAllEndpointAddresses()
                         .Where(x => x.Endpoint.Contains("http"))
                         .ToArray();
            foreach (var it in disco)
            {
                try
                {
                    BuildSendActivityBox(it, items);
                }
                catch (Exception)
                {   
                }
                
            };

        }

        /// <summary>
        /// Builds the send activity box.
        /// </summary>
        /// <param name="it">It.</param>
        /// <remarks></remarks>
        private void BuildSendActivityBox(DiscoItem it, ToolboxCategoryItems items)
        {
            var cat = new ToolboxCategory(it.Contract);
            var ops = MetadataHelper
                .GetOperationDescriptions(it.Endpoint + "/mex")
                .First()
                .DeclaringContract
                .Operations;
            var httpEndpoint = MetadataHelper
                .GetEndpoints(it.Endpoint + "/mex").FirstOrDefault(x => x.Address.Uri.Scheme == Uri.UriSchemeHttp);
            AddOperationsToCategory(httpEndpoint, ops, cat);
            items.Add(cat);
           
        }

        /// <summary>
        /// Loads the contract assembly.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <remarks></remarks>
        private void LoadContractAssembly(string url)
        {
            Uri uri            = new Uri(url);
            var lastSegment = uri.Segments[uri.Segments.Length-1];
            var contractUrl = url.Replace(lastSegment, "bin/iris.contract");
        }

        /// <summary>
        /// Adds the operations to category.
        /// </summary>
        /// <param name="ops">The ops.</param>
        /// <param name="cat">The cat.</param>
        /// <remarks></remarks>
        private void AddOperationsToCategory(ServiceEndpoint httpEndpoint, 
            IEnumerable<OperationDescription> ops, ToolboxCategory cat)
        {
            if (ops == null) return;
            var assy = Assembly.GetAssembly(typeof (Send));
            foreach (var wrp in ops.Select(ods => new ToolboxItemWrapper
                                                      {
                                                          DisplayName = ods.Name, 
                                                          ToolName = "System.ServiceModel.Activities.Send", 
                                                          AssemblyName = assy.FullName
                                                      }))
            {
                cat.Tools.Add(wrp);
            }
        }


        /// <summary>
        /// Gets the embedded resource names.
        /// </summary>
        /// <remarks></remarks>
        private void GetEmbeddedResourceNames()
        {
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            string[] names = myAssembly.GetManifestResourceNames();
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }





        /// <summary>
        /// Creates the predefined activities category.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private ToolboxCategory CreatePredefinedActivitiesCategory()
        {
            Assembly assy = Assembly.GetAssembly(typeof(Sequence));
            var cat = new ToolboxCategory("Predefined Activities");
            Type[] types = assy
                .GetTypes()
                .Where(t => (t.IsSubclassOf(typeof(Activity)) && (!t.IsAbstract) && (!t.ContainsGenericParameters)))
                .ToArray();

            foreach (var t in types)
            {
                try
                {
                    var inst = (Activity)Activator.CreateInstance(t);
                    if (t.IsVisible)
                    {
                        var wrp = new ToolboxItemWrapper(t, inst.DisplayName);
                     
                        cat.Add(wrp); ;
                    }
                }
                catch
                { }
            };
            return cat;
        }

        /// <summary>
        /// Adds the property inspector.
        /// </summary>
        /// <remarks></remarks>
        private void AddPropertyInspector()
        {
            Grid.SetColumn(_wd.PropertyInspectorView, 2);
            grdDesigner.Children.Add(_wd.PropertyInspectorView);
        }


        /// <summary>
        /// Runs this instance.
        /// </summary>
        /// <remarks></remarks>
        public void Run()
        {
            WorkflowApplication app = new WorkflowApplication(_chrt);
            app.Run();

        }

        /// <summary>
        /// Adds the category.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <remarks></remarks>
        public void AddCategory(ToolboxCategoryItems items)
        {
            foreach (var i in items)
            {
                _control.Categories.Add(i);
            }
        }
    }




}
