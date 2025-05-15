using System;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;


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
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=yp02;password="))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM users WHERE login = @login AND password = @password";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string role = reader["role"].ToString();
                            MessageBox.Show($"Добро пожаловать, {reader["fio"]}!");

                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();

                            Window parentWindow = Window.GetWindow(this);
                            parentWindow?.Close();
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка подключения: " + ex.Message);
                }
            }
        }

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Glav(_frame));
        }
    }
}
