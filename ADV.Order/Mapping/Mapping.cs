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
                .ForMember(w => w.DateCreate, mem => mem.MapFrom(p => p.DateCreate.ToString("dd.MM.yyyy HH:mm")))
                ;

            CreateMap<Order, OrdersViewModel>()
                ;

            CreateMap<Model.OrdersProducts, ProductsViewModel>()
                .ForMember(w => w.Total, mem => mem.MapFrom(p => p.Product.Qty * p.Product.Price ))
                .ForMember(w => w.ProductId, mem => mem.MapFrom(p => p.Id))
                .ForMember(w => w.ProductName, mem => mem.MapFrom(p => p.Product.ProductName))
                .ForMember(w => w.Qty, mem => mem.MapFrom(p => p.Product.Qty))
                .ForMember(w => w.Price, mem => mem.MapFrom(p => p.Product.Price))
              ;
        }
    }
}
