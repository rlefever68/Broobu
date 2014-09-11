using System;
using Broobu.Fx.UI;
using Iris.Fx.UI;

namespace Broobu.CloudStudio.UI.Controls
{
    public class SoaStudioViewModel : ViewModelBase
    {



        ///// <summary>
        ///// Gets the activity builder.
        ///// </summary>
        ///// <param name="operationDescription">The operation description.</param>
        ///// <param name="configurationName">Name of the configuration.</param>
        ///// <param name="proxyNamespace">The proxy namespace.</param>
        ///// <returns></returns>
        //private ActivityBuilder GetActivityBuilder(OperationDescription operationDescription, string configurationName, string proxyNamespace)
        //{
        //    //var bld = new ClientActivityBuilder(operationDescription, configurationName, proxyNamespace);
        //    //ActivityBuilder b = bld.Build();
        //    //return b;
        //}


        protected override void StartAuthenticatedSession()
        {
            throw new NotImplementedException();
        }

        public override void TerminateAuthenticatedSession(Action onSessionTerminated = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes the ViewModel the first time it is called.
        /// This method will be called from the View that implements the
        /// ViewModel
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel</param>
        protected override void InitializeInternal(object[] parameters)
        {
            
        }
    }
}
