using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace Pms.ManageWorkspaces.UI.Controls.UIInputValidations
{
    public static class CurrencyClass
    {
        public static readonly DependencyProperty CurrencyDp =
            DependencyProperty.RegisterAttached("AttachCurrency", typeof (bool), typeof (CurrencyClass),
                                                new PropertyMetadata(false, AttachCurrency));

        public static bool GetAttachCurrency(DependencyObject dp)
        {
            return (bool) dp.GetValue(CurrencyDp);
        }

        public static void SetAttachCurrency(DependencyObject dp, bool value)
        {
            dp.SetValue(CurrencyDp, value);
        }

        public static void AttachCurrency(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            if (!(dp is TextBox))
                return;
            var textBox = dp as TextBox;
            DataObject.AddPastingHandler(textBox, PastingHandler);
            textBox.PreviewTextInput += TextBox_PreviewTextInput;
            textBox.TextChanged += TextBox_TextChanged;
        }

        private static void PastingHandler(object sender, DataObjectPastingEventArgs e)
        {
            e.CancelCommand();
        }

        private static bool IsValidCurrencyFormat(string textToCheck)
        {
            return Regex.IsMatch(textToCheck, @"^[0-9,0-9]*\.?\d*$");
        }

        static void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(sender is TextBox))
                return;
            var amountTextBox = sender as TextBox;
            if (amountTextBox.Text.StartsWith(","))
            {
                amountTextBox.TextChanged -= TextBox_TextChanged;
                amountTextBox.Text = amountTextBox.Text.Substring(1);
                amountTextBox.TextChanged += TextBox_TextChanged;
            }
            if (amountTextBox.Text.Contains(" "))
            {
                amountTextBox.TextChanged -= TextBox_TextChanged;
                amountTextBox.Text = amountTextBox.Text.Replace(" ", "");
                amountTextBox.TextChanged += TextBox_TextChanged;
            }
            string oldstring = amountTextBox.Text.Contains(".")
                                        ? amountTextBox.Text
                                        : amountTextBox.Text.Length > 1 && !amountTextBox.Text.Contains(".")
                                              ? amountTextBox.Text.Insert(amountTextBox.Text.Length - 2, ".")
                                              : string.Format("{0}.00", amountTextBox.Text);
            amountTextBox.TextChanged -= TextBox_TextChanged;
            string toplace =
                ChangeToAmountFormat(amountTextBox.Text.Length > 1 && !amountTextBox.Text.Contains(".")
                                         ? amountTextBox.Text.Insert(amountTextBox.Text.Length - 2, ".")
                                         : amountTextBox.Text);
            amountTextBox.Text = toplace;
            amountTextBox.TextChanged += TextBox_TextChanged;
            foreach (var change in e.Changes)
            {
                try
                {
                    amountTextBox.CaretIndex = change.AddedLength > 0
                                                   ? change.Offset + 1 + toplace.Length - oldstring.Length
                                                   : oldstring.Length - toplace.Length > 0 ? change.Offset - 1 : change.Offset;
                }
                catch(ArgumentOutOfRangeException)
                {

                }
                break;
            }
        }
        

        static void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValidNumber(e.Text);
            if (!(sender is TextBox))
                return;
            e.Handled = !IsValidCurrencyFormat((sender as TextBox).Text.Insert((sender as TextBox).CaretIndex, e.Text));
        }

        private static bool IsValidNumber(string textToCheck)
        {
            return Regex.IsMatch(textToCheck, "^[0-9.,]$");
        }

        private static string ChangeToAmountFormat(string textToFormat)
        {
            if (string.IsNullOrEmpty(textToFormat))
                return string.Empty;
            return Convert.ToDecimal(textToFormat).ToString("###,###,##0.00");
        }
    }
}
