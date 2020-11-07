using ADV.OrdersProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADV.OrdersProducts.ModelsView
{
    public class IndexHomeViewModel
    {
        public DatailsOrderViewModel DatailsOrderViewModel { get; set; }

        public List<OrdersViewModel> OrdersViewModel { get; set; }

        public List<ProductsViewModel> ProductsViewModel { get; set; }
    }
}
