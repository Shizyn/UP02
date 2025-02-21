using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UP02.Classes;

namespace UP02.Pages.Regist
{
    /// <summary>
    /// Логика взаимодействия для Regist.xaml
    /// </summary>
    public partial class Regist : Page
    {
        public Regist(Frame _frame)
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;

            // Проверка логина
            if (string.IsNullOrEmpty(LoginTextBox.Text))
            {
                LoginTextBox.ToolTip = "Логин не может быть пустым!";
                LoginTextBox.Background = Brushes.LightPink;
                isValid = false;
            }
            else
            {
                LoginTextBox.ToolTip = null;
                LoginTextBox.Background = Brushes.White;
            }

            // Проверка пароля
            if (PasswordBox.SecurePassword.Length == 0)
            {
                PasswordBox.ToolTip = "Пароль не может быть пустым!";
                PasswordBox.Background = Brushes.LightPink;
                isValid = false;
            }
            else if (PasswordBox.SecurePassword.Length < 6)
            {
                PasswordBox.ToolTip = "Пароль должен содержать минимум 6 символов!";
                PasswordBox.Background = Brushes.LightPink;
                isValid = false;
            }
            else
            {
                PasswordBox.ToolTip = null;
                PasswordBox.Background = Brushes.White;
            }

            // Проверка подтверждения пароля
            if (ConfirmPasswordBox.SecurePassword.Length == 0)
            {
                ConfirmPasswordBox.ToolTip = "Подтверждение пароля не может быть пустым!";
                ConfirmPasswordBox.Background = Brushes.LightPink;
                isValid = false;
            }
            else if (!PasswordBox.SecurePassword.Equals(ConfirmPasswordBox.SecurePassword))
            {
                ConfirmPasswordBox.ToolTip = "Пароли не совпадают!";
                ConfirmPasswordBox.Background = Brushes.LightPink;
                isValid = false;
            }
            else
            {
                ConfirmPasswordBox.ToolTip = null;
                ConfirmPasswordBox.Background = Brushes.White;
            }

            // Проверка email
            if (string.IsNullOrEmpty(EmailTextBox.Text))
            {
                EmailTextBox.ToolTip = "Email не может быть пустым!";
                EmailTextBox.Background = Brushes.LightPink;
                isValid = false;
            }
            else
            {
                EmailTextBox.ToolTip = null;
                EmailTextBox.Background = Brushes.White;
            }

            // Проверка ФИО
            if (string.IsNullOrEmpty(FioTextBox.Text))
            {
                FioTextBox.ToolTip = "ФИО не может быть пустым!";
                FioTextBox.Background = Brushes.LightPink;
                isValid = false;
            }
            else
            {
                FioTextBox.ToolTip = null;
                FioTextBox.Background = Brushes.White;
            }

            // Проверка телефона
            if (string.IsNullOrEmpty(PhoneTextBox.Text))
            {
                PhoneTextBox.ToolTip = "Телефон не может быть пустым!";
                PhoneTextBox.Background = Brushes.LightPink;
                isValid = false;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(PhoneTextBox.Text, @"^\+?\d{10,15}$"))
            {
                PhoneTextBox.ToolTip = "Неверный формат телефона!";
                PhoneTextBox.Background = Brushes.LightPink;
                isValid = false;
            }
            else
            {
                PhoneTextBox.ToolTip = null;
                PhoneTextBox.Background = Brushes.White;
            }

            // Проверка адреса
            if (string.IsNullOrEmpty(AddressTextBox.Text))
            {
                AddressTextBox.ToolTip = "Адрес не может быть пустым!";
                AddressTextBox.Background = Brushes.LightPink;
                isValid = false;
            }
            else
            {
                AddressTextBox.ToolTip = null;
                AddressTextBox.Background = Brushes.White;
            }

            // Если хотя бы одно поле невалидно
            if (!isValid)
            {
                MessageBox.Show("Пожалуйста, исправьте ошибки в форме!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Если все проверки пройдены
            MessageBox.Show("Регистрация успешно завершена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            // Здесь можно добавить логику сохранения данных
        }

        private void ConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
