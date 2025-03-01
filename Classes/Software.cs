using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace UP02.Classes
{
    public class Software
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public string Version { get; set; }
        public Software(int Id, string Name, string Developer, string Version)
        {
            this.Id = Id;
            this.Name = Name;
            this.Developer = Developer;
            this.Version = Version;
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
        public static List<Software> Select()
        {
            List<Software> AllSoftware = new List<Software>();
            string SQL = "SELECT * FROM `software`;";
            MySqlConnection connection = OpenConnection();
            MySqlDataReader Data = Query(SQL, connection);
            while (Data.Read())
            {
                AllSoftware.Add(new Software(
                    Data.GetInt32(0),
                    Data.GetString(1),
                    Data.GetString(2),
                    Data.GetString(3)
                    ));
            }
            CloseConnection(connection);
            return AllSoftware;
        }
        public void Add()
        {
            string SQL = $"INSERT INTO `software`(`name`, `developer`, `version`) " +
                         $"VALUES ('{Name}','{Developer}','{Version}')";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }
        public void Update()
        {
            string SQL = $"UPDATE `software` SET `name`='{Name}',`developer`='{Developer}',`version`='{Version}' WHERE `id`='{Id}'";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }

        public void Delete()
        {
            string SQL = $"DELETE FROM `software` WHERE `id` = {Id}";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }
    }
}
