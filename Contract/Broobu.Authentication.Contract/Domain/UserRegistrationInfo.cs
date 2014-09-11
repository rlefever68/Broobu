using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.Authentication.Contract.Domain
{

    [DataContract]
    public class UserRegistrationInfo : DomainObject<UserRegistrationInfo>
    {
        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<UserRegistrationInfo>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<UserRegistrationInfo>.Validate(this);
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "FirstName cannot be empty")]
        [DataMember]
        private string _firstName;
        public string FirstName 
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        private string _lastName;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name cannot be empty")]
        [DataMember]
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }


        private string _telephone;
        [DataMember]
        public string Telephone
        {
            get
            {
                return _telephone;
            }
            set
            {
                _telephone = value;
                RaisePropertyChanged("Telephone");
            }
        }

        private string _mobile;
        [DataMember]
        public string Mobile
        {
            get
            {
                return _mobile;
            }
            set
            {
                _mobile = value;
                RaisePropertyChanged("Mobile");
            }
        }

        private string _email;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email cannot be empty")]
        [DataMember]
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                RaisePropertyChanged("Email");
            }
        }

        private string _password;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password cannot be empty")]
        [DataMember]
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }
        }

        private string _confirmedPassword;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password cannot be empty")]
        [DataMember]
        public string ConfirmedPassword
        {
            get
            {
                return _confirmedPassword;
            }
            set
            {
                _confirmedPassword = value;
                RaisePropertyChanged("ConfirmedPassword");
            }
        }

        private string _userName;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username cannot be empty")]
        [DataMember]
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                RaisePropertyChanged("UserName");
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
                _authMode = value;
                RaisePropertyChanged("AuthMode");
            }
        }
    }
}
