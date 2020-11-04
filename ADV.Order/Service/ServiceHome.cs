using ADV.Orders.Model;
using ADV.OrdersProducts.Interfaces;
using ADV.OrdersProducts.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ProductsViewModel> GetProductsAsync(int IdOrder)
        {
            var product = await ctx.Orders
               .Include(s => s.Product)
               .FirstOrDefaultAsync(l => l.Id == IdOrder)
               ;

            return new ProductsViewModel() { Product = product.Product.ToList() };
        }
    }
}
