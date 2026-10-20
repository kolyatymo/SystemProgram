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

namespace Final_Exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Progres { get; set; }
        public string Source { get; set; }
        public string[] SourcesFile { get; set; }
        public string Word { get; set; }
        public string[] FileNames { get; set; }

        public int Count = 0;

        public int[] Counts { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            MyProgressBar.Value = 0;

        }

        private void SelectDirectory_Button(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog dialog = new OpenFolderDialog();
            if(dialog.ShowDialog() == true)
            {
                Source = dialog.FolderName;
                Word = MyWords.Text;
            }
        }

        private async void Go_Button(object sender, RoutedEventArgs e)
        {
            Count = 0;

            await Task.Run(() => SearchWords(Word, Source));

            MyListNameFile.Items.Clear();
            MyListPathFile.Items.Clear();
            MyListCountWord.Items.Clear();

            MyListPathFile.Items.Add(string.Join("\n", SourcesFile));
            MyListCountWord.Items.Add(string.Join("\n", Counts));
            MyListNameFile.Items.Add(string.Join("\n", FileNames));
        }

        public void SearchWords(string word, string source)
        {
            Directory.CreateDirectory(source);
            
            List<int> counts = new List<int>();
            List<string> filenames = new List<string>();
            List<string> sourcesfile = new List<string>();

            var files = Directory.GetFiles(source, "*", SearchOption.AllDirectories);

            int total = files.Length;
            int proces = 0;

            foreach (var f in files)
            {
                string Content = File.ReadAllText(f);

                string[] words = Content.Split(new char[] { ' ', ',', '.', '!', '?' },StringSplitOptions.RemoveEmptyEntries);

                bool found = false;

                foreach (var w in words)
                {
                    if (w == word)
                    {
                        Count++;
                        found = true;
                    }
                }

                if(found)
                {
                    filenames.Add(System.IO.Path.GetFileName(f));
                    sourcesfile.Add(f);
                    counts.Add(Count);
                    Count = 0;
                }

                proces++;

                if(total > 0)
                {
                    Progres = (int)((double)proces / total * 100);
                    Dispatcher.Invoke(() =>
                    {
                        MyProgressBar.Value = Progres;
                    });
                }
            }

            Counts = counts.ToArray();
            FileNames = filenames.ToArray();
            SourcesFile = sourcesfile.ToArray();
        }

        private async void SaveToFile_Button(object sender, RoutedEventArgs e)
        {
            string FileNamee = "MyTextInfo.txt";

            if(File.Exists(FileNamee))
            {
                File.Delete(FileNamee);
            }

            string text = $"Name File --> \n{string.Join("\n", FileNames)}\n" +
                          $"Path File --> \n{string.Join("\n", SourcesFile)}\n" +
                          $"word ({Word}) Count --> \n{string.Join("\n", Counts)}";


            await Task.Run(() => File.AppendAllText(FileNamee, text));
        }
    }
}
