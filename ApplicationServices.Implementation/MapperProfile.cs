using ApplicationServices.Interfaces;
using ApplicationServices.Interfaces.Product;
using AutoMapper;
using Entities;

namespace ApplicationServices.Implementation
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Entities.Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<ChangeOrderDto, Entities.Order>(); 

            CreateMap<Entities.Product, ProductDto>();
            CreateMap<ChangeProductDto, Entities.Product>();
        }
    }
}
