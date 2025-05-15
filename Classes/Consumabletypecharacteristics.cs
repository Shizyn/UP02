using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace UP02.Classes
{
    public class Consumabletypecharacteristics
    {
        public int id { get; set; }
        public int consumable_type_id { get; set; }
        public int characteristic_id { get; set; }
        public string is_required { get; set; }
        public string default_value { get; set; }
        public Consumabletypecharacteristics(int id, int consumable_type_id, int characteristic_id, string is_required, string default_value)
        {
            this.id = id;
            this.consumable_type_id = consumable_type_id;
            this.characteristic_id = characteristic_id;
            this.is_required = is_required;
            this.default_value = default_value;
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
        public static List<Consumabletypecharacteristics> Select()
        {
            List<Consumabletypecharacteristics> AllConsumabletypecharacteristics = new List<Consumabletypecharacteristics>();
            string SQL = "SELECT * FROM `consumable_type_characteristics`;";
            MySqlConnection connection = OpenConnection();
            MySqlDataReader Data = Query(SQL, connection);
            while (Data.Read())
            {
                AllConsumabletypecharacteristics.Add(new Consumabletypecharacteristics(
                    Data.GetInt32(0),
                    Data.GetInt32(1),
                    Data.GetInt32(2),
                    Data.GetString(3),
                    Data.GetString(4)
                    ));
            }
            CloseConnection(connection);
            return AllConsumabletypecharacteristics;
        }
        public void Add()
        {
            string SQL = $"INSERT INTO `consumable_type_characteristics`(`consumable_type_id`, `characteristic_id`, `is_required`, `default_value`) " +
                         $"VALUES ('{consumable_type_id}','{characteristic_id}','{is_required}','{default_value}')";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }
        public void Update()
        {
            string SQL = $"UPDATE `consumable_type_characteristics` SET `consumable_type_id`='{consumable_type_id}',`characteristic_id`='{characteristic_id}',`is_required`='{is_required}',`default_value`='{default_value}' WHERE `id`='{this.id}'";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }

        public void Delete()
        {
            string SQL = $"DELETE FROM `consumable_type_characteristics` WHERE `id` = {id}";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }
    }
}
