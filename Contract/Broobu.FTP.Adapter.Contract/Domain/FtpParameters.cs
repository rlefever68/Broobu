using System;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace Pms.FTP.Adapter.Contract.Domain
{
    [DataContract(Namespace = FtpAdapterConstants.DefaultNamespace)]
    public class FtpParameters
    {
        [DataMember]
        public string Address { get; set; }
        
        [DataMember]
        public int Port { get; set; }

        [DataMember]
        public string User { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
        
        [DataMember]
        public int NumberOfRetries { get; set; }

        [DataMember]
        public int DelayBetweenRetriesInSeconds { get; set; }

        public override string ToString()
        {
            Type thisType = GetType();

            StringBuilder returnValue = new StringBuilder();
            
            returnValue.Append(thisType.FullName);
            returnValue.AppendLine();

            foreach (PropertyInfo propertyInfo in thisType.GetProperties())
            {
                returnValue.AppendFormat("{0} = {1}", propertyInfo.Name, propertyInfo.GetValue(this,null));
                returnValue.AppendLine();
            }
            return returnValue.ToString();
        }
    }
}