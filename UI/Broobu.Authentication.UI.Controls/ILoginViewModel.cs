using System.ComponentModel;
using Broobu.Fx.UI;
using Broobu.Fx.UI.Attributes;
using DevExpress.Mvvm;


namespace Broobu.Authentication.UI.Controls
{
    public interface ILoginViewModel  
    {
        
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        string Password { get; set; }

        /// <summary>
        /// Gets or sets the application.
        /// </summary>
        /// <value>The application.</value>
        string ApplicationCode { get; set; }

        /// <summary>
        /// Gets or sets the application password.
        /// </summary>
        /// <value>The application password.</value>
        string ApplicationPassword { get; set; }

     


        /// <summary>
        /// Gets or sets the login command.
        /// </summary>
        /// <value>The login command.</value>
        DelegateCommand LoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the close command.
        /// </summary>
        /// <value>The close command.</value>
        DelegateCommand CloseCommand { get; set; }
       
        /// <summary>
        /// Gets a value indicating whether this instance has error.
        /// 
        /// This can be very usefull to disable/enable certain commands
        /// when an error has occurred.
        /// </summary>
        /// <value><c>true</c> if this instance has error; otherwise, <c>false</c>.</value>
        [IgnoreIsDirty]
        bool HasError { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is dirty.
        /// 
        /// A dirty instance is an instance of which one of its properties that is NOT 
        /// flagged as IsDirty has changed.
        /// </summary>
        /// <value><c>true</c> if this instance is dirty; otherwise, <c>false</c>.</value>
        bool IsDirty { get; set; }

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// An error message indicating what is wrong with this object. The default is an empty string ("").
        /// </returns>
        [IgnoreIsDirty]
        string Error { get; }

       

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        event PropertyChangedEventHandler PropertyChanged;

      
        /// <summary>
        /// Gets the Error string from the specified Property
        /// </summary>
        /// <value>Error value</value>
        string this[string columnName] { get; }
    }
}