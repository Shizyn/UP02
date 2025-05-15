using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace UP02.Classes
{
    public class Consumable_characteristic
    {
        public int Id { get; set; }
        public string Characteristic_name { get; set; }
        public string Characteristic_value { get; set; }
        public Consumable_characteristic(int Id, string Characteristic_name, string Characteristic_value) 
        {
            this.Id = Id;
            this.Characteristic_name = Characteristic_name;
            this.Characteristic_value = Characteristic_value;
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
        public static List<Consumable_characteristic> Select()
        {
            List<Consumable_characteristic> AllConsumablecharacteristics = new List<Consumable_characteristic>();
            string SQL = "SELECT * FROM `consumable_characteristics`;";
            MySqlConnection connection = OpenConnection();
            MySqlDataReader Data = Query(SQL, connection);
            while (Data.Read())
            {
                AllConsumablecharacteristics.Add(new Consumable_characteristic(
                    Data.GetInt32(0),
                    Data.GetString(1),
                    Data.GetString(2)
                    ));
            }
            CloseConnection(connection);
            return AllConsumablecharacteristics;
        }
        public void Add()
        {
            string SQL = $"INSERT INTO `consumable_characteristics`(`characteristic_name`, `characteristic_value`) " +
                         $"VALUES ('{Characteristic_name}','{Characteristic_value}')";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }
        public void Update()
        {
            string SQL = $"UPDATE `consumable_characteristics` SET `characteristic_name`='{Characteristic_name}',`characteristic_value`='{Characteristic_value}' WHERE `id`='{this.Id}'";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }

        public void Delete()
        {
            string SQL = $"DELETE FROM `consumable_characteristics` WHERE `id` = {this.Id}";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }
    }
}
