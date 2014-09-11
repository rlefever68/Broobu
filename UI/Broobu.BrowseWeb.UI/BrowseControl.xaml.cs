using System.ComponentModel.Composition;
using System.Windows.Controls;
using System.Windows;
using System;
using Broobu.Fx.UI.Addin;

namespace AddIn
{
    [Export(typeof(IAddInControl))]
    public partial class AddInControl : IAddInControl
    {
        public AddInControl()
        {
            InitializeComponent();

            _goButton.Click += new RoutedEventHandler(delegate
                {
                    try
                    {
                        _wb.Source = new Uri("http://"+_address.Text);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
        }
    }
}
