using System.Windows;
using System.Windows.Controls;

namespace UP02.Pages.Room
{
    public partial class Add : Page
    {
        public readonly Frame _frame;
        public Add(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Main.Main(_frame));
        }

        private void AddRoomBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
