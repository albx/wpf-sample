using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ProcessRunner
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            DataContext = SetupProcessViewModel.Default();
            StartDate.Value = (DataContext as SetupProcessViewModel).Start;
            EndDate.Value = (DataContext as SetupProcessViewModel).End;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var startDate = Convert.ToDateTime(StartDate.Value);
            var endDate = Convert.ToDateTime(EndDate.Value);

            var ticks = (endDate - startDate);
            int ticksMilliseconds = (int)ticks.TotalMilliseconds;

            Task.Delay((startDate - DateTime.Now)).ContinueWith((t) =>
            {
                var cmd = Process.Start("cmd.exe");
                cmd.WaitForExit(ticksMilliseconds);

                //Thread.Sleep(ticksMilliseconds);
                cmd.Kill();
                cmd.Close();
            });
        }
    }
}
