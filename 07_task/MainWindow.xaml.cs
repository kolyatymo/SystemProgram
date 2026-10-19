using Microsoft.Win32;
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

namespace _07_task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_Directory(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog dialog = new OpenFolderDialog();
            if (dialog.ShowDialog() == true)
            {
                Source = dialog.FolderName;
                srcTextBox.Text = Source;           
            }
        }

        private void Dest_Directory(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog dialog = new OpenFolderDialog();
            if(dialog.ShowDialog() == true)
            {
                Destination = dialog.FolderName;
                destTextBox.Text = Destination;
            }
        }

        private void Copy_Directory(object sender, RoutedEventArgs e)
        {
            DirectoryCopy(Source, Destination);
        }

        private void DirectoryCopy(string source, string destination)
        {
            Directory.CreateDirectory(destination);

            foreach (var F in Directory.GetFiles(source))
            {
                string FileName = System.IO.Path.GetFileName(F);
                //File.Copy(F, FileName, true);
                File.Copy(F, System.IO.Path.Combine(destination, FileName), true);
            }
            foreach (var Direc in Directory.GetDirectories(source))
            {
                string DirectName = System.IO.Path.GetFileName(destination);
                DirectoryCopy(Direc, System.IO.Path.Combine(destination, DirectName));
            }
        }
    }
}