
namespace Pms.ManageWorkspaces.UI.Controls.UIInputValidations
{

    public enum ValidationTypes 
    {
        /// <summary>
        /// No Validation will be done
        /// </summary>
        [StringValue("")]
        None = 0,
        /// <summary>
        /// Only integer numbers will be allowed
        /// </summary>
        [StringValue("^[0-9]$")]
        Numeric = 1,
        /// <summary>
        /// Number and alphabets are allowed
        /// </summary>
        [StringValue("^[a-z A-Z 0-9]$")]
        AlphaNumeric = 2,
        /// <summary>
        /// Decimal, Integer values are allowed
        /// </summary>
        [StringValue("^[0-9.]$")]
        Decimal = 3,
        /// <summary>
        /// Number,alphabets and special characters are allowed
        /// </summary>
        [StringValue("^[\\d+\\w+!@#$%^&*()<>,-.//?/:;'|+=-\\{\\}]$")]
        Default = 4
    }
}