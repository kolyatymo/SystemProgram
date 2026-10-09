using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
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

namespace _03_Thread_ProgressBar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Thread thread = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            thread = new Thread(HardWork);
            thread.Start();
        }

        private void HardWork()
        {
            bool flag = false;
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (progress.Value > 0)
                {
                    progress.Value = progress.Minimum;
                }
                flag = progress.Value < progress.Maximum;
            });
            while (flag)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    progress.Value++;
                    flag = progress.Value < progress.Maximum;
                });
                Thread.Sleep(100);
            }
        }
        private void PrimeNumb(int First, int Last)
        {
            for (int i = First; i < Last; i++)
            {
                bool IsGood = true;

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        IsGood = false;
                        break;
                    }
                }
                if (IsGood)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        list.Items.Add(i);
                    });
                    Thread.Sleep(100);
                }
            }
        }

        private void Fibonacci()
        {
            int a = 0;
            int b = 1;
            for (int i = 0; i < 100; i++)
            {

                Application.Current.Dispatcher.Invoke(() =>
                {
                    list2.Items.Add(a);
                });

                int n = a + b;
                a = b;
                b = n;
                Thread.Sleep(50);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int first;

            if (string.IsNullOrEmpty(firstN.Text))
                first = 2;
            else
                first = int.Parse(firstN.Text);
            
            int second;

            if (string.IsNullOrEmpty(secondN.Text))
                second = 1000;
            else
                second = int.Parse(secondN.Text);

            Thread thread = new Thread(() => PrimeNumb(first,second));
            thread.Start();

        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                MessageBox.Show("Prime numbers");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            list.Items.Clear();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(() => Fibonacci());
            thread.Start();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            list2.Items.Clear();
        }
    }
}