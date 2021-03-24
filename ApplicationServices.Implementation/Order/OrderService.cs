using System;
using System.Linq;
using System.Threading.Tasks;
using ApplicationServices.Implementation.Common;
using ApplicationServices.Interfaces;
using ApplicationServices.Interfaces.Order;
using AutoMapper;
using Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationServices.Implementation.Order
{
    public class OrderService :EntityService<Entities.Order,ChangeOrderDto>, IOrderService
    {
        private readonly IDbContext _dbContext;
        private readonly ICurrentUserService _userService;
        private readonly IStatisticService _statisticService;

        public OrderService(
            IDbContext dbContext,
            IMapper mapper,
            ICurrentUserService userService,
            IStatisticService statisticService
             ):base(dbContext,mapper)
        {
            _dbContext = dbContext;
            _userService = userService;
            _statisticService = statisticService;
        }

        protected override void InitializeNewEntity(Entities.Order order)
        {
            order.UserEmail = _userService.Email;
        }

        public override async  Task<int> CreateEntityAsync(ChangeOrderDto dto)
        {
            await _statisticService.WriteStatisticAsync("Order", dto.Items.Select(x => x.ProductId));
            return await base.CreateEntityAsync(dto);
        }

        protected override async Task<Entity> GetTrackedEntity(int id)
        {
            var order = await _dbContext.Orders
                .Include(x => x.Items)
                .SingleAsync(x => x.Id == id);
            return order;
        }

        public override Task DeleteEntityAsync(int id)
        {
            throw new NotSupportedException();
        }
    }
}
