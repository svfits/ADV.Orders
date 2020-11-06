using ADV.OrdersProducts.Model;
using ADV.OrdersProducts.Models;
using AutoMapper;
using System.Linq;

namespace ADV.OrdersProducts.Mapping
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Order, DatailsOrderViewModel>()
                .ForMember(w => w.Total, mem => mem.MapFrom(p => p.OrdersProducts.Sum(r => r.Product.Qty * r.Product.Price)))
                ;

            CreateMap<Order, OrdersViewModel>()
                ;


        }
    }
}
