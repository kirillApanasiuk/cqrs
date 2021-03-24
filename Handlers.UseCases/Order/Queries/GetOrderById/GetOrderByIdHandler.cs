using AutoMapper;
using Handlers.UseCases.Order.Dto;
using Handlers.Infrastructure.Interfaces;
using Handlers.UseCases.Common.Queries.GetEntityById;

namespace Handlers.UseCases.Order.Queries.GetOrderById
{
    public class GetOrderByIdHandler : GetEntityByIdQueryHandler<GetOrderByIdQuery,Entities.Order,OrderDto>
    {
        public GetOrderByIdHandler(IDbContext dbContext,IMapper mapper):base(dbContext,mapper)
        {
          
        }
    }

  
}
