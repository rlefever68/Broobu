using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.ComponentModel;

namespace WpfApplication406
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }
    }

    public class MainWindowViewModel: INotifyPropertyChanged
    {
        private TimeSpan duration;
        public TimeSpan Duration
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Duration"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
