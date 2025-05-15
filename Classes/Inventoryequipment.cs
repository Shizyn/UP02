using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace UP02.Classes
{
    public class Inventoryequipment
    {
        public int id { get; set; }
        public int equipment_id { get; set; }
        public int checked_by_user_id { get; set; }
        public int inventory_check_id { get; set; }
        public string comment { get; set; } 
        public Inventoryequipment(int id, int equipment_id, int checked_by_user_id, int inventory_check_id, string comment)
        {
            this.id = id;
            this.equipment_id = equipment_id;
            this.checked_by_user_id = checked_by_user_id;
            this.inventory_check_id = inventory_check_id;
            this.comment = comment;
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
        public static List<Inventoryequipment> Select()
        {
            List<Inventoryequipment> AllInventoryequipment = new List<Inventoryequipment>();
            string SQL = "SELECT * FROM `inventory_equipment`;";
            MySqlConnection connection = OpenConnection();
            MySqlDataReader Data = Query(SQL, connection);
            while (Data.Read())
            {
                AllInventoryequipment.Add(new Inventoryequipment(
                    Data.GetInt32(0),
                    Data.GetInt32(1),
                    Data.GetInt32(2),
                    Data.GetInt32(3),
                    Data.GetString(4)
                    ));
            }
            CloseConnection(connection);
            return AllInventoryequipment;
        }
        public void Add()
        {
            string SQL = $"INSERT INTO `inventory_equipment`(`equipment_id`, `checked_by_user_id`, `inventory_check_id`, `comment`) " +
                         $"VALUES ('{equipment_id}','{checked_by_user_id}','{inventory_check_id}','{comment}')";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }
        public void Update()
        {
            string SQL = $"UPDATE `inventory_equipment` SET `equipment_id`='{equipment_id}',`checked_by_user_id`='{checked_by_user_id}',`inventory_check_id`='{inventory_check_id}',`comment`='{comment} WHERE `id`='{this.id}'";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }

        public void Delete()
        {
            string SQL = $"DELETE FROM `inventory_equipment` WHERE `id` = {id}";
            MySqlConnection connection = OpenConnection();
            Query(SQL, connection);
            CloseConnection(connection);
        }
    }
}