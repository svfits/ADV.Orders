using ADV.Orders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ADV.OrdersProducts.Models
{
    public class DatailsOrderViewModel
    {
        public string OrderName { get; set; }

        public DateTime DateCreate { get; set; }

        public Status Status { get; set; }

        public int Total { get; set; }
    }
}
