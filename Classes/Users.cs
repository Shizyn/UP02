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
        public static IEnumerable<Users> AllUsers()
        {
            List<Users> allUsers = new List<Users>();
            //DataTable requestUsers = DBConnection.Connection("SELECT * FROM Users");
           
            
            //foreach (DataRow users in requestUsers.Rows)
            //    allUsers.Add(new Users()
            //    {
            //        Id = Convert.ToInt32(users[0]),
            //        Login = users[1].ToString(),
            //        Password = users[2].ToString(),
            //    });
            return allUsers;
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