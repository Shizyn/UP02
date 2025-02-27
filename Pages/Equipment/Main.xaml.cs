using System.Windows;
using System.Windows.Controls;

namespace UP02.Pages.Equipment
{    
    public partial class Main : Page
    {
        public readonly Frame _frame;
        public Main(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Main.Main(_frame));
        }
    }
}
