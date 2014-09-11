using System.Collections.Generic;
using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Domain.Applets;
using Broobu.EcoSpace.Contract.Domain.Menu;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Account
{
    [DataContract]
    public class UserEnvironmentInfo : DomainObject<UserEnvironmentInfo>
    {

        private MenuContainer _menu;
        private AppletContainer _applets;

        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public string Greeting { get; set; }

        [DataMember]
        public MenuContainer Menu
        {
            get { return _menu; }
            set 
            { 
                _menu = value;
                _menu.Owner = this;
            }
        }


        [DataMember]
        public AppletContainer Applets
        {
            get { return _applets; }
            set 
            { 
                _applets = value;
                _applets.Owner = this;
            }
        }


        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<UserEnvironmentInfo>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<UserEnvironmentInfo>.Validate(this);
        }

    }
}
