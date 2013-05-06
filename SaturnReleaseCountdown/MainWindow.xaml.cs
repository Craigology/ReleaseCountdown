using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private DateTime _targetDate = new DateTime(2013, 8, 5);
        private DispatcherTimer _timer;

        private StarField _starField;
        private Stopwatch _lastUpdate;

        private void Callback(object sender, EventArgs eventArgs)
        {
            TimeSpan interval = DateTime.Now - _targetDate;
            DaysToGo.Text = (-1 * (int)(interval.TotalDays)).ToString();
            WeeksToGo.Text = (-1* (int)(interval.TotalDays/7)).ToString();
            SecondsToGo.Text = (-1 * (int)(interval.TotalSeconds)).ToString();
        }

        public MainWindow()
        {
            //_timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, Callback, Dispatcher.CurrentDispatcher);
            InitializeComponent();

        }

        private static bool _initializedAfterScreenSizeChanged = false;
        private void InitIfNeededAfterScreenSizeIsKnown()
        {
            if (_initializedAfterScreenSizeChanged) return;
            _initializedAfterScreenSizeChanged = true;

            _starField = new StarField(panelStarfield);
            _lastUpdate = Stopwatch.StartNew();
            CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if (_lastUpdate.ElapsedMilliseconds < 10) return;
            _starField.UpdateStars(_lastUpdate.ElapsedMilliseconds);
        }


        private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Globals.ScreenWidth = ActualWidth;
            Globals.ScreenHeight = ActualHeight;

            InitIfNeededAfterScreenSizeIsKnown();            
        }
    }
}
