using System.IO;
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

namespace _06_Async_await_demo_first
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Generate(object sender, RoutedEventArgs e)
        {
            /*int value = DenerateValue();
            list.Items.Add(value);*/
            
            // 1
            //Task<int> task = Task.Run(DenerateValue);
            //var value = await task; // асинхроне - await дає можливість виконувати таску а інші потоки також виконуються і програма не зависає

            // 2
            /*var task = await Task.Run(DenerateValue);
            list.Items.Add(task);*/

            // 3
            //list.Items.Add(await Task.Run(DenerateValue));
            //MessageBox.Show("Complete");

            // 4
            list.Items.Add(await GeneratevalueAsync());

            // async - alow method to use await keywords
            // await - wait task without freezing



            /*FileStream file = new FileStream();
            file.CopyTo();
            file.CopyToAsync();
            file.Read();
            file.ReadAsync();
            file.WriteAsync(); // Async - асинхроне*/
        }

        int DenerateValue()
        {
            MessageBox.Show("Generate");
            Thread.Sleep(rnd.Next(5000));
            return rnd.Next(1000);
        }

        Task<int> GeneratevalueAsync()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(rnd.Next(5000));
                return rnd.Next(1000);
            });
        }
    }
}