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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UP02.Pages.Models
{
    public partial class Add : Page
    {
        public readonly Frame _frame;
        public Add(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            shadow.Color = Color.FromArgb(255, 0, 96, 172);
        }

        private void AddSoftwaresBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Main.Main(_frame));
        }
    }
}
