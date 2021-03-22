using AutoMapper;
using Handlers.Entities;
using Handlers.UseCases.Order.Dto;

namespace Handlers.UseCases.Order.Utils
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Entities.Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<ChangeOrderDto, Entities.Order>();
        }
    }
}
