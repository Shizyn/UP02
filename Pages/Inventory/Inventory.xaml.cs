using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UP02.Pages.Inventory
{
    public partial class Inventory : UserControl
    {
        List<Classes.Users> AllUsers = Classes.Users.Select();
        Classes.Inventorychecks inventorychecks;
        public readonly Frame _frame;
        public Inventory(Frame frame, Classes.Inventorychecks inventorychecks)
        {
            InitializeComponent();
            _frame = frame;
            this.inventorychecks = inventorychecks;
            start_dateTB.Text = inventorychecks.Start_date.ToString("yyyy-MM-dd HH:mm:ss");
            end_dateTB.Text = inventorychecks.End_date.ToString("yyyy-MM-dd HH:mm:ss");
            nameTB.Text = inventorychecks.Name;
            sotrudnikTB.Text = AllUsers.Find(x => x.Id == inventorychecks.User_id).Fio;
        }

        private void EditInventoryCheck(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Inventory.Add(_frame, inventorychecks));
        }

        private void DeleteInventoryCheck(object sender, RoutedEventArgs e)
        {
            inventorychecks.Delete();
            Classes.Inventorychecks.Select();
            _frame.Navigate(new Pages.Inventory.Main(_frame));
        }
    }
}
