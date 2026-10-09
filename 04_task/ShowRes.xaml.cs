using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _04_task
{
    /// <summary>
    /// Interaction logic for ShowRes.xaml
    /// </summary>
    public partial class ShowRes : Window
    {
        public ShowRes(MyTaskText text)
        {
            InitializeComponent();

            ShowMyRes(text);
        }

        private async void ShowMyRes(MyTaskText text)
        {
            ResultText.Text = await Task.Run(() => text.print());
        }

    }
}
