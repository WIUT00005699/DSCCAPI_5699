using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC_CW_5699.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Manufacturer { get; set; }
        public string Category { get; set; }
    }
}
