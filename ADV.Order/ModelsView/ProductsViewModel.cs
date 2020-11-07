using ADV.OrdersProducts.Model;
using System.Collections.Generic;

namespace ADV.OrdersProducts.Models
{
    public class ProductsViewModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Qty { get; set; }

        public int Price { get; set; }

        public int Total { get; set; }
    }
}
