using IOExtensions;
using Microsoft.Win32;
using PropertyChanged;
using System.Collections.ObjectModel;
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

namespace _07_Copy_File
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VieModel model;
        public MainWindow()
        {
            InitializeComponent();

            model = new VieModel()
            {
                Source = @"C:\Users\Vlad\Downloads\Examen.zip",
                Destination = @"C:\Users\Vlad\Downloads\52",
                Progresss = 0
            };
            this.DataContext = model;

        }
        private async void CoppyButtonClick(object sender, RoutedEventArgs e)
        {
            string FileName = System.IO.Path.GetFileName(model.Source);

            string destFilePath = System.IO.Path.Combine(model.Destination, FileName);
            // way 1 --> File.Copy(Source, destFilePath,true);

            CopyProcessInfo info = new CopyProcessInfo(FileName);
            model.AddProcess(info);

            await CopyFileAsync(model.Source,destFilePath, info);
            info.Percentage = 100;
            MessageBox.Show("Complate");
        }

        private Task CopyFileAsync(string src, string dest, CopyProcessInfo info)
        {

            return FileTransferManager.CopyWithProgressAsync(src, dest, (progress) =>
            {
                model.Progresss = (int)progress.Percentage;
                info.Percentage = progress.Percentage;
                info.BytesPerSecond = progress.BytesPerSecond;
            },false);

            /*return Task.Run(() =>
            {
                using (FileStream srcStream = new FileStream(src, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream destStream = new FileStream(dest, FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[1024 * 8]; // 8 kb
                        int bytes = 0;
                        do
                        {
                            bytes = srcStream.Read(buffer, 0, buffer.Length);
                            destStream.Write(buffer, 0, bytes);
                            float percenttage = destStream.Length / (srcStream.Length / 100);
                            //Thread.Sleep(1000);
                            model.Progresss = (int)percenttage;

                        } while (bytes > 0);
                    }
                }
            });*/
        }

        private void OpenSourceButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if(dialog.ShowDialog() == true)
            {
                model.Source = dialog.FileName;
                //srcTextBox.Text = model.Source;
            }
        }

        private void OpenDestButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog dialog = new OpenFolderDialog();
            if(dialog.ShowDialog() == true)
            {
                model.Destination = dialog.FolderName;
                //destTextBox.Text = model.Destination;
            }
        }

    }

    [AddINotifyPropertyChangedInterface]

    public class VieModel
    {
        private ObservableCollection<CopyProcessInfo> processes;
        public string Source { get; set; }
        public string Destination { get; set; }
        public int Progresss { get; set; }
        public bool IsWaiting => Progresss == 0;
        public VieModel()
        {
            processes = new ObservableCollection<CopyProcessInfo>();
        }
        public IEnumerable<CopyProcessInfo> Processes => processes; // get
        public void AddProcess(CopyProcessInfo info)
        {
            processes.Add(info);
        }
    }

    public class CopyProcessInfo
    {
        public string FileName { get; set; }
        public double Percentage { get; set; }
        public int PercentageInt => (int)Percentage;
        public double BytesPerSecond { get; set; }
        public double MegaBytesPerSecond => Math.Round(BytesPerSecond / 1024 / 1024, 1);
        public CopyProcessInfo(string fileName)
        {
            FileName = fileName;
        }
    }
}

