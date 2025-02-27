using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.Compiler;
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
            MySqlDataReader query = Connect.Connection($"select name_directions_id, id from {Connect.DataBase}.directions");
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
                string query_2 = $"INSERT INTO {Connect.DataBase}.directions (name_directions_id) VALUES ('{direction}')";
                Connect.Connection(query_2);
                id = direction_Chek(direction);
            }
            return id;
        }
        public string status_Chek(string status)
        {
            MySqlDataReader query = Connect.Connection($"select name_statuses_id, id from {Connect.DataBase}.status");
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
                string query_2 = $"INSERT INTO {Connect.DataBase}.status (status) VALUES ('{status}')";
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
        public void ImportCsvData_Users()
        {
            string csvFilePath = "C:/Users/student-a202/Desktop/6aaa.csv";
            using (MySqlConnection connection = new MySqlConnection(Connect.con))
            {

                connection.Open();
                foreach (var line in File.ReadLines(csvFilePath))
                {

                    var values = line.Split(';');
                    string login = values.Length > 0 ? values[0] : string.Empty;

                    string passoword = values.Length > 1 ? values[1] : string.Empty;

                    string role = values.Length > 2 ? values[2] : string.Empty;

                    string email = values.Length > 3 ? values[3] : string.Empty;

                    string fio = values.Length > 4 ? values[4] : string.Empty;

                    string phone = values.Length > 5 ? values[5] : string.Empty;

                    string address = values.Length > 6 ? values[6] : string.Empty;




                    string query = $"INSERT INTO {Connect.DataBase}.Users (login, passoword, role, email, fio, phone, address)" +
                        $" VALUES ('{login}', '{passoword}', '{role}', '{email}', '{fio}', '{phone}', '{address}')";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }


        }
        public void ImportCsvData_Inventorychecks()
        {
            string csvFilePath = "C:/Users/student-a202/Desktop/6aaa.csv";
            using (MySqlConnection connection = new MySqlConnection(Connect.con))
            {

                connection.Open();
                foreach (var line in File.ReadLines(csvFilePath))
                {

                    var values = line.Split(';');
                    string start_date = values.Length > 0 ? values[0] : string.Empty;

                    string end_date = values.Length > 1 ? values[1] : string.Empty;

                    string name = values.Length > 2 ? values[2] : string.Empty;

                    string user_id = values.Length > 3 ? values[3] : string.Empty;
                    user_id = user_Chek(user_id);

                    string query = $"INSERT INTO {Connect.DataBase}.inventory_checks (start_date, end_date, name, user_id)" +
                        $" VALUES ('{start_date}', '{end_date}', '{name}', '{user_id}')";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }


        }
        public void ImportCsvData_Inventoryequipment()
        {
            string csvFilePath = "C:/Users/student-a202/Desktop/6aaa.csv";
            using (MySqlConnection connection = new MySqlConnection(Connect.con))
            {

                connection.Open();
                foreach (var line in File.ReadLines(csvFilePath))
                {

                    var values = line.Split(';');
                    string equipment_id = values.Length > 0 ? values[0] : string.Empty;
                    equipment_id = Inventorychecks_Chek(equipment_id);

                    string room = values.Length > 1 ? values[1] : string.Empty;
                    room = room_Chek(room);
                    string Inventorychecks = values.Length > 2 ? values[2] : string.Empty;
                    Inventorychecks= Inventorychecks_Chek(Inventorychecks);
                    string comment = values.Length > 3 ? values[3] : string.Empty;

                    string query = $"INSERT INTO {Connect.DataBase}.inventory_equipment (equipment_id, room, Inventorychecks, comment)" +
                        $" VALUES ('{equipment_id}', '{room}', '{Inventorychecks}', '{comment}')";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }

        }
        public string Inventorychecks_Chek(string Inventorychecks)
        {
            MySqlDataReader query = Connect.Connection($"select name, id from {Connect.DataBase}.inventory_checks");
            string id = null;
            while (query.Read())
            {
                if (query.GetString(0) == Inventorychecks)
                {
                    id = $"{query.GetInt32(1)}";
                }
            }
            if (id == null)
            {
                string query_2 = $"INSERT INTO {Connect.DataBase}.inventory_checks (name) VALUES ('{Inventorychecks}')";
                Connect.Connection(query_2);
                id = room_Chek(Inventorychecks);
            }
            return id;
        }
        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////    
        /// 
        /// </summary>
        public void ImportCsvData_Rooms()
        {
            string csvFilePath = "C:/Users/student-a202/Desktop/6aaa.csv";
            using (MySqlConnection connection = new MySqlConnection(Connect.con))
            {

                connection.Open();
                foreach (var line in File.ReadLines(csvFilePath))
                {

                    var values = line.Split(';');

                    string name = values.Length > 0 ? values[0] : string.Empty;
                    string short_name = values.Length > 1 ? values[1] : string.Empty;
                    string responsible_user_id = values.Length > 2 ? values[2] : string.Empty;
                    responsible_user_id = user_Chek(responsible_user_id);

                    string query = $"INSERT INTO {Connect.DataBase}.rooms (name, short_name, responsible_user_id)" +
                        $" VALUES ('{name}', '{short_name}', '{responsible_user_id}')";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }

        }
        public void ImportCsvData_models()
        {
            string csvFilePath = "C:/Users/student-a202/Desktop/6aaa.csv";
            using (MySqlConnection connection = new MySqlConnection(Connect.con))
            {

                connection.Open();
                foreach (var line in File.ReadLines(csvFilePath))
                {

                    var values = line.Split(';');

                    string name = values.Length > 0 ? values[0] : string.Empty;
                    string type_id = values.Length > 1 ? values[1] : string.Empty;
                    type_id = models_types_Chek(type_id);


                    string query = $"INSERT INTO {Connect.DataBase}.models (name, type_id)" +
                        $" VALUES ('{name}', '{type_id}')";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }

        }
        public string models_types_Chek(string models_types)
        {
            MySqlDataReader query = Connect.Connection($"select name, id from {Connect.DataBase}.models_types");
            string id = null;
            while (query.Read())
            {
                if (query.GetString(0) == models_types)
                {
                    id = $"{query.GetInt32(1)}";
                }
            }
            if (id == null)
            {
                string query_2 = $"INSERT INTO {Connect.DataBase}.models_types (name) VALUES ('{models_types}')";
                Connect.Connection(query_2);
                id = room_Chek(models_types);
            }
            return id;
        }
        public void ImportCsvData_software()
        {
            string csvFilePath = "C:/Users/student-a202/Desktop/6aaa.csv";
            using (MySqlConnection connection = new MySqlConnection(Connect.con))
            {

                connection.Open();
                foreach (var line in File.ReadLines(csvFilePath))
                {

                    var values = line.Split(';');

                    string name = values.Length > 0 ? values[0] : string.Empty;
                    string developer_id = values.Length > 1 ? values[1] : string.Empty;
                    developer_id= developers_Chek(developer_id);
                    string version = values.Length > 2 ? values[2] : string.Empty;
                    

                    string query = $"INSERT INTO {Connect.DataBase}.rooms (name, developer_id , responsible_user_id)" +
                        $" VALUES ('{name}', '{developer_id}', '{version}')";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }

        }
        public string developers_Chek(string developers)
        {
            MySqlDataReader query = Connect.Connection($"select name, id from {Connect.DataBase}.developers");
            string id = null;
            while (query.Read())
            {
                if (query.GetString(0) == developers)
                {
                    id = $"{query.GetInt32(1)}";
                }
            }
            if (id == null)
            {
                string query_2 = $"INSERT INTO {Connect.DataBase}.developers (name) VALUES ('{developers}')";
                Connect.Connection(query_2);
                id = room_Chek(developers);
            }
            return id;
        }
        /// <summary>
        /// ////
        /// </summary>
        public void ImportCsvData_network_settings()
        {
            string csvFilePath = "C:/Users/student-a202/Desktop/6aaa.csv";
            using (MySqlConnection connection = new MySqlConnection(Connect.con))
            {

                connection.Open();
                foreach (var line in File.ReadLines(csvFilePath))
                {

                    var values = line.Split(';');
                    string equipment_id = values.Length > 0 ? values[0] : string.Empty;

                    string ip_address = values.Length > 1 ? values[1] : string.Empty;

                    string subnet_mask = values.Length > 2 ? values[2] : string.Empty;

                    string gateway = values.Length > 3 ? values[3] : string.Empty;

                    string dns_servers = values.Length > 4 ? values[4] : string.Empty;

                    string query = $"INSERT INTO {Connect.DataBase}.network_settings (equipment_id, ip_address, subnet_mask, gateway, dns_servers)" +
                        $" VALUES ('{equipment_id}', '{ip_address}', '{subnet_mask}', '{gateway}', '{dns_servers}')";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }

        }
    }
}