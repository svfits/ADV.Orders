using ADV.OrdersProducts.Interfaces;
using ADV.OrdersProducts.Model;
using ADV.OrdersProducts.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADV.OrdersProducts.Service
{
    public class ServiceHome : IServicesHome
    {
        private readonly DataContextApp ctx;

        private readonly IMapper _mapper;

        public ServiceHome(DataContextApp ctx, IMapper mapper)
        {
            this.ctx = ctx;
            _mapper = mapper;
        }

        public async Task<DatailsOrderViewModel> GetDatailsOrderAsync(int IdOrder)
        {
            var datailsOrder = await ctx.Orders
                .AsNoTracking()
                .Where(s => s.Id.Equals(IdOrder))
                .ProjectTo<DatailsOrderViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync()
                ;

            return datailsOrder;
        }
        public async Task<List<OrdersViewModel>> GetOrdersAsync()
        {
            var orders = await ctx.Orders
               .AsNoTracking()
               .ProjectTo<OrdersViewModel>(_mapper.ConfigurationProvider)
               .ToListAsync()
               ;

            return orders;
        }

        public async Task<List<ProductsViewModel>> GetProductsAsync(int orderId)
        {
            var product = await ctx.OrdersProducts
               .Where(k => k.Order.Id == orderId)
               .ProjectTo<ProductsViewModel>(_mapper.ConfigurationProvider)
               .ToListAsync()
              ;

            return product;
        }
    }
}
