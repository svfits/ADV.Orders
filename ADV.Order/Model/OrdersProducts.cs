using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ADV.OrdersProducts.Model
{
    public class OrdersProducts
    {
        public int Id { get; set; }

        

        public Order Order { get; set; }

       

        public Product Product { get; set; }
    }
}
