using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace UP02.Classes
{
    public class Equipment
    {
        public int id { get; set; }
        public string name { get; set; }
        public byte[] photo { get; set; }
        public int inventory_number { get; set; }
        public int room_id { get; set; }
        public int model_id { get; set; }
        public int user_id { get; set; }
        public int responsible_user_id { get; set; }
        public string direction_id { get; set; }
        public string status_id { get; set; }
        public string cost { get; set; }
        public string comment { get; set; }
        public int software_id { get; set; }
        public Equipment(int id, string name, byte[] photo, int inventory_number, int room_id, int model_id, int user_id, 
            int responsible_user_id, string direction_id, string status_id, string cost, string comment, int software_id)
        {
            this.id = id;
            this.name = name;
            this.photo = photo;
            this.inventory_number = inventory_number;
            this.room_id = room_id;
            this.model_id = model_id;
            this.user_id = user_id;
            this.responsible_user_id = responsible_user_id;
            this.direction_id = direction_id;
            this.status_id = status_id;
            this.cost = cost;
            this.comment = comment;
            this.software_id = software_id;
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
        public static List<Equipment> Select()
        {
            List<Equipment> AllEquipment = new List<Equipment>();
            string SQL = "SELECT * FROM `equipment`;";
            MySqlConnection connection = OpenConnection();
            MySqlDataReader Data = Query(SQL, connection);
            while (Data.Read())
            {
                AllEquipment.Add(new Equipment(
                    Data.GetInt32(0),
                    Data.GetString(1),
                    (byte[])Data.GetValue(2),
                    Data.GetInt32(3),
                    Data.GetInt32(4),
                    Data.GetInt32(5),
                    Data.GetInt32(6),
                    Data.GetInt32(7),
                    Data.GetString(8),
                    Data.GetString(9),
                    Data.GetString(10),
                    Data.GetString(11),
                    Data.GetInt32(12)
                    ));
            }
            CloseConnection(connection);
            return AllEquipment;
        }
        public void Add()
        {
            string SQL = $"INSERT INTO `equipment`(`name`, `photo`, `inventory_number`, `room_id`, `model_id`, `user_id`, `responsible_user_id`, `direction_id`, `status_id`, `cost`, `comment`, `software_id`) " +
                         $"VALUES (@name, @photo, @inventory_number, @room_id, @model_id, @user_id, @responsible_user_id, @direction_id, @status_id, @cost, @comment, @software_id)";

            using (MySqlConnection connection = OpenConnection())
            {
                using (MySqlCommand command = new MySqlCommand(SQL, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@photo", photo);
                    command.Parameters.AddWithValue("@inventory_number", inventory_number);
                    command.Parameters.AddWithValue("@room_id", room_id);
                    command.Parameters.AddWithValue("@model_id", model_id);
                    command.Parameters.AddWithValue("@user_id", user_id);
                    command.Parameters.AddWithValue("@responsible_user_id", responsible_user_id);
                    command.Parameters.AddWithValue("@direction_id", direction_id);
                    command.Parameters.AddWithValue("@status_id", status_id);
                    command.Parameters.AddWithValue("@cost", cost);
                    command.Parameters.AddWithValue("@comment", comment);
                    command.Parameters.AddWithValue("@software_id", software_id);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void Update()
        {
            string SQL = $"UPDATE `equipment` SET " +
                         $"`name` = @name, " +
                         $"`photo` = @photo, " +
                         $"`inventory_number` = @inventory_number, " +
                         $"`room_id` = @room_id, " +
                         $"`model_id` = @model_id, " +
                         $"`user_id` = @user_id, " +
                         $"`responsible_user_id` = @responsible_user_id, " +
                         $"`direction_id` = @direction_id, " +
                         $"`status_id` = @status_id, " +
                         $"`cost` = @cost, " +
                         $"`comment` = @comment, " +
                         $"`software_id` = @software_id " +
                         $"WHERE `id` = @id";

            using (MySqlConnection connection = OpenConnection())
            {
                using (MySqlCommand command = new MySqlCommand(SQL, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@photo", photo);
                    command.Parameters.AddWithValue("@inventory_number", inventory_number);
                    command.Parameters.AddWithValue("@room_id", room_id);
                    command.Parameters.AddWithValue("@model_id", model_id);
                    command.Parameters.AddWithValue("@user_id", user_id);
                    command.Parameters.AddWithValue("@responsible_user_id", responsible_user_id);
                    command.Parameters.AddWithValue("@direction_id", direction_id);
                    command.Parameters.AddWithValue("@status_id", status_id);
                    command.Parameters.AddWithValue("@cost", cost);
                    command.Parameters.AddWithValue("@comment", comment);
                    command.Parameters.AddWithValue("@software_id", software_id);
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete()
        {
            string SQL = $"DELETE FROM `equipment` WHERE `id` = {id}";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }
    }
}