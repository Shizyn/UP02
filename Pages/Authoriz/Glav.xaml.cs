using System.Windows;
using System.Windows.Controls;

namespace UP02.Pages.Authoriz
{
    public partial class Glav : Page
    {
        private readonly Frame _frame;
        public Glav(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }
        public void OpenPage(Page pages)
        {
            frame.Navigate(pages);
        }
        private void NavigateToLoginPage(object sender, RoutedEventArgs e)
        {
            if (_frame != null)
            {
                OpenPage(new Authoriz(_frame));
            }
        }

        // Навигация на страницу регистрации
        private void NavigateToRegisterPage(object sender, RoutedEventArgs e)
        {
            if (_frame != null)
            {
                OpenPage(new Regist.Regist(_frame));
            }
        }
    }
}