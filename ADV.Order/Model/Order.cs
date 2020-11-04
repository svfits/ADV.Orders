using System;
using System.Collections;
using System.Collections.Generic;

namespace ADV.Orders.Model
{
    public class Order
    {
        public Order()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string OrderName { get; set; }

        public Status Status { get; set; }

        public DateTime DateCreate { get; set; }

        public ICollection<Product> Product { get; set; }
    }

    public enum Status
    {
        Complete,
        Inprogress
    }
}