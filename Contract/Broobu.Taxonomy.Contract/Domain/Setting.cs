using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.Taxonomy.Contract.Domain
{

    [DataContract]
    public class Setting : DomainObject<Setting>
    {

    

        class Property
        {
            public const string ApplicationFunctionId = "ApplicationFunctionId";
            public const string AccountId = "AccountId";
            public const string RoleId = "RoleId";
            public const string ObjectId = "ObjectId";
            public const string SettingInfo = "SettingInfo";
        }

        private string _applicationFunctionId;

        [DataMember]
        public string ApplicationFunctionId
        {
            get
            {
                return _applicationFunctionId;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value)) 
                    value = SysConst.NullGuid;
                _applicationFunctionId = value;
                RaisePropertyChanged(Property.ApplicationFunctionId);
            }
        }



        private string _objectId;

        [DataMember]
        public string ObjectId
        {
            get
            {
                return _objectId;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    value = SysConst.NullGuid;
                _objectId = value;
                RaisePropertyChanged(Property.ObjectId);
            }
        }





        private string _accountId;
        [DataMember]
        public string AccountId
        {
            get
            {
                return _accountId;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))  
                    value = SysConst.NullGuid;
                _accountId = value;
                RaisePropertyChanged(Property.AccountId);
            }
        }


        private string _roleId;
        [DataMember]
        public string RoleId
        {
            get
            {
                return _roleId;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value)) 
                    value = SysConst.NullGuid;
                _roleId = value;
                RaisePropertyChanged(Property.RoleId);
            }
        }


        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<Setting>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<Setting>.Validate(this);
        }

        public override string ToString()
        {
            return String.Format("SettingItem: Id={0}, ApplicationFunctionId={1}, AccountId={2}, RoleId={3}",
                Id, ApplicationFunctionId, AccountId, RoleId);
        }
    }
}
