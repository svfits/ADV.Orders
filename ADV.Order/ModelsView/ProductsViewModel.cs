using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADV.OrdersProducts.Models
{
    public class ProductsViewModel
    {
        public string ProductName { get; set; }

        public int Gty { get; set; }

        public int Price { get; set; }

        public int Total { get; set; }
    }
}
