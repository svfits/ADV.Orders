using ADV.OrdersProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADV.OrdersProducts.Interfaces
{
    public interface IServicesHome
    {
        Task<DatailsOrderViewModel> GetDatailsOrder(int IdOrder);

        Task<OrdersViewModel> GetOrders();

        Task<ProductsViewModel> GetProducts(int IdOrder);
    }
}
