// ***********************************************************************
// Assembly         : Broobu.MonitorDisco.Contract
// Author           : Rafael Lefever
// Created          : 12-25-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 12-25-2013
// ***********************************************************************
// <copyright file="DiscoInfo.cs" company="Broobu Pvt.Ltd.">
//     Copyright (c) Broobu Pvt.Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Runtime.Serialization;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.MonitorDisco.Contract.Domain
{
    /// <summary>
    /// Class DiscoInfo.
    /// </summary>
    [DataContract]
    public class DiscoInfo : DomainObject<DiscoInfo>
    {
        /// <summary>
        /// The _status
        /// </summary>
        private string _status;


        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [DataMember]
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                if (HasErrors)
                    _status = DiscoStatus.Error;
                RaisePropertyChanged("Status");
            }
        }

        /// <summary>
        /// Gets or sets the protocol.
        /// </summary>
        /// <value>The protocol.</value>
        [DataMember]
        public string Protocol { get; set; }

        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>The host.</value>
        [DataMember]
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>The port.</value>
        [DataMember]
        public string Port { get; set; }

        /// <summary>
        /// Gets or sets the layer.
        /// </summary>
        /// <value>The layer.</value>
        [DataMember]
        public string Layer { get; set; }

        /// <summary>
        /// Gets or sets the application.
        /// </summary>
        /// <value>The application.</value>
        [DataMember]
        public string Application { get; set; }

        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        /// <value>The service.</value>
        [DataMember]
        public string Service { get; set; }


        /// <summary>
        /// Gets or sets the endpoint.
        /// </summary>
        /// <value>The endpoint.</value>
        [DataMember]
        public string Endpoint { get; set; }

        /// <summary>
        /// Gets or sets the contract.
        /// </summary>
        /// <value>The contract.</value>
        [DataMember]
        public string Contract { get; set; }



        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            var di = (obj as DiscoInfo);
            if (di == null) return false;
            return (di.Protocol == Protocol) &&
                (di.Contract == Contract);
        }


        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode()
                   + Status.GetHashCode()
                   + Protocol.GetHashCode()
                   + Host.GetHashCode()
                   + Port.GetHashCode()
                   + Layer.GetHashCode()
                   + Application.GetHashCode()
                   + Service.GetHashCode();
        }


        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<DiscoInfo>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<DiscoInfo>.Validate(this);
        }


        ///// <summary>
        ///// Builds the metadata.
        ///// </summary>
        ///// <param name="builder">The builder.</param>
        //public static void BuildMetadata(MetadataBuilder<DiscoInfo> builder)
        //{
        //    builder.Property(x => x.Application).DisplayName("Application");
        //    builder.Property(x => x.Contract).DisplayName("Contract");
        //    builder.Property(x => x.Endpoint).DisplayName("Endpoint");
        //    builder.Property(x => x.Host).DisplayName("Host");
        //    builder.Property(x => x.Layer).DisplayName("Layer");
        //    builder.Property(x => x.Port).DisplayName("Port");
        //    builder.Property(x => x.Protocol).DisplayName("Protocol");
        //    builder.Property(x => x.Service).DisplayName("Service");
        //    builder.Property(x => x.Status).DisplayName("Status");
        //}
    

    }
}
