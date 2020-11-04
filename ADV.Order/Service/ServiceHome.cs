using ADV.Orders.Model;
using ADV.OrdersProducts.Interfaces;
using ADV.OrdersProducts.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADV.OrdersProducts.Service
{
    public class ServiceHome : IServicesHome
    {
        private readonly DataContextApp ctx;
        private readonly Mapper mapper;

        public ServiceHome(DataContextApp ctx, Mapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public Task<DatailsOrderViewModel> GetDatailsOrder(int IdOrder)
        {
            throw new NotImplementedException();
        }

        public Task<OrdersViewModel> GetOrders()
        {
            throw new NotImplementedException();
        }

        public Task<ProductsViewModel> GetProducts(int IdOrder)
        {
            throw new NotImplementedException();
        }
    }
}
