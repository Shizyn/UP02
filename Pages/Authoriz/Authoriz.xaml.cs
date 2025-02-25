using System.Windows;
using System.Windows.Controls;


namespace UP02.Pages.Authoriz
{

    public partial class Authoriz : Page
    {

        public readonly Frame _frame;
        public Authoriz(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //LoginTextBox.Text = string.Empty;
            PasswordBox.Password = string.Empty;
            string login = LoginTextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();

            if (Classes.Users.Equals(login, password))
            {
                MessageBox.Show("Вы успешно вошли!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                if (_frame != null)
                {
                    _frame.Navigate(new Pages.Main.Main()); 
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
