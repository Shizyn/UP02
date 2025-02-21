using System;
using System.Collections.Generic;
using System.Text;

namespace UP02.Classes
{
    public class Consumabletypecharacteristics
    {
        public int Id { get; set; }
        public int Consumable_type_id { get; set; }
        public int Characteristic_id { get; set; }
        public string Is_required { get; set; }
        public string Default_value { get; set; }
    }
}
