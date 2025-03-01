using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UP02.Pages.Models
{
    public partial class Models : UserControl
    {
        List<Classes.Models_types> AllModels_Types = Classes.Models_types.Select();
        Classes.Models models;
        public readonly Frame _frame;
        public Models(Frame frame, Classes.Models models)
        {
            InitializeComponent();
            _frame = frame;
            this.models = models;
            nameTB.Text = models.Name;
            type_idTB.Text = AllModels_Types.Find(x => x.id == models.Type_id).name;
        }

        private void EditModel(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Models.Add(_frame, models));
        }

        private void DeleteModel(object sender, RoutedEventArgs e)
        {
            models.Delete();
            Classes.Models.Select();
            _frame.Navigate(new Pages.Models.Main(_frame));
        }
    }
}
