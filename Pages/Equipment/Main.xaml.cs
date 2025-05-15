using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UP02.Pages.Equipment
{    
    public partial class Main : Page
    {
        public List<Classes.Equipment> AllEquipment = Classes.Equipment.Select();
        public readonly Frame _frame;
        public Main(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            foreach (Classes.Equipment equipment in AllEquipment)
            {
                EquipmentParent.Children.Add(new Pages.Equipment.Equipment(_frame, equipment));
            }
        }

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Main.Main(_frame));
        }
    }
}