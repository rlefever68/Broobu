using System.Runtime.Serialization;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.Authentication.Contract.Domain
{
    [DataContract]
    public class UserFunction : DomainObject<UserFunction>
    {   
        

        /// <summary>
        /// Gets or sets the function code.
        /// </summary>
        /// <value>The code.</value>
        [DataMember]
        public string Code;

        /// <summary>
        /// Gets or sets a value indicating whether this instance has parameter.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has parameter; otherwise, <c>false</c>.
        /// </value>
        public bool HasParameter { get; set; }

        /// <summary>
        /// Gets or sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        [DataMember]
        public string ParameterValue;



        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<UserFunction>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        protected override System.Collections.Generic.ICollection<string> Validate()
        {
            return DataErrorInfoValidator<UserFunction>.Validate(this);
        }
    }
}