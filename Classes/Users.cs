using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace UP02.Classes
{
    public class Users
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Fio { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public Users(string login, string password)
        {
            List<Users> allUsers = new List<Users>();
            DataTable requestStates = DBConnection.Connection("SELECT * FROM [dbo].[Users]");
            Login = login;
            Password = password;
            
            foreach (DataRow state in requestStates.Rows)
                allUsers.Add(new Users(login, password)
                {
                    Id = Convert.ToInt32(state[0]),
                    Login = state[1].ToString(),
                    Password = state[2].ToString(),
                });
            return;
        }
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