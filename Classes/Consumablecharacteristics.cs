using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace UP02.Classes
{
    class Consumablecharacteristics
    {
        public int Id { get; set; }
        public int Consumable_id { get; set; }
        public string Characteristic_name { get; set; }
        public string Characteristic_value { get; set; }
        public Consumablecharacteristics(int Id, int Consumable_id, string Characteristic_name, string Characteristic_value) 
        {
            this.Id = Id;
            this.Consumable_id = Consumable_id;
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
        public static List<Inventorychecks> Select()
        {
            List<Inventorychecks> AllInventoryChecks = new List<Inventorychecks>();
            string SQL = "SELECT * FROM `consumable_characteristics`;";
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
    }
}
