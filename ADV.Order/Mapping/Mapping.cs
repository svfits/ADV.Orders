using ADV.Orders.Model;
using ADV.OrdersProducts.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADV.OrdersProducts.Mapping
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Order, DatailsOrderViewModel>()
                .ForMember(w => w.Total, mem => mem.MapFrom(p => p.Product.Sum(r => r.Qty * r.Price)))
                ;

            CreateMap<Order, OrdersViewModel>()
                ;
        }
    }
}
