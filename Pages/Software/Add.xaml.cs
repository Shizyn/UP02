using System.Windows;
using System.Windows.Controls;

namespace UP02.Pages.Software
{
    public partial class Add : Page
    {
        Classes.Software software;
        public readonly Frame _frame;
        public Add(Frame frame, Classes.Software software)
        {
            InitializeComponent();
            _frame = frame;
            if (software != null)
            {
                this.software = software;
                namePB.Text = software.Name;
                developerTB.Text = software.Developer;
                versionTB.Text = software.Version;
                BthAdd.Content = $"Изменить";
            }
        }

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Pages.Main.Main(_frame));
        }

        private void AddSoftwaresBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.software == null)
            {
                Classes.Software newSoftware = new Classes.Software(
                    0,
                    namePB.Text,
                    developerTB.Text,
                    versionTB.Text
                    );
                newSoftware.Add();
                MessageBox.Show($"Программна добавлена");
            }
            if (this.software != null)
            {
                Classes.Software newSoftware = new Classes.Software(
                    software.Id,
                    namePB.Text,
                    developerTB.Text,
                    versionTB.Text
                    );
                newSoftware.Update();
                MessageBox.Show($"Программа изменёна");
            }
            _frame.Navigate(new Main(_frame));
        }
    }
}
