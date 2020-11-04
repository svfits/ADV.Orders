using System.Collections.Generic;

namespace ADV.Orders.Model
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int Qty { get; set; }

        public int Price { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}