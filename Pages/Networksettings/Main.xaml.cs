using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UP02.Pages.Networksettings
{
    public partial class Main : Page
    {
        public readonly Frame _frame;
        public List<Classes.Network_settings> AllNetworksettings = Classes.Network_settings.Select();
        public readonly Frame frame;
        public Main(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            foreach (Classes.Network_settings networksettings in AllNetworksettings)
            {
                networkParent.Children.Add(new Networksettings(_frame, networksettings));
            }
        }

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Main.Main(_frame));
        }
    }
}
