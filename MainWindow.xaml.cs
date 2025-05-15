using System.Windows;
using System.Windows.Controls;

namespace UP02
{
    public partial class MainWindow : Window
    {

        public static MainWindow mainWindow;

        public MainWindow()
        {
            InitializeComponent();
            MainWindow.mainWindow = this;
            frame.Navigate(new Pages.Main.Main(frame));
        }
        public void OpenPage(Page pages)
        {
            frame.Navigate(pages);
        }

    }
}
