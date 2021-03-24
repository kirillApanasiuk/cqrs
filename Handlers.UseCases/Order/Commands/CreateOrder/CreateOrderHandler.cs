using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Handlers.ApplicationServices.Interfaces;
using Handlers.Infrastructure.Interfaces;
using Handlers.UseCases.Common.Commands.CreateEntity;
using Handlers.UseCases.Order.Dto;

namespace Handlers.UseCases.Order.Commands.CreateOrder
{
   public  class CreateOrderCommandHandler : CreateEntityCommandHandler<CreateOrderCommand,Entities.Order,ChangeOrderDto>
    {
        private readonly ICurrentUserService _userService;
        private readonly IStatisticService _statisticService;


        public CreateOrderCommandHandler(
            IDbContext dbContext,
            IMapper mapper,
            ICurrentUserService userService,
            IStatisticService statisticService ):base(dbContext,mapper)
        {
            _userService = userService;
            _statisticService = statisticService;
        }
        public override async Task<int> HandleAsync(CreateOrderCommand request)
        {
            await _statisticService.WriteStatisticAsync("Order", request.Dto.Items.Select(i => i.ProductId));
            return await base.HandleAsync(request);
        }

        protected override void InitializeNewEntity(Entities.Order order)
        {
            order.UserEmail = _userService.Email;
        }
    }
}
