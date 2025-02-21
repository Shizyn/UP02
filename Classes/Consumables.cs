using System;
using System.Collections.Generic;
using System.Text;

namespace UP02.Classes
{
    public class Consumables
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Arrival_date { get; set; }
        public BadImageFormatException Image { get; set; }
        public int Count { get; set; }
        public int User_id { get; set; }
        public int Consumable_type_id { get; set; }
    }
}
