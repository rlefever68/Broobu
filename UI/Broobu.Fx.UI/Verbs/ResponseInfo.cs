using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.Fx.UI.Verbs
{
    /// <summary>
    /// </summary>
    /// <remarks></remarks>
    public class ResponseInfo : DomainObject<ResponseInfo>
    {
        /// <summary>
        /// </summary>
        private VerbInfo _input;

        /// <summary>
        /// </summary>
        private XElement _response;

        /// <summary>
        /// </summary>
        private object _sender;

        /// <summary>
        ///     Gets or sets the sender.
        /// </summary>
        /// <value>The sender.</value>
        /// <remarks></remarks>
        [DataMember]
        public object Sender
        {
            get { return _sender; }
            set
            {
                _sender = value;
                RaisePropertyChanged("Sender");
            }
        }

        /// <summary>
        ///     Gets or sets the input.
        /// </summary>
        /// <value>The input.</value>
        /// <remarks></remarks>
        [DataMember]
        public VerbInfo Input
        {
            get { return _input; }
            set
            {
                _input = value;
                RaisePropertyChanged("Input");
            }
        }

        /// <summary>
        ///     Gets or sets the response.
        /// </summary>
        /// <value>The response.</value>
        /// <remarks></remarks>
        [DataMember]
        public XElement Response
        {
            get { return _response; }
            set
            {
                _response = value;
                RaisePropertyChanged("Response");
            }
        }

        /// <summary>
        ///     Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<ResponseInfo>.Validate(this, columnName);
        }

        /// <summary>
        ///     Validates this instance.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<ResponseInfo>.Validate(this);
        }
    }
}