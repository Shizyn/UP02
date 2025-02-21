using System;
using System.Collections.Generic;
using System.Text;

namespace UP02.Classes
{
    public class Inventoryequipment
    {
        public int Id { get; set; }
        public int Equipment_id { get; set; }
        public int Checked_by_user_id { get; set; }
        public int Inventory_check_id { get; set; }
        public string Comment { get; set; }
    }
}
