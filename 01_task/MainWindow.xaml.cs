using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
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

namespace _01_task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += _timer_Tick;
            //RefreshClick(null, null);
        }

        private void RefreshClick(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = Process.GetProcesses();
        }

        private void _timer_Tick(object? sender, EventArgs e)
        {
            RefreshClick(sender, null);
        }

        private void RadioClick(object sender, RoutedEventArgs e)
        {
            if(Second1.IsChecked == true)
                SetInterval(1);
            else if (Second2.IsChecked == true)
                SetInterval(2);
            else if (Second5.IsChecked == true)
                SetInterval(5);
            else if (stop.IsChecked == true)
                timer.Stop();
        }

        private void SetInterval(int sec)
        {
            timer.Interval = new TimeSpan(0, 0, sec);
            timer.Start();
        }

        private void Kill_Click(object sender, RoutedEventArgs e)
        {
            var res = ((Process)grid.SelectedItem);
            try
            {
                MessageBox.Show(res.ProcessName);
                res.Kill();
                RefreshClick(null, null);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Show_Detail_Click(object sender, RoutedEventArgs e)
        {
            Process selected = (Process)grid.SelectedItem;
            ShowAll showAll = new ShowAll(selected);
            showAll.Show();
        }

        private void Exe_Click(object sender, RoutedEventArgs e)
        {
            string res = Text_exe.Text;
            Process.Start($"{res}");
            grid.ItemsSource = Process.GetProcessesByName(res); 
        }
    }
}