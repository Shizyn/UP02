using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using static Org.BouncyCastle.Math.EC.ECCurve;

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
        public Users(int Id, string Login, string Password, string Role, string Email, string Fio, string Phone, string Address) 
        { 
            this.Id = Id;
            this.Login = Login;
            this.Password = Password;
            this.Role = Role;
            this.Email = Email;
            this.Fio = Fio;
            this.Phone = Phone;
            this.Address = Address;
        }
        public static void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
            MySqlConnection.ClearPool(connection);
        }
        public static MySqlDataReader Query(string SQL, MySqlConnection connection)
        {
            return new MySqlCommand(SQL, connection).ExecuteReader();
        }
        public static MySqlConnection OpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(Connection.Connect.con);
            connection.Open();

            return connection;
        }
        public static List<Users> Select()
        {
            List<Users> AllUsers = new List<Users>();
            string SQL = "SELECT * FROM `users`;";
            MySqlConnection connection = OpenConnection();
            MySqlDataReader Data = Query(SQL, connection);
            while (Data.Read())
            {
                AllUsers.Add(new Users(
                    Data.GetInt32(0),
                    Data.GetString(1),
                    Data.GetString(2),
                    Data.GetString(3),
                    Data.GetString(4),
                    Data.GetString(5),
                    Data.GetString(6),
                    Data.GetString(7)
                    ));
            }
            CloseConnection(connection);
            return AllUsers;
        }
        public void Add()
        {
            string SQL = $"INSERT INTO `users`(`login`, `password`, `role`, `email`, `fio`, `phone`, `address`) " +
                         $"VALUES ('{this.Login}','{this.Password}','{this.Role}','{this.Email}','{this.Fio}','{this.Phone}','{this.Address}')";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }
        public void Update()
        {
            string SQL = $"UPDATE `users` SET `login`='{this.Login}',`password`='{this.Password}',`role`='{this.Role}',`email`='{this.Email}'," +
                         $"`fio`='{this.Fio}',`phone`='{this.Phone}',`address`='{this.Address}' WHERE `id`='{this.Id}'";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }

        public void Delete()
        {
            string SQL = $"DELETE FROM `users` WHERE `id` = {this.Id}";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
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