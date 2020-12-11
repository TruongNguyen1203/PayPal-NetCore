using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayPayCore.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
