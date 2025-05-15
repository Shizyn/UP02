using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UP02.Pages.Networksettings
{
    public partial class Add : Page
    {
        List<Classes.Equipment> AllEquipment = Classes.Equipment.Select();
        Classes.Network_settings network_Settings;
        public readonly Frame _frame;
        public Add(Frame frame, Classes.Network_settings network_Settings = null)
        {
            InitializeComponent();
            foreach (var item in AllEquipment)
            {
                equipmentPB.Items.Add(item.name);
            }
            if (network_Settings != null)
            {
                this.network_Settings = network_Settings;
                equipmentPB.SelectedIndex = AllEquipment.FindIndex(x => x.id == network_Settings.Equipment_id);
                ip_addressTB.Text = network_Settings.Ip_address;
                subnet_maskTB.Text = network_Settings.Subnet_mask;
                gatewayTB.Text = gatewayTB.Text;
                dns_serverTB.Text = dns_serverTB.Text;
                BthAdd.Content = $"Изменить";
            }
            _frame = frame;
        }

        private void AddNetworkBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.network_Settings == null)
            {
                Classes.Network_settings newNetwork_settings = new Classes.Network_settings(
                    0,
                    AllEquipment.Find(x => x.name == equipmentPB.SelectedItem).id,
                    ip_addressTB.Text,
                    subnet_maskTB.Text,
                    gatewayTB.Text,
                    dns_serverTB.Text
                    );
                newNetwork_settings.Add();
                MessageBox.Show($"настройки сети добавлены");
            }
            if (this.network_Settings != null)
            {
                Classes.Network_settings newNetwork_settings = new Classes.Network_settings(
                    network_Settings.Id,
                    AllEquipment.Find(x => x.name == equipmentPB.SelectedItem).id,
                    ip_addressTB.Text,
                    subnet_maskTB.Text,
                    gatewayTB.Text,
                    dns_serverTB.Text
                    );
                newNetwork_settings.Update();
                MessageBox.Show($"настройки сети изменены");
            }
            _frame.Navigate(new Main(_frame));
        }

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Main.Main(_frame));
        }
    }
}
