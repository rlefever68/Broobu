using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Iris.Fx.Domain;
using Iris.Fx.Validation;

namespace Iris.MonitorSession.Contract.Domain
{
    [DataContract]
    public class SessionViewItem : DomainObject<SessionViewItem>
    {
        [DataMember]
        public string AccountId { get; set; }
        [DataMember]
        public string AuthenticationMode { get; set; }
        [DataMember]
        public DateTime LastActivity { get; set; }
        [DataMember]
        public DateTime LoggedInAt { get; set; }
        [DataMember]
        public string Host { get; set; }
        [DataMember]
        public string UserFullName { get; set; }
        [DataMember]
        public string Telephone { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Username { get; set; }



        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<SessionViewItem>.Validate(this, columnName);
        }
        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<SessionViewItem>.Validate(this);
        }
    }
}
