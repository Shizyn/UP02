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
using System.Runtime.InteropServices;
using System.Security;

namespace UP02.Pages.Regist
{
    
    public partial class Regist : Page
    {
        private readonly Frame _frame;
        public Regist(Frame _frame)
        {
            InitializeComponent();
            _frame = frame;
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;

            //// Проверка логина
            //if (string.IsNullOrEmpty(LoginTB.Text))
            //{
            //    MessageBox.Show("Логин не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //    LoginTB.Background = Brushes.Red;
            //    isValid = false;
            //}
            //else
            //{
            //    LoginTB.ToolTip = null;
            //    LoginTB.Background = Brushes.White;
            //}

            //// Проверка пароля
            //if (PassPB.SecurePassword.Length == 0)
            //{
            //    MessageBox.Show("Пароль не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //    PassPB.Background = Brushes.Red;
            //    isValid = false;
            //}
            //else if (PassPB.SecurePassword.Length < 6)
            //{
            //    MessageBox.Show("Пароль должен содержать минимум 6 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //    PassPB.Background = Brushes.Red;
            //    isValid = false;
            //}
            //else
            //{
            //    PassPB.ToolTip = null;
            //    PassPB.Background = Brushes.White;
            //}

            //// Проверка подтверждения пароля
            //if (ConfirmPassPB.SecurePassword.Length == 0)
            //{
            //    MessageBox.Show("Подтверждение пароля не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //    ConfirmPassPB.Background = Brushes.Red;
            //    isValid = false;
            //}
            //else if (ConvertToString(PassPB.SecurePassword) != ConvertToString(ConfirmPassPB.SecurePassword))
            //{
            //    MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //    ConfirmPassPB.Background = Brushes.Red;
            //    isValid = false;
            //}
            //else
            //{
            //    ConfirmPassPB.ToolTip = null;
            //    ConfirmPassPB.Background = Brushes.White;
            //}

            //// Проверка email
            //if (string.IsNullOrEmpty(EmailTB.Text))
            //{
            //    MessageBox.Show("Email не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //    EmailTB.Background = Brushes.Red;
            //    isValid = false;
            //}
            //else if (!IsValidEmail(EmailTB.Text))
            //{
            //    MessageBox.Show("Неверный формат email!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //    EmailTB.Background = Brushes.Red;
            //    isValid = false;
            //}
            //else
            //{
            //    EmailTB.ToolTip = null;
            //    EmailTB.Background = Brushes.White;
            //}

            //// Проверка ФИО
            //if (string.IsNullOrEmpty(FioTB.Text))
            //{
            //    MessageBox.Show("ФИО не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //    FioTB.Background = Brushes.Red;
            //    isValid = false;
            //}
            //else
            //{
            //    FioTB.ToolTip = null;
            //    FioTB.Background = Brushes.White;
            //}

            //// Проверка телефона
            //if (string.IsNullOrEmpty(PhoneTB.Text))
            //{
            //    MessageBox.Show("Телефон не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //    PhoneTB.Background = Brushes.Red;
            //    isValid = false;
            //}
            //else if (!System.Text.RegularExpressions.Regex.IsMatch(PhoneTB.Text, @"^\+?\d{10,15}$"))
            //{
            //    MessageBox.Show("Неверный формат телефона!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //    PhoneTB.Background = Brushes.Red;
            //    isValid = false;
            //}
            //else
            //{
            //    PhoneTB.ToolTip = null;
            //    PhoneTB.Background = Brushes.White;
            //}

            //// Проверка адреса
            //if (string.IsNullOrEmpty(AddressTB.Text))
            //{
            //    MessageBox.Show("Адрес не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //    AddressTB.Background = Brushes.Red;
            //    isValid = false;
            //}
            //else
            //{
            //    AddressTB.ToolTip = null;
            //    AddressTB.Background = Brushes.White;
            //}

            // Если хотя бы одно поле невалидно
            //if (!isValid)
            //{
            //    MessageBox.Show("Пожалуйста, исправьте ошибки в форме!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}

            // Если все проверки пройдены

            if (isValid)
            {
                MessageBox.Show("Регистрация успешно завершена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                if (_frame != null)
                {
                    _frame.Navigate(new Pages.Main.Main());
                }
            }
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
        private string ConvertToString(SecureString securePassword)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
