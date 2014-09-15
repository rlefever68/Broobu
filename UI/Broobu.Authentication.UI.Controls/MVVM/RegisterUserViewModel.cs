// ***********************************************************************
// Assembly         : Broobu.Authentication.UI.Controls
// Author           : Rafael Lefever
// Created          : 07-30-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-14-2014
// ***********************************************************************
// <copyright file="RegisterUserViewModel.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Threading;
using System.Windows;
using Broobu.Authentication.Contract;
using Broobu.Authentication.Contract.Domain;
using Broobu.Authentication.UI.Controls.Views;
using Broobu.Fx.UI;
using Broobu.Fx.UI.Domain;
using Broobu.Fx.UI.MVVM;
using Broobu.Fx.UI.ValidationRules;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using Wulka.Crypto;
using ValidationResult = System.Windows.Controls.ValidationResult;

namespace Broobu.Authentication.UI.Controls.Mvvm
{
    /// <summary>
    /// Class RegisterUserViewModel.
    /// </summary>
    public class RegisterUserViewModel :FxViewModelBase
    {
        /// <summary>
        /// The _feedback
        /// </summary>
        private string _feedback;

        /// <summary>
        /// The _user name is unique
        /// </summary>
        private bool _userNameIsUnique = true;

        private string _oldEmail;

        /// <summary>
        /// Gets or sets the user information.
        /// </summary>
        /// <value>The user information.</value>
        public UserRegistrationInfo UserInfo  {get;set;}


        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterUserViewModel"/> class.
        /// </summary>
        public RegisterUserViewModel()
        {
            UserInfo = new UserRegistrationInfo();
            Registering = false;
            UserNameIsUnique = false;
        }

        /// <summary>
        /// Initializes the ViewModel the first time it is called.
        /// This method will be called from the View that implements the
        /// ViewModel
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel</param>
        protected override void InitializeInternal(object[] parameters)
        {
            
            Feedback = "Please complete this form.";

        }


        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password 
        { 
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the confirmed password.
        /// </summary>
        /// <value>The confirmed password.</value>
        public string ConfirmedPassword { get; set; }


        /// <summary>
        /// Goes the back.
        /// </summary>
        [Command(Name="GoBack",UseCommandManager = true)]
        public void GoBack()
        {
            Messenger.Default.Send(new NavigateMvvmMessage() 
            {
                ViewName = LoginView.ID,
                Header = LoginView.HEADER
            });
        }



        /// <summary>
        /// Submits this instance.
        /// </summary>
         [Command(Name = "Submit", UseCommandManager = true,CanExecuteMethodName = "CanSubmit")]
        public void Submit()
        {
             Registering = true;
             UserInfo.Password = CryptoEngine.Encrypt(Password);
             UserInfo.ConfirmedPassword = CryptoEngine.Encrypt(ConfirmedPassword);
             UserInfo.UserName = UserInfo.Email;
             if (UserInfo.HasErrors) return;
             Feedback = String.Format("Registering User: {0} {1}.", UserInfo.FirstName, UserInfo.LastName);
             AuthenticationPortal
                 .Authentication
                 .RegisterNewUserAsync(UserInfo, RegisterNewUserCompleted);
        }

         /// <summary>
         /// Gets or sets a value indicating whether this <see cref="RegisterUserViewModel"/> is registering.
         /// </summary>
         /// <value><c>true</c> if registering; otherwise, <c>false</c>.</value>
        public bool Registering { get; set; }


        /// <summary>
        /// Determines whether this instance can submit.
        /// </summary>
        /// <returns><c>true</c> if this instance can submit; otherwise, <c>false</c>.</returns>
        public bool CanSubmit()
        {
            return Validate();
        }




        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Validate()
        {
            Feedback = "";
            var valid = true;
            if(Registering)
            {
                valid = false;
                Feedback = "Registering...\n";
            }
            if (string.IsNullOrEmpty(UserInfo.Email))
            {
                valid = false;
                //Feedback += "User name is empty.\n";
            }
            else
            {
                if (new EmailRule().Validate(UserInfo.Email, null) != ValidationResult.ValidResult)
                {
                    valid = false;
                    //Feedback += "Invalid email address.\n";
                }
                else
                {
                    CheckUserNameUnique();
                    if (ShowUsernameFeedback)
                    {
                        ShowUsernameFeedback = false;
                        if (UserNameIsUnique)
                        {
                            Feedback += "Username is available\n";
                        }
                        else
                        {
                            Feedback = "Username is not available\n";
                        }
                    }
                }
            }
            if (string.IsNullOrEmpty(UserInfo.FirstName))
            {
                valid = false;
                //Feedback += "First name should not be empty.\n";
            }
            if (string.IsNullOrEmpty(UserInfo.LastName))
            {
                valid = false;
                //Feedback += "Last name should not be empty.\n";
            }
            if(string.IsNullOrEmpty(Password))
            {
                valid = false;
               // Feedback += "Password must not be empty.\n";
            }
            if (string.IsNullOrEmpty(ConfirmedPassword))
            {
                valid = false;
             //   Feedback += "Password confirmation must not be empty.\n";
            }
            if (String.IsNullOrWhiteSpace(Password) || String.IsNullOrWhiteSpace(ConfirmedPassword)) return valid;
            if (Password == ConfirmedPassword) return valid;
            Feedback = "Password and confirmed passwords don't match.\n";
            return false;
        }

        public bool ShowUsernameFeedback { get; set; }

        /// <summary>
        /// Checks the user name unique.
        /// </summary>
        private void CheckUserNameUnique()
        {
            if (UserInfo.Email == _oldEmail) return;
            _oldEmail = UserInfo.Email;
            AuthenticationPortal
                .Authentication
                .UserNameExistsAsync(UserInfo.Email, (b) =>
                {
                    UserNameIsUnique = !b;
                    ShowUsernameFeedback = true;
                    Validate();
                });
        }


        /// <summary>
        /// Gets or sets a value indicating whether [user name is unique].
        /// </summary>
        /// <value><c>true</c> if [user name is unique]; otherwise, <c>false</c>.</value>
        public bool UserNameIsUnique
        {
            get { return _userNameIsUnique; }
            set
            {
                _userNameIsUnique = value;
            }
        }



        /// <summary>
        /// Registers the new user completed.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void RegisterNewUserCompleted(UserRegistrationInfo obj)
        {
            Registering = false;
            Feedback = !obj.HasErrors 
                ? String.Format("Your registration is received.\nA confirmation email has been sent to '{0}'.", UserInfo.Email) 
                : obj.Error;
            Application.Current.DoEvents();
            Thread.Sleep(3000);
            Messenger.Default.Send(new NavigateMvvmMessage()
            {
                Header = LoginView.HEADER,
                ViewName = LoginView.ID
            });
        }

        /// <summary>
        /// Gets or sets the feedback.
        /// </summary>
        /// <value>The feedback.</value>
        public string Feedback
        {
            get { return _feedback; }
            set { _feedback = value; RaisePropertyChanged("Feedback"); }
        }
    }
}
