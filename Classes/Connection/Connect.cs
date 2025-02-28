using MySqlConnector;

namespace UP02.Classes.Connection
{
    public class Connect
    {
        public static string server = "127.0.0.1";
        public static string login = "root";
        public static string password = "";
        public static string DataBase = "up02";
        public static string Port = "3306";
        public static string con = $"server={server};uid={login};pwd={password};database={DataBase};port={Port};";
        public static MySqlDataReader Connection(string query)
        {
            MySqlConnection connection = new MySqlConnection(con);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            return cmd.ExecuteReader();
        }
    }
}
//public static DataTable Connection(string SQL)
//{
//    DataTable dataTable = new DataTable("Datatable");
//    SqlConnection sqlConnection = new SqlConnection("server = ; Trusted_Connection = No; DataBase = ; User = ; PWD = ;");
//    sqlConnection.Open();
//    SqlCommand sqlCommand = sqlConnection.CreateCommand();
//    sqlCommand.CommandText = SQL;
//    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
//    sqlDataAdapter.Fill(dataTable);
//    return dataTable;
//}