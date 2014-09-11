using System;
using System.ServiceModel;
using System.ServiceModel.Activation;


namespace Broobu.Engine.Service
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public class CloudFactory : ServiceHostFactory
    {


        public static ServiceHost CreateProxy(params Uri[] baseAddresses)
        {
            var f = new CloudFactory();
            return f.CreateServiceHost(typeof(CloudEngine), baseAddresses);
        }

        /// <summary>
        /// Creates a <see cref="T:System.ServiceModel.ServiceHost"/> for a specified type of service with a specific base address.
        /// </summary>
        /// <param name="serviceType">Specifies the type of service to host.</param>
        /// <param name="baseAddresses">The <see cref="T:System.Array"/> of type <see cref="T:System.Uri"/> that contains the base addresses for the service hosted.</param>
        /// <returns>A <see cref="T:System.ServiceModel.ServiceHost"/> for the type of service specified with a specific base address.</returns>
        /// <remarks></remarks>
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var serviceHost = new ServiceHost(serviceType, baseAddresses);
            //serviceHost.Opened += ServiceHostOpened;
            return serviceHost;
        }


        /// <summary>
        /// Services the host opened.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        //static void ServiceHostOpened(object sender, EventArgs e)
        //{
        //    var proxy = sender as CloudEngine;
        //    if (proxy != null)
        //    {
        //        proxy.RefreshFromCache();
        //    }
        //}
    }
}
