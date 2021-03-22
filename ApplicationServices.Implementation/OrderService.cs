using ApplicationServices.Interfaces;
using Infrastructure.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationServices.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IDbContext _dbContext;
        private readonly  IMapper _mapper;
        private readonly ICurrentUserService _userService;

        public OrderService(IDbContext dbContext,IMapper mapper,ICurrentUserService userService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<OrderDto> GetByIdAsync(int id)
        {
           var result = await _dbContext.Orders
                .Where(x => x.Id == id)
                .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                .SingleAsync();
           return result;
        }

        public async Task<int> CreateOrderAsync(ChangeOrderDto dto)
        {
            var order = _mapper.Map<Order>(dto);
            order.UserEmail = _userService.Email;
            _dbContext.Orders.Add(order);
            await  _dbContext.SaveChangesAsync();
            return order.Id;
        }

        public async Task UpdateOrderAsync(int id,ChangeOrderDto dto)
        {
            var order = await _dbContext.Orders
                .Include(x => x.Items)
                .SingleAsync(o => o.Id == id);
            _mapper.Map(dto,order);
            await _dbContext.SaveChangesAsync();
        }
    }
}
