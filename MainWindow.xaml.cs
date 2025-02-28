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
using UP02.Pages;

namespace UP02
{
    public partial class MainWindow : Window
    {

        public static MainWindow mainWindow;

        public MainWindow()
        {
            InitializeComponent();

            MainWindow.mainWindow = this;
            frame.Navigate(new Pages.Authoriz.Glav(frame));
        }
        public void OpenPage(Page pages)
        {
            frame.Navigate(pages);
        }

    }
}
