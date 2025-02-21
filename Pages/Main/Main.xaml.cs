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

namespace UP02.Pages.Main
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {

        public Pages.Users.Main mainUsers = new Pages.Users.Main();
        public Main()
        {
            InitializeComponent();
            OpenPage(mainUsers);
        }
        public void OpenPage(Page pages)
        {
            frame.Navigate(pages);
        }
        private void OpenUsersList(object sender, RoutedEventArgs e) =>
                OpenPage(new Pages.Users.Main());

        private void OpenUsersAdd(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Users.Add());

        // Оборудование
        private void OpenEquipmentList(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Equipment.Main());

        private void OpenEquipmentAdd(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Equipment.Add());

        // Аудитории
        private void OpenRoomList(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Room.Main());

        private void OpenRoomAdd(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Room.Add());

        // Инвентаризация
        private void OpenInventoryList(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Inventory.Main());

        private void OpenInventoryAdd(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Inventory.Add());

        // Сетевые настройки
        private void OpenNetworkSettingsList(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Networksettings.Main());

        private void OpenNetworkSettingsAdd(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Networksettings.Add());

        // Материалы
        private void OpenConsumablesList(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Consumables.Main());

        private void OpenConsumablesAdd(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Consumables.Add());

        // Характеристики расходного материала
        private void OpenTypeConsumablesList(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.ConsumableCharacteristics.Main());

        private void OpenTypeConsumablesAdd(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.ConsumableCharacteristics.Add());

        // Программное обеспечение
        private void OpenSoftwareList(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Software.Main());

        private void OpenSoftwareAdd(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Software.Add());

        // Модель оборудования
        private void OpenModelsList(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Models.Main());

        private void OpenModelsAdd(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Models.Add());

    }
}