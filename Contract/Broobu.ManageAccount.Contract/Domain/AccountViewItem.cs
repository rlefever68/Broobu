using System;
using Pms.Framework.Domain;
using Pms.Framework.Validation;
using System.Runtime.Serialization;

namespace Pms.ManageAccount.Contract.Domain
{
    public class AccountViewItem : DomainObject<AccountViewItem>
    {
        public class Property
        {
            public const string UserName = "UserName";
            public const string ValidFrom = "ValidFrom";
            public const string ValidUntil = "ValidUntil";
            public const string CardId = "CardId";
            public const string IsActive = "IsActive";
            public const string AuthMode = "AuthMode";

            public const string FirstName = "FirstName";
            public const string LastName = "LastName";
            public const string MiddleName = "MiddleName";
            public const string EmailAddress = "EmailAddress";
            public const string Telephone1 = "Telephone1";
            public const string Telephone2 = "Telephone2";
        }


        private string _userName;
        [DataMember]
        public string UserName 
        {
            get
            {
                return _userName;
            }
            set
            {
                if(value!=_userName)
                {
                    _userName = value;
                    RaisePropertyChanged(Property.UserName);
                }
            }
        }


        private DateTime? _validFrom;
        [DataMember]
        public DateTime? ValidFrom 
        {
            get
            {
                return _validFrom;

            }
            set
            {
                if(value!=_validFrom)
                {
                    _validFrom = value;
                    RaisePropertyChanged(Property.ValidFrom);
                }
            }
        }


        private DateTime? _validUntil;
        [DataMember]
        public DateTime? ValidUntil 
        {
            get
            {
                return _validUntil;
            }
            set
            {
                if(_validUntil!=value)
                {
                    _validUntil = value;
                    RaisePropertyChanged(Property.ValidUntil);
                }
            }
        }



        private byte[] _cardId;
        [DataMember]
        public byte[] CardId 
        {
            get {return _cardId;}
            set 
            { 
                if(value!=_cardId)
                {
                    _cardId = value;
                    RaisePropertyChanged(Property.CardId);
                }
            }
        }


        private string _authMode;
        [DataMember]
        public string AuthMode 
        {
            get
            {
                return _authMode;
            }
            set
            {
                if(_authMode!=value)
                {
                    _authMode = value;
                    RaisePropertyChanged(Property.AuthMode);
                }
            }
        }

        private string _firstName;
        [DataMember]
        public string FirstName 
        {
            get {return _firstName;}
            set 
            {
                if(value!=_firstName)
                {
                    _firstName = value;
                    RaisePropertyChanged(Property.FirstName);
                }
            }
        }

        private string _lastName;
        [DataMember]
        public string LastName 
        {
            get {return _lastName;}
            set 
            {
                if(value!=_lastName)
                {
                    _lastName = value;
                    RaisePropertyChanged(Property.LastName);
                }
            }
        }


        private string _middleName;
        [DataMember]
        public string MiddleName 
        {
            get 
            {
                return _middleName;
            }
            set
            {
                if(value!=_middleName)
                {
                    _middleName = value;
                    RaisePropertyChanged(Property.MiddleName);

                }
            }
        }


        private string _emailAddress;
        [DataMember]
        public string EmailAddress 
        { 
            get {return _emailAddress;} 
            set 
            {
                if(value!=_emailAddress)
                {
                    EmailAddress = _emailAddress;
                    RaisePropertyChanged(Property.EmailAddress);
                }
            } 
        }


        private string _telephone1;
        [DataMember]
        public string Telephone1 
        { 
            get
            {
                return _telephone1;
            }
            set
            {
                if(_telephone1!=value)
                {
                    _telephone1 = value;
                    RaisePropertyChanged(Property.Telephone1);
                }
            }
        }

        private string _telephone2;
        [DataMember]
        public string Telephone2 
        { 
            get
            {
                return _telephone2;
            }
            set
            {
                if(_telephone2!=value)
                {
                    _telephone2 = value;
                    RaisePropertyChanged(Property.Telephone2);
                }
            }
        }



        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<AccountViewItem>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        protected override System.Collections.Generic.ICollection<string> Validate()
        {
            return DataErrorInfoValidator<AccountViewItem>.Validate(this);
        }
    }
}
