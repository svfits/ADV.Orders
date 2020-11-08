using ADV.OrdersProducts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADV.OrdersProducts.Models
{
    public class OrdersViewModel
    {
        public int Id { get; set; }

        public string OrderName { get; set; }

        public DateTime DateCreate { get; set; }

        public Status Status { get; set; }
    }
}
