using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UP02.Pages.Models
{
    public partial class Main : Page
    {
        public readonly Frame _frame;
        public List<Classes.Models> AllModels = Classes.Models.Select();
        public Main(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            foreach (Classes.Models models in AllModels)
            {
                modelsParent.Children.Add(new Pages.Models.Models(_frame, models));
            }
        }

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Main.Main(_frame));
        }
    }
}
