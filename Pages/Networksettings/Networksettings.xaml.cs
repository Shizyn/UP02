using System.Windows;
using System.Windows.Controls;

namespace UP02.Pages.Networksettings
{
    public partial class Networksettings : UserControl
    {
        Classes.Network_settings network_settings;
        public readonly System.Windows.Controls.Frame _frame;
        public Networksettings(System.Windows.Controls.Frame frame, Classes.Network_settings network_settings)        
        {
            InitializeComponent();
            _frame = frame;
            this.network_settings = network_settings;
            equipment_idTB.Text = network_settings.Equipment_id.ToString();
            ip_addressTB.Text = network_settings.Ip_address;
            subnet_maskTB.Text = network_settings.Subnet_mask;
            gatewayTB.Text = network_settings.Gateway;
            dns_serverTB.Text = network_settings.Dns_servers;
        }

        private void EditNetwork(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Networksettings.Add(_frame, network_settings));
        }

        private void DeleteNetwork(object sender, RoutedEventArgs e)
        {
            network_settings.Delete();
            Classes.Network_settings.Select();
            _frame.Navigate(new Pages.Networksettings.Main(_frame));
        }
    }
}
