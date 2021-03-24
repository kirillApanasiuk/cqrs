using AutoMapper;
using Handlers.UseCases.Product.Dto;

namespace Handlers.UseCases.Product.Utils
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Entities.Product, ProductDto>();
            CreateMap<ChangeProductDto, Entities.Product>();
        }
    }
}
