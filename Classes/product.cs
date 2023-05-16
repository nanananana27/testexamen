using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class product
    {
        public int id { get; set; }
        public string article { get; set; }
        public string name { get; set; }
        public string measure_unit { get; set; }
        public int price { get; set; }
        public int max_discount { get; set; }
        public string manufacturer { get; set; }
        public string supplier { get; set; }
        public int category_id { get; set; }
        public int discount { get; set; }
        public int amount_on_warehouse { get; set; }
        public string description { get; set; }
        public string img_src { get; set; }
    }
}
