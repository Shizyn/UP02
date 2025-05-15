using MySqlConnector;

namespace UP02.Classes.Connection
{
    public class Connect
    {
        public static string server = "localhost";
        public static string login = "root";
        public static string password = "Asdfg123";
        public static string DataBase = "yp02";
        //public static string Port = "3306";
        public static string con = $"server={server};uid={login};pwd={password};database={DataBase};";
        //port={Port};
        public static MySqlDataReader Connection(string query)
        {
            MySqlConnection connection = new MySqlConnection(con);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            return cmd.ExecuteReader();
        }
    }
}