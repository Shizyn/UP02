using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace UP02.Classes
{ 
    public class Inventorychecks
    {
        public int Id { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        public string Name { get; set; }
        public int User_id { get; set; }
        public Inventorychecks(int Id, DateTime Start_date, DateTime End_date, string Name, int User_id) 
        {
            this.Id = Id;
            this.Start_date = Start_date;
            this.End_date = End_date;
            this.Name = Name;
            this.User_id = User_id;
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
        public static List<Inventorychecks> Select()
        {
            List<Inventorychecks> AllInventoryChecks = new List<Inventorychecks>();
            string SQL = "SELECT * FROM `inventory_checks`;";
            MySqlConnection connection = OpenConnection();
            MySqlDataReader Data = Query(SQL, connection);
            while (Data.Read())
            {
                AllInventoryChecks.Add(new Inventorychecks(
                    Data.GetInt32(0),
                    Data.GetDateTime(1),
                    Data.GetDateTime(2),
                    Data.GetString(3),
                    Data.GetInt32(4)
                    ));
            }
            CloseConnection(connection);
            return AllInventoryChecks;
        }
        public void Add()
        {
            string SQL = $"INSERT INTO `inventory_checks`(`start_date`, `end_date`, `name`, `user_id`) " +
                         $"VALUES ('{Start_date.ToString("yyyy-MM-dd HH:mm:ss")}','{End_date.ToString("yyyy-MM-dd HH:mm:ss")}','{Name}','{User_id}')";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }
        public void Update()
        {
            string SQL = $"UPDATE `inventory_checks` SET `start_date`='{Start_date.ToString("yyyy-MM-dd HH:mm:ss")}',`end_date`='{End_date.ToString("yyyy-MM-dd HH:mm:ss")}',`name`='{Name}',`user_id`='{User_id} WHERE `id`='{this.Id}'";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }

        public void Delete()
        {
            string SQL = $"DELETE FROM `inventory_checks` WHERE `id` = {Id}";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }
    }
}
