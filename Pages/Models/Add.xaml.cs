using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UP02.Pages.Models
{
    public partial class Add : Page
    {
        List<Classes.Models_types> AllModels_Types = Classes.Models_types.Select();
        Classes.Models models;
        public readonly Frame _frame;
        public Add(Frame frame, Classes.Models models = null)
        {
            InitializeComponent();
            foreach (var item in AllModels_Types)
            {
                type_idTB.Items.Add(item.name);
            }

            type_idTB.Items.Add("Выберите .....");

            if (models != null)
            {
                this.models = models;
                namePB.Text = models.Name;
                type_idTB.SelectedIndex = AllModels_Types.FindIndex(x => x.id == models.Type_id);
                BthAdd.Content = $"Изменить";
            }
            _frame = frame;
            shadow.Color = Color.FromArgb(255, 0, 96, 172);
        }

        private void AddSoftwaresBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.models == null)
            {
                Classes.Models newModels = new Classes.Models(
                    0,
                    namePB.Text,
                    AllModels_Types.Find(x => x.name == type_idTB.SelectedItem).id
                    );
                newModels.Add();
                MessageBox.Show($"Модель добавлена");
            }
            if (this.models != null)
            {
                Classes.Models newModels = new Classes.Models(
                    models.Id,
                    namePB.Text,
                    AllModels_Types.Find(x => x.name == type_idTB.SelectedItem).id
                    );
                newModels.Update();
                MessageBox.Show($"Модель изменена");
            }
            _frame.Navigate(new Main(_frame));
        }

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Main.Main(_frame));
        }
    }
}
