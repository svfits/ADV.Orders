using System.Collections.Generic;

namespace ADV.OrdersProducts.Model
{
    public class Product
    {
        public Product()
        {
            OrdersProducts = new List<OrdersProducts>();
        }

        public int Id { get; set; }

        public string ProductName { get; set; }

        public int Qty { get; set; }

        public int Price { get; set; }
        

        public List<OrdersProducts> OrdersProducts { get; set; }
    }
}