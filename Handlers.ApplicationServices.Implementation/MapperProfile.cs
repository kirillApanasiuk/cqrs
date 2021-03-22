using AutoMapper;
using Handlers.Entities;
using Handlers.UseCases.Order.Dto;

namespace Handlers.ApplicationServices.Implementation
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<ChangeOrderDto, Order>();
        }
    }
}
