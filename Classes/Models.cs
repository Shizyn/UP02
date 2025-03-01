using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace UP02.Classes
{
    public class Models
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type_id { get; set; }
        public Models(int Id, string Name, int Type_id)
        {
            this.Id = Id;
            this.Name = Name;
            this.Type_id = Type_id;
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
        public static List<Models> Select()
        {
            List<Models> AllModels = new List<Models>();
            string SQL = "SELECT * FROM `models`;";
            MySqlConnection connection = OpenConnection();
            MySqlDataReader Data = Query(SQL, connection);
            while (Data.Read())
            {
                AllModels.Add(new Models(
                    Data.GetInt32(0),
                    Data.GetString(1),
                    Data.GetInt32(2)
                    ));
            }
            CloseConnection(connection);
            return AllModels;
        }
        public void Add()
        {
            string SQL = $"INSERT INTO `models`(`name`, `type_id`) " +
                         $"VALUES ('{Name}','{Type_id}')";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }
        public void Update()
        {
            string SQL = $"UPDATE `models` SET `name`='{Name}',`type_id`='{Type_id}'";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }

        public void Delete()
        {
            string SQL = $"DELETE FROM `models` WHERE `id` = {Id}";
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
