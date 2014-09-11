using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Broobu.EcoSpace.Contract.Properties;

namespace Broobu.EcoSpace.Contract.Domain.Applets
{
    [DataContract]
    public class ManageCloudApplet : CloudApplet
    {
        public static string ID = "MANAGE_CLOUD_APPLET";
        public ManageCloudApplet()
        {
            Id = ID;
            DisplayName = "Manage Cloudspace";
            Icon = Resources.ConfigCloud;
            PublishUrl = "http://www.broobu.com/clickonce/broobu/ecospace/broobu.ecospace.ui.application";
        }

    }
}
