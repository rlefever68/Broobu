
#region Namespace

using System;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Windows.Input;
using DevExpress.Xpf.Grid;
using System.Xml;

#endregion

namespace Pms.ManageWorkspaces.UI.Controls.UIInputValidations
{
    /// <summary>
    /// 
    /// </summary>
    public static class InputValidation
    {

        #region Dependency Properties

        /// <summary>
        /// A Dependency Property that sets validation to the textbox.
        /// Note:- If Decimal or Numeric validation type is selected by default pasting functionality will be disabled
        /// </summary>
        public static readonly DependencyProperty TextValidationDp =
            DependencyProperty.RegisterAttached("MyValidation", typeof (ValidationTypes), typeof (InputValidation),
                                                new PropertyMetadata(ValidationTypes.None, ValidationType));

        /// <summary>
        /// A Dependency Property that sets the decimal numbers to be accepted for decimal type validaton.
        /// Note:- By default 2 numbers will be permited though user gives less number
        /// </summary>
        public static readonly DependencyProperty DecimalNumbersDp =
            DependencyProperty.RegisterAttached("DecimalNumbers", typeof (int), typeof (InputValidation),
                                                new PropertyMetadata(2, DecimalNumbers));

        /// <summary>
        /// A Dependency Property that disables the paste functionality in a textbox
        /// Note:- If a textbox validation type is either decimal or numeric user can not disable paste functionality
        /// </summary>
        public static readonly DependencyProperty DisablePasteFunctionalityDp =
            DependencyProperty.RegisterAttached("DisablePasteFunctionality", typeof (bool), typeof (InputValidation),
                                                new PropertyMetadata(false, DisablePasteFunctionality));

        #endregion

        #region Disable Paste functionality methods


        /// <summary>
        /// A Method that disabled the paste functionality for the textbox
        /// </summary>
        /// <param name="dp">
        /// A <see cref="System.Windows.DependencyObject"/> that contains the property
        /// </param>
        /// <returns>
        /// A <see cref="System.Boolean"/> value that holds paste functionality either enabled/disabled
        /// for the particular Dependency object
        /// </returns>
        public static bool GetDisablePasteFunctionality(DependencyObject dp)
        {
            return (bool)dp.GetValue(DisablePasteFunctionalityDp);
        }

        /// <summary>
        /// A Method that sets the value to the particular Dependency object
        /// </summary>
        /// <param name="dp">
        /// A <see cref="System.Windows.DependencyObject"/> that holds the property
        /// </param>
        /// <param name="value">
        /// A value that should set to the paritcular dependency object
        /// </param>
        public static void SetDisablePasteFunctionality(DependencyObject dp, bool value)
        {
            var selectedValiation = GetValidationType(dp);
            if (selectedValiation == ValidationTypes.Decimal || selectedValiation == ValidationTypes.Numeric)
                return;
            dp.SetValue(DisablePasteFunctionalityDp, value);
        }

        private static void DisablePasteFunctionality(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            var textBox = dp as TextBox;
            if (textBox == null)
                return;
            DataObject.AddPastingHandler(dp, TextBoxPastingHandler);
        }

        private static void TextBoxPastingHandler(object sender, DataObjectPastingEventArgs e)
        {
            e.CancelCommand();
        }

        #endregion

        #region Decimal Number Methods

        /// <summary>
        /// A Method that gets the number of decimals to be accpeted for the decimal type textbox
        /// </summary>
        /// <param name="dp">
        /// A <see cref="System.Windows.DependencyObject"/> that contains the property
        /// </param>
        /// <returns>
        /// A <see cref="System.Int32"/> that holds the decimal numbers to be permited for the
        /// particular dependency object
        /// </returns>
        public static int GetDecimalNumbers(DependencyObject dp)
        {
            return (int)dp.GetValue(DecimalNumbersDp);
        }

        /// <summary>
        /// A Method that sets the value to the particular Dependency object
        /// </summary>
        /// <param name="dp">
        /// A <see cref="System.Windows.DependencyObject"/> that holds the property
        /// </param>
        /// <param name="value">
        /// A value that should set to the paritcular dependency object
        /// </param>
        public static void SetDecimalNumbers(DependencyObject dp, int value)
        {
            if (value < 2)
                value = 2;
            dp.SetValue(DecimalNumbersDp, value);
        }

        public static void DecimalNumbers(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion

        #region TextBox Validation Methods

        /// <summary>
        /// A Method that gets the validation type for the textbox
        /// </summary>
        /// <param name="dp">
        /// A <see cref="System.Windows.DependencyObject"/> that contains the property
        /// </param>
        /// <returns>
        /// A selected enum type for the particular Dependency object
        /// </returns>
        public static ValidationTypes GetValidationType(DependencyObject dp)
        {
            return (ValidationTypes)dp.GetValue(TextValidationDp);
        }

        /// <summary>
        /// A Method that sets the value to the particular Dependency object
        /// </summary>
        /// <param name="dp">
        /// A <see cref="System.Windows.DependencyObject"/> that holds the property
        /// </param>
        /// <param name="value">
        /// A value that should set to the paritcular dependency object
        /// </param>
        public static void SetValidationType(DependencyObject dp, ValidationTypes value)
        {
            dp.SetValue(TextValidationDp, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ValidationType(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var txt = (Control) Convert.ChangeType(sender, sender.GetType());
            if (txt == null)
                return;
            txt.PreviewTextInput += Txt_PreviewTextInput;
            var selectedValiation = GetValidationType(sender);
            if (selectedValiation == ValidationTypes.Decimal || selectedValiation == ValidationTypes.Numeric)
            {
                DataObject.AddPastingHandler(txt, TextBoxPastingHandler);
                txt.PreviewKeyDown += Txt_PreviewKeyDown;
            }
            if (selectedValiation == ValidationTypes.AlphaNumeric)
                DataObject.AddPastingHandler(txt, TextBoxPastingHandler);
        }

        /// <summary>
        /// For disabling space
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Txt_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        #endregion

        #region Private Methods

        private static void Txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(sender is DependencyObject))
                return;
            ValidationTypes selectedValiation = GetValidationType(sender as DependencyObject);
            if (selectedValiation == ValidationTypes.None)
                return;
            var str = new StringEnumeration(typeof(ValidationTypes));
            e.Handled = IsValidData(e.Text,
                                    str.GetStringValue(Enum.GetName(typeof(ValidationTypes), selectedValiation)));
            var textBox = sender as TextBox;
            if (textBox == null)
                return;
            try
            {
                if (selectedValiation == ValidationTypes.Decimal)
                {
                    if(e.Text==".")
                    {
                        int previousCaretIndex = textBox.CaretIndex;
                        textBox.Text = !textBox.Text.Contains(".") ? string.Format("{0}.0", textBox.Text) : textBox.Text;
                        textBox.CaretIndex = previousCaretIndex + 1;
                    }
                    e.Handled =
                        IsValidNumberData(textBox.Text.Insert(textBox.CaretIndex, e.Text),
                                          @"^-?\d*\.?\d{0," + GetDecimalNumbers(sender as DependencyObject) + "}?$");
                }
            }
            catch(ArgumentOutOfRangeException)
            {
            }
            if (selectedValiation == ValidationTypes.Numeric)
                e.Handled =
                    IsValidNumberData(textBox.Text.Insert(textBox.CaretIndex, e.Text), @"^\d*$");
        }

        private static bool IsValidNumberData(string decimalText, string pattern)
        {
            return !Regex.IsMatch(decimalText, pattern);
        }

        private static bool IsValidData(string textToValidate, string validationExpression)
        {
            return !Regex.IsMatch(textToValidate, validationExpression);
        }

        #endregion
    }
}