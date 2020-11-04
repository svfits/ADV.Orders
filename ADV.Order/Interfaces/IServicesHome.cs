using ADV.OrdersProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADV.OrdersProducts.Interfaces
{
    public interface IServicesHome
    {
        Task<DatailsOrderViewModel> GetDatailsOrderAsync(int IdOrder);

        Task<List<OrdersViewModel>> GetOrdersAsync();

        Task<ProductsViewModel> GetProductsAsync(int IdOrder);
    }
}
