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

namespace UP02.Pages.Authoriz
{
    /// <summary>
    /// Логика взаимодействия для Glav.xaml
    /// </summary>
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
                OpenPage(new Pages.Authoriz.Authoriz(_frame));
            }
        }

        // Навигация на страницу регистрации
        private void NavigateToRegisterPage(object sender, RoutedEventArgs e)
        {
            if (_frame != null)
            {
                OpenPage(new Pages.Regist.Regist(_frame));
            }
        }
    }
}