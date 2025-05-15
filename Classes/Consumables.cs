using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace UP02.Classes
{
    public class Consumables
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime arrival_date { get; set; }
        public byte[] image { get; set; }
        public int count { get; set; }
        public int user_id { get; set; }
        public int consumable_id { get; set; }
        public Consumables(int id, string name, string description, DateTime arrival_date, byte[] image, int count, int user_id, int consumable_id) 
        { 
            this.id = id;
            this.name = name;
            this.description = description;
            this.arrival_date = arrival_date;
            this.image = image;
            this.count = count;
            this.user_id = user_id;
            this.consumable_id = consumable_id;
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
        public static List<Consumables> Select()
        {
            List<Consumables> AllConsumables = new List<Consumables>();
            string SQL = "SELECT * FROM `consumables`;";
            MySqlConnection connection = OpenConnection();
            MySqlDataReader Data = Query(SQL, connection);
            while (Data.Read())
            {
                AllConsumables.Add(new Consumables(
                    Data.GetInt32(0),
                    Data.GetString(1),
                    Data.GetString(2),
                    Data.GetDateTime(3),
                    (byte[])Data.GetValue(4),
                    Data.GetInt32(5),
                    Data.GetInt32(6),
                    Data.GetInt32(7)
                    ));
            }
            CloseConnection(connection);
            return AllConsumables;
        }
        public void Add()
        {
            string SQL = $"INSERT INTO `consumables`(`name`, `description`, `arrival_date`, `image`, `count`, `user_id`, `consumable_id`) " +
                         $"VALUES (@name, @description, @arrival_date, @image, @count, @user_id, @consumable_id)";

            using (MySqlConnection connection = OpenConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(SQL, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@arrival_date", arrival_date.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@image", image ?? (object)DBNull.Value); // правильно передаём byte[]
                    cmd.Parameters.AddWithValue("@count", count);
                    cmd.Parameters.AddWithValue("@user_id", user_id);
                    cmd.Parameters.AddWithValue("@consumable_id", consumable_id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Update()
        {
            string SQL = $"UPDATE `consumables` SET " +
                         $"`name`=@name, `description`=@description, `arrival_date`=@arrival_date, `image`=@image, " +
                         $"`count`=@count, `user_id`=@user_id, `consumable_id`=@consumable_id WHERE `id`=@id";

            using (MySqlConnection connection = OpenConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(SQL, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@arrival_date", arrival_date.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@image", image ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@count", count);
                    cmd.Parameters.AddWithValue("@user_id", user_id);
                    cmd.Parameters.AddWithValue("@consumable_id", consumable_id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete()
        {
            string SQL = $"DELETE FROM `consumables` WHERE `id` = {id}";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }
    }
}
