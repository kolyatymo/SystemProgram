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

namespace _06_practical
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

        private void button_Enter(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                MessageBox.Show("Hello");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string file_path = FilePath.Tex;

            if(!File.Exists(file_path))
            {
                MessageBox.Show("File not fount");
                return;
            }
            



        }
    }
}