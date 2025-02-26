using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using UP02.Classes.Connection;

namespace UP02.Classes.CSV
{
    public class Excel_CSV
    {

        public void ImportCsvData_equipment()
        {
            string csvFilePath = "C:/Users/student-a202/Desktop/6aaa.csv";
            using (MySqlConnection connection = new MySqlConnection(Connect.con))
            {

                connection.Open();
                foreach (var line in File.ReadLines(csvFilePath))
                {

                    var values = line.Split(';');
                    string name = values.Length > 0 ? values[0] : string.Empty;

                    string photo = values.Length > 1 ? values[1] : string.Empty;

                    string inventory_number = values.Length > 2 ? values[2] : string.Empty;

                    string room_id = values.Length > 3 ? values[3] : string.Empty;

                    room_id = room_Chek(room_id);

                    string model_id = values.Length > 4 ? values[4] : string.Empty;

                    model_id = model_Chek(model_id);
                    string user_id = values.Length > 5 ? values[5] : string.Empty;

                    user_id = user_Chek(user_id);
                    string direction_id = values.Length > 6 ? values[6] : string.Empty;

                    direction_id = direction_Chek(direction_id);
                    string status_id = values.Length > 7 ? values[7] : string.Empty;

                    //status_id= status_Chek(status_id);
                    string cost = values.Length > 8 ? values[8] : string.Empty;

                    string comment = values.Length > 9 ? values[9] : string.Empty;

                    string software_id = values.Length > 10 ? values[10] : string.Empty;

                    software_id = soft_Chek(software_id);



                    string query = $"INSERT INTO {Connect.DataBase}.equipment (name, photo, inventory_number, room_id, model_id, user_id, direction_id, cost, comment, software_id)" +
                        $" VALUES ('{name}', '{photo}', '{inventory_number}', '{room_id}', '{model_id}', '{user_id}', '{direction_id}', '{cost}', '{comment}', '{software_id}')";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }


        }
        public string room_Chek(string room)
        {
            MySqlDataReader query = Connect.Connection($"select name, id from {Connect.DataBase}.rooms");
            string id = null;
            while (query.Read())
            {
                if (query.GetString(0) == room)
                {
                    id = $"{query.GetInt32(1)}";
                }
            }
            if (id == null)
            {
                string query_2 = $"INSERT INTO {Connect.DataBase}.rooms (name) VALUES ('{room}')";
                Connect.Connection(query_2);
                id = room_Chek(room);
            }

            return id;
        }
        public string model_Chek(string model)
        {
            MySqlDataReader query = Connect.Connection($"select name, id from {Connect.DataBase}.models");
            string id = null;
            while (query.Read())
            {
                if (query.GetString(0) == model)
                {
                    id = $"{query.GetInt32(1)}";
                }
            }
            if (id == null)
            {
                string query_2 = $"INSERT INTO {Connect.DataBase}.models (name) VALUES ('{model}')";
                Connect.Connection(query_2);
                id = model_Chek(model);
            }
            return id;
        }
        public string user_Chek(string user)
        {
            MySqlDataReader query = Connect.Connection($"select login, id from {Connect.DataBase}.users");
            string id = null;
            while (query.Read())
            {
                if (query.GetString(0) == user)
                {
                    id = $"{query.GetInt32(1)}";
                }
            }
            if (id == null)
            {
                string query_2 = $"INSERT INTO {Connect.DataBase}.users (login) VALUES ('{user}')";
                Connect.Connection(query_2);
                id = user_Chek(user);
            }
            return id;
        }
        public string direction_Chek(string direction)
        {
            MySqlDataReader query = Connect.Connection($"select name_directions_id, id from {Connect.DataBase}.tableid");
            string id = null;
            while (query.Read())
            {
                if (query.GetString(0) == direction)
                {
                    id = $"{query.GetInt32(1)}";
                }
            }
            if (id == null)
            {
                string query_2 = $"INSERT INTO {Connect.DataBase}.tableid (name_directions_id) VALUES ('{direction}')";
                Connect.Connection(query_2);
                id = direction_Chek(direction);
            }
            return id;
        }
        public string status_Chek(string status)
        {
            MySqlDataReader query = Connect.Connection($"select name_statuses_id, id from {Connect.DataBase}.tableid");
            string id = null;
            while (query.Read())
            {
                if (query.GetString(0) == status)
                {
                    id = $"{query.GetInt32(1)}";
                }
            }
            if (id == null)
            {
                string query_2 = $"INSERT INTO {Connect.DataBase}.tableid (status) VALUES ('{status}')";
                Connect.Connection(query_2);
                id = room_Chek(status);
            }
            return id;
        }
        public string soft_Chek(string soft)
        {
            MySqlDataReader query = Connect.Connection($"select name, id from {Connect.DataBase}.software");
            string id = null;
            while (query.Read())
            {
                if (query.GetString(0) == soft)
                {
                    id = $"{query.GetInt32(1)}";
                }
            }
            if (id == null)
            {
                string query_2 = $"INSERT INTO {Connect.DataBase}.software (name) VALUES ('{soft}')";
                Connect.Connection(query_2);
                id = room_Chek(soft);
            }
            return id;
        }
    }
}