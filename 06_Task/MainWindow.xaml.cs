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

namespace _06_Task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async Task<int> Factorial(int x)
        {

            return await Task.Run(() =>
            {
                int res = 1;
                for (int i = 1; i <= x; i++)
                {
                    res *= i;
                }
                return res;
            });
        }

        private async void Click_Result(object sender, RoutedEventArgs e)
        {
            int numb = int.Parse(Number.Text);
            list.Items.Add(await Factorial(numb));
        }
    }
}

