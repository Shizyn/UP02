using System;
using System.Collections.Generic;
using System.Text;

namespace UP02.Classes
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BadImageFormatException Photo { get; set; }
        public int Inventory_number { get; set; }
        public int Room_id { get; set; }
        public int Model_id { get; set; }
        public int User_id { get; set; }
        public int Responsible_user_id { get; set; }
        public int Direction_id { get; set; }
        public int Status_id { get; set; }
        public decimal Cost { get; set; }
        public string Comment { get; set; }
        public int Software_id { get; set; }

    }
}
