using ADV.OrdersProducts.Model;
using System;
using System.ComponentModel;

namespace ADV.OrdersProducts.Models
{
    public class DatailsOrderViewModel
    {
        [DisplayName("Number")]
        public string OrderName { get; set; }

        [DisplayName("Date")]        
        public DateTime DateCreate { get; set; }

        [DisplayName("Status")]
        public Status Status { get; set; }

        [DisplayName("Total")]
        public int Total { get; set; }
    }
}
