using System.Windows;
using System.Windows.Controls;

namespace UP02.Pages.Software
{
    public partial class Software : UserControl
    {
        Classes.Software softwares;
        public readonly Frame _frame;
        public Software(Frame frame, Classes.Software softwares)
        {
            InitializeComponent();
            _frame = frame;
            this.softwares = softwares;
            tbName.Text = softwares.Name;
            tbDeveloper.Text = softwares.Developer;
            tbVersion.Text = softwares.Version;
        }

        private void EditSoftware(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Software.Add(_frame, softwares));
        }

        private void DeleteSoftware(object sender, RoutedEventArgs e)
        {
            softwares.Delete();
            Classes.Software.Select();
            _frame.Navigate(new Pages.Software.Main(_frame));
        }
    }
}
