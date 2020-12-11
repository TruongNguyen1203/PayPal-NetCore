using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayPayCore.Models
{
    public class ProductModel
    {
        public List<Product> FindAll()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = "p01",
                    Name = "Name 1",
                    Photo = "macbook.jfif",
                    Price = 4.5,
                    Quantity = 2
                },
                 new Product
                {
                    Id = "p02",
                    Name = "Name 2",
                    Photo = "macbook2.jpg",
                    Price = 7.6,
                    Quantity = 4
                },
                  new Product
                {
                    Id = "p03",
                    Name = "Name 3",
                    Photo = "nhamthehao.jpg",
                    Price = 10,
                    Quantity = 5
                }
            };
        }
    }
}
