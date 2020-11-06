using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ADV.OrdersProducts.Model
{
    public class Order
    {
        public Order()
        {
            OrdersProducts = new List<OrdersProducts>();
        }

        
        public int Id { get; set; }

        public string OrderName { get; set; }

        public Status Status { get; set; }

        public DateTime DateCreate { get; set; }

        public List<OrdersProducts> OrdersProducts { get; set; }
    }

    public enum Status
    {
        Complete,
        Inprogress
    }
}