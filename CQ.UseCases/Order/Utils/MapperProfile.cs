using AutoMapper;
using CQ.Entities;
using CQ.UseCases.Order.Dto;

namespace CQ.UseCases.Order.Utils
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
