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
using System.Net.Mail;

namespace UP02.Pages.Regist
{
    
    public partial class Regist : Page
    {
        public Regist(Frame _frame)
        {
            InitializeComponent();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;

            // Проверка логина
            if (string.IsNullOrEmpty(LoginTB.Text))
            {
                LoginTB.ToolTip = "Логин не может быть пустым!";
                LoginTB.Background = Brushes.LightPink;
                isValid = false;
            }
            else
            {
                LoginTB.ToolTip = null;
                LoginTB.Background = Brushes.White;
            }

            // Проверка пароля
            if (PassPB.SecurePassword.Length == 0)
            {
                PassPB.ToolTip = "Пароль не может быть пустым!";
                PassPB.Background = Brushes.LightPink;
                isValid = false;
            }
            else if (PassPB.SecurePassword.Length < 6)
            {
                PassPB.ToolTip = "Пароль должен содержать минимум 6 символов!";
                PassPB.Background = Brushes.LightPink;
                isValid = false;
            }
            else
            {
                PassPB.ToolTip = null;
                PassPB.Background = Brushes.White;
            }

            // Проверка подтверждения пароля
            if (ConfirmPassPB.SecurePassword.Length == 0)
            {
                ConfirmPassPB.ToolTip = "Подтверждение пароля не может быть пустым!";
                ConfirmPassPB.Background = Brushes.LightPink;
                isValid = false;
            }
            else if (!PassPB.SecurePassword.Equals(ConfirmPassPB.SecurePassword))
            {
                ConfirmPassPB.ToolTip = "Пароли не совпадают!";
                ConfirmPassPB.Background = Brushes.LightPink;
                isValid = false;
            }
            else
            {
                ConfirmPassPB.ToolTip = null;
                ConfirmPassPB.Background = Brushes.White;
            }

            // Проверка email
            if (string.IsNullOrEmpty(EmailTB.Text))
            {
                EmailTB.ToolTip = "Email не может быть пустым!";
                EmailTB.Background = Brushes.LightPink;
                isValid = false;
            }
            else if (!IsValidEmail(EmailTB.Text))
            {
                EmailTB.ToolTip = "Неверный формат email!";
                EmailTB.Background = Brushes.LightPink;
                isValid = false;
            }
            else
            {
                EmailTB.ToolTip = null;
                EmailTB.Background = Brushes.White;
            }

            // Проверка ФИО
            if (string.IsNullOrEmpty(FioTB.Text))
            {
                FioTB.ToolTip = "ФИО не может быть пустым!";
                FioTB.Background = Brushes.LightPink;
                isValid = false;
            }
            else
            {
                FioTB.ToolTip = null;
                FioTB.Background = Brushes.White;
            }

            // Проверка телефона
            if (string.IsNullOrEmpty(PhoneTB.Text))
            {
                PhoneTB.ToolTip = "Телефон не может быть пустым!";
                PhoneTB.Background = Brushes.LightPink;
                isValid = false;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(PhoneTB.Text, @"^\+?\d{10,15}$"))
            {
                PhoneTB.ToolTip = "Неверный формат телефона!";
                PhoneTB.Background = Brushes.LightPink;
                isValid = false;
            }
            else
            {
                PhoneTB.ToolTip = null;
                PhoneTB.Background = Brushes.White;
            }

            // Проверка адреса
            if (string.IsNullOrEmpty(AddressTB.Text))
            {
                AddressTB.ToolTip = "Адрес не может быть пустым!";
                AddressTB.Background = Brushes.LightPink;
                isValid = false;
            }
            else
            {
                AddressTB.ToolTip = null;
                AddressTB.Background = Brushes.White;
            }

            // Если хотя бы одно поле невалидно
            if (!isValid)
            {
                MessageBox.Show("Пожалуйста, исправьте ошибки в форме!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Если все проверки пройдены
            MessageBox.Show("Регистрация успешно завершена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Метод проверки email
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
