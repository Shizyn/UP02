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
        public Network_settings(int Id, int Equipment_id) { }
    }
}
