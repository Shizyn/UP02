using System.Windows;
using System.Windows.Controls;
using UP02.Pages.Authoriz;
using ZstdSharp.Unsafe;

namespace UP02.Pages.Main
{
    public partial class Main : Page
    {
        Classes.Users users;
        public readonly Frame _frame;


        public Main(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }
        public void OpenPage(Page pages)
        {
            frame.Navigate(pages);
        }
        private void OpenUsersList(object sender, RoutedEventArgs e) =>
                OpenPage(new Pages.Users.Main(_frame));

        private void OpenUsersAdd(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Users.Add(_frame, users));

        // Оборудование
        private void OpenEquipmentList(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Equipment.Main(_frame));

        private void OpenEquipmentAdd(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Equipment.Add(_frame));

        // Аудитории
        private void OpenRoomList(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Room.Main(_frame));

        private void OpenRoomAdd(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Room.Add(_frame));

        // Инвентаризация
        private void OpenInventoryList(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Inventory.Main(_frame));

        private void OpenInventoryAdd(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Inventory.Add(_frame));

        // Сетевые настройки
        private void OpenNetworkSettingsList(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Networksettings.Main(_frame));

        private void OpenNetworkSettingsAdd(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Networksettings.Add(_frame));

        // Материалы
        private void OpenConsumablesList(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Consumables.Main(_frame));

        private void OpenConsumablesAdd(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Consumables.Add(_frame));

        // Характеристики расходного материала
        private void OpenTypeConsumablesList(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.ConsumableCharacteristics.Main(_frame));

        private void OpenTypeConsumablesAdd(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.ConsumableCharacteristics.Add(_frame));

        // Программное обеспечение
        private void OpenSoftwareList(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Software.Main(_frame));

        private void OpenSoftwareAdd(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Software.Add(_frame));

        // Модель оборудования
        private void OpenModelsList(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Models.Main(_frame));

        private void OpenModelsAdd(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.Models.Add(_frame));

        private void GoOutButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Glav(_frame));
        }
    }
}