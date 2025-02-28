using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace UP02.Pages.Inventory
{    
    public partial class Add : Page
    {
        List<Classes.Users> AllUsers = Classes.Users.Select();
        Classes.Inventorychecks inventorychecks;
        public readonly Frame _frame;
        public Add(Frame frame, Classes.Inventorychecks inventorychecks = null)
        {
            InitializeComponent();
            foreach (var item in AllUsers)
            {
                sotrydnikTB.Items.Add(item.Fio);
            }

            sotrydnikTB.Items.Add("Выберите .....");
            
            if (inventorychecks != null)
            {
                this.inventorychecks = inventorychecks;
                start_DatePB.Text = inventorychecks.Start_date.ToString("yyyy-MM-dd HH:mm:ss");
                end_DatePB.Text = inventorychecks.End_date.ToString("yyyy-MM-dd HH:mm:ss");
                nameTB.Text = inventorychecks.Name;
                sotrydnikTB.SelectedIndex = AllUsers.FindIndex(x => x.Id == inventorychecks.User_id);
                BthAdd.Content = $"Изменить";
            }
            _frame = frame;            
        }

        private void AddInventoryBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime start_date;
            DateTime end_date;

            DateTime.TryParse(start_DatePB.Text, out start_date);
            DateTime.TryParse(end_DatePB.Text, out end_date);

            if (this.inventorychecks == null)
            {
                Classes.Inventorychecks newInventoryChecks = new Classes.Inventorychecks(
                    0,
                    start_date,
                    end_date,
                    nameTB.Text,
                    AllUsers.Find(x => x.Fio == sotrydnikTB.SelectedItem).Id
                    );
                newInventoryChecks.Add();
                MessageBox.Show($"Инвентаризация добавлена");
            }
            if (this.inventorychecks != null)
            {
                Classes.Inventorychecks newInventoryChecks = new Classes.Inventorychecks(
                    inventorychecks.Id,
                    start_date,
                    end_date,
                    nameTB.Text,
                    AllUsers.Find(x => x.Fio == sotrydnikTB.SelectedItem).Id
                    );
                newInventoryChecks.Update();
                MessageBox.Show($"Инвентаризация изменена");
            }
            _frame.Navigate(new Main(_frame));
        }

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Main.Main(_frame));
        }        
    }
}
