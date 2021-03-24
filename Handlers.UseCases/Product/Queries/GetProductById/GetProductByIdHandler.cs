using AutoMapper;
using Handlers.Infrastructure.Interfaces;
using Handlers.UseCases.Common.Queries.GetEntityById;
using Handlers.UseCases.Product.Dto;

namespace Handlers.UseCases.Product.Queries.GetProductById
{
    public class GetProductByIdHandler : GetEntityByIdQueryHandler<GetProductByIdQuery,Entities.Product,ProductDto>
    {

        public GetProductByIdHandler(IDbContext dbContext,IMapper mapper):base(dbContext,mapper)
        {
        }
    }

  
}
