using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SaturnReleaseCountdown
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DateTime _targetDate = new DateTime(2013, 7, 29);
        private DispatcherTimer _timer;

        private void Callback(object sender, EventArgs eventArgs)
        {
            DaysToGo.Text = (DateTime.Now.Date - _targetDate).TotalDays.ToString();
        }

        public MainWindow()
        {
            _timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, Callback, Dispatcher.CurrentDispatcher);
            InitializeComponent();
        }
    }
}
