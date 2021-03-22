using System.Linq;
using Handlers.CqrsFramework;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Handlers.UseCases.Order.Dto;
using Handlers.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Handlers.UseCases.Order.Queries.GetOrderById
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderByIdHandler(IDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<OrderDto> HandleAsync(GetOrderByIdQuery request)
        {
            var result = await _dbContext.Orders
                .Where(x => x.Id == request.Id)
                .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                .SingleAsync();
            return result;
        }
    }

  
}
