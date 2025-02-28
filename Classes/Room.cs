using MySqlConnector;
using System.Collections.Generic;

namespace UP02.Classes
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Short_name { get; set; }
        public int Responsible_user_id { get; set; }
        public Room(int Id, string Name, string Short_name, int Responsible_user_id)
        {
            this.Id = Id;
            this.Name = Name;
            this.Short_name = Short_name;
            this.Responsible_user_id = Responsible_user_id;
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
        public static List<Room> Select()
        {
            List<Room> AllRoom = new List<Room>();
            string SQL = "SELECT * FROM `rooms`;";
            MySqlConnection connection = OpenConnection();
            MySqlDataReader Data = Query(SQL, connection);
            while (Data.Read())
            {
                AllRoom.Add(new Room(
                    Data.GetInt32(0),
                    Data.GetString(1),
                    Data.GetString(2),
                    Data.GetInt32(3)
                    ));
            }
            CloseConnection(connection);
            return AllRoom;
        }
        public void Add()
        {
            string SQL = $"INSERT INTO `rooms`(`name`, `short_name`, `responsible_user_id`) " +
                         $"VALUES ('{this.Name}','{this.Short_name}','{this.Responsible_user_id}')";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }
        public void Update()
        {
            string SQL = $"UPDATE `rooms` SET `name`='{this.Name}',`short_name`='{this.Short_name}',`responsible_user_id`='{this.Responsible_user_id}' WHERE `id`='{this.Id}'";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }

        public void Delete()
        {
            string SQL = $"DELETE FROM `rooms` WHERE `id` = {this.Id}";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }
    }
}