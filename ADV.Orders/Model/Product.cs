namespace ADV.Orders.Model
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int Qty { get; set; }

        public int Price { get; set; }

        public Order Order { get; set; }
    }
}