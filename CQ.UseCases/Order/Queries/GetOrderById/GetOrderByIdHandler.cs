using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CQ.CqrsFramework;
using CQ.Infrastructure.Interfaces;
using CQ.UseCases.Order.Dto;
using Microsoft.EntityFrameworkCore;

namespace CQ.UseCases.Order.Queries.GetOrderById
{
    public class GetOrderByIdHandler : IQueryHandler<GetOrderByIdQuery, OrderDto>
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
