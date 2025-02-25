using System;
using System.Windows;
using System.Windows.Controls;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Media;
using UP02.Pages.Authoriz;

namespace UP02.Pages.Regist
{

    public partial class Regist : Page
    {
        public readonly Frame _frame;
        public Regist(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            string er="";

            bool isValid = true;

            // Проверка логина
            if (string.IsNullOrEmpty(LoginTB.Text))
            {er += "Логин не может быть пустым!\n";
                //MessageBox.Show("Логин не может быть пустым!\n", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                LoginTB.Background = Brushes.Red;
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
                er += "Пароль не может быть пустым!\n";
              //  MessageBox.Show("Пароль не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                PassPB.Background = Brushes.Red;
                isValid = false;
            }
            else if (PassPB.SecurePassword.Length < 6)
            {
                er += "Пароль должен содержать минимум 6 символов!\n";
               // MessageBox.Show("Пароль должен содержать минимум 6 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                PassPB.Background = Brushes.Red;
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
                er += "Подтверждение пароля не может быть пустым!\n";
                // MessageBox.Show("Подтверждение пароля не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                ConfirmPassPB.Background = Brushes.Red;
                isValid = false;
            }
            else if (ConvertToString(PassPB.SecurePassword) != ConvertToString(ConfirmPassPB.SecurePassword))
            {er += "Пароли не совпадают!\n";
                //MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                ConfirmPassPB.Background = Brushes.Red;
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
                er += "Email не может быть пустым!\n";
                //MessageBox.Show("Email не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                EmailTB.Background = Brushes.Red;
                isValid = false;
            }
            else if (!IsValidEmail(EmailTB.Text))
            {er += "Неверный формат email!\n";    
               // MessageBox.Show("Неверный формат email!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                EmailTB.Background = Brushes.Red;
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
                er += "ФИО не может быть пустым!\n";
                //MessageBox.Show("ФИО не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                FioTB.Background = Brushes.Red;
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
                er += "Телефон не может быть пустым!\n";
               // MessageBox.Show("Телефон не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                PhoneTB.Background = Brushes.Red;
                isValid = false;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(PhoneTB.Text, @"^\+?\d{10,15}$"))
            {
                er += "Неверный формат телефона!\n";
                //MessageBox.Show("Неверный формат телефона!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                PhoneTB.Background = Brushes.Red;
                isValid = false;
            }
            else
            {
                PhoneTB.ToolTip = null;
                PhoneTB.Background = Brushes.White;
            }

            // Проверка адреса
            if (string.IsNullOrEmpty(AddressTB.Text))
            {er += "Адрес не может быть пустым!\n";
               // MessageBox.Show("Адрес не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                AddressTB.Background = Brushes.Red;
                isValid = false;
            }
            else
            {
                AddressTB.ToolTip = null;
                AddressTB.Background = Brushes.White;
            }
            //Если хотя бы одно поле невалидно
            if (!isValid)
            {
                MessageBox.Show(er, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Если все проверки пройдены

            if (_frame != null)
            {
                MessageBox.Show("Вы успешно вошли!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                _frame.Navigate(new Pages.Main.Main());
            }
            else
            {
                MessageBox.Show("Что-то не так!", "не повезло", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void GetBackButton_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new Glav(_frame));
        }
    }
}
