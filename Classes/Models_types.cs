using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace UP02.Classes
{
    public class Models_types
    {
        public int id { get; set; }
        public string name { get; set; }
        public Models_types(int id, string name)
        {
            this.id = id;
            this.name = name;
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
        public static List<Models_types> Select()
        {
            List<Models_types> AllModels_Types = new List<Models_types>();
            string SQL = "SELECT * FROM `models_types`;";
            MySqlConnection connection = OpenConnection();
            MySqlDataReader Data = Query(SQL, connection);
            while (Data.Read())
            {
                AllModels_Types.Add(new Models_types(
                    Data.GetInt32(0),
                    Data.GetString(1)
                    ));
            }
            CloseConnection(connection);
            return AllModels_Types;
        }
    }
}
