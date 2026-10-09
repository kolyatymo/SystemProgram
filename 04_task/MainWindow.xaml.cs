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

namespace _04_task
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

        private void Click_Enter(object sender, RoutedEventArgs e)
        {
            string mytext = Mytext.Text;

            MyTaskText text = new MyTaskText();

            text.MyRows(mytext);

            ShowRes showRes = new ShowRes(text);

            showRes.Show();
        }

        private void SaveToFile(object sender, RoutedEventArgs e)
        {
            string file_name = "NyText.txt";

            MyTaskText text = new MyTaskText();
            text.MyRows(Mytext.Text);

            File.WriteAllText(file_name, text.print());
        }
    }

    public class MyTaskText
    {
        public int NumbSentences { get; set; }
        public int NumbSymbols { get; set; }
        public int NumbWords { get; set; }
        public int NumbOfInterrogativeSentences { get; set; }
        public int NumbOfExclamatorySentences { get; set; }

        public void MyRows(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if(text[i] == '.')
                {
                    NumbSentences++;
                }
                NumbSymbols++;

                if (text[i] == ' ')
                {
                    NumbWords++;
                }

                if (text[i] == '?')
                {
                    NumbSentences++;
                    NumbOfInterrogativeSentences++;
                }
                
                if (text[i] == '!')
                {
                    NumbSymbols++;
                    NumbOfExclamatorySentences++;
                } 
            }
        }

        public string print()
        {

            return  $"Number of Line --> {NumbSentences}\n" +
                    $"Numb Symbols   --> {NumbSymbols}\n" +
                    $"Numb Words     --> {NumbWords}\n" +
                    $"Number of (?)  --> {NumbOfInterrogativeSentences}\n" +
                    $"Number of (!)  --> {NumbOfExclamatorySentences}";





            /*Console.WriteLine($"Number of Line --> {NumbSentences}");
            Console.WriteLine($"Numb Symbols   --> {NumbSymbols}");
            Console.WriteLine($"Numb Words     --> {NumbWords}");
            Console.WriteLine($"Number of (?)  --> {NumbOfInterrogativeSentences}");
            Console.WriteLine($"Number of (!)  --> {NumbOfExclamatorySentences}");*/
        }

    }
}