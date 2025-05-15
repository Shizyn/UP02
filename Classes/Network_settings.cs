using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace UP02.Classes
{
    public class Network_settings
    {
        public int Id { get; set; }
        public int Equipment_id { get; set; }
        public string Ip_address { get; set; }
        public string Subnet_mask { get; set; }
        public string Gateway { get; set; }
        public string Dns_servers { get; set; }
        public Network_settings(int Id, int Equipment_id, string Ip_address, string Subnet_mask, string Gateway, string Dns_servers) 
        {
            this.Id = Id;
            this.Equipment_id = Equipment_id;
            this.Ip_address = Ip_address;
            this.Subnet_mask = Subnet_mask;
            this.Gateway = Gateway;
            this.Dns_servers = Dns_servers;
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
        public static List<Network_settings> Select()
        {
            List<Network_settings> AllNetwork_settings = new List<Network_settings>();
            string SQL = "SELECT * FROM `network_settings`;";
            MySqlConnection connection = OpenConnection();
            MySqlDataReader Data = Query(SQL, connection);
            while (Data.Read())
            {
                AllNetwork_settings.Add(new Network_settings(
                    Data.GetInt32(0),
                    Data.GetInt32(1),
                    Data.GetString(2),
                    Data.GetString(3),
                    Data.GetString(4),
                    Data.GetString(5)
                    ));
            }
            CloseConnection(connection);
            return AllNetwork_settings;
        }
        public void Add()
        {
            string SQL = $"INSERT INTO `network_settings`(`equipment_id`, `ip_address`, `subnet_mask`, `gateway`, `dns_servers`) " +
                         $"VALUES ('{this.Equipment_id}','{this.Ip_address}','{this.Subnet_mask}','{this.Gateway}','{this.Dns_servers}')";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }
        public void Update()
        {
            string SQL = $"UPDATE `rooms` SET `equipment_id`='{this.Equipment_id}',`ip_address`='{this.Ip_address}',`subnet_mask`='{this.Subnet_mask}',`gateway`='{this.Gateway}',`dns_servers`='{this.Dns_servers}' WHERE `id`='{this.Id}'";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }

        public void Delete()
        {
            string SQL = $"DELETE FROM `network_settings` WHERE `id` = {this.Id}";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }
    }
}