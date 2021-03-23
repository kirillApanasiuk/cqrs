using System.Threading.Tasks;
using AutoMapper;
using CQ.CqrsFramework;
using CQ.Infrastructure.Interfaces;

namespace CQ.UseCases.Order.Commands.CreateOrder
{
   public  class CreateOrderHandler : ICommandHandler<CreateOrderCommand>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;

        public CreateOrderHandler(IDbContext dbContext,IMapper mapper,ICurrentUserService userService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userService = userService;
        }
        public async Task HandleAsync(CreateOrderCommand request)
        {
            var order = _mapper.Map<Entities.Order>(request.Dto);
            order.UserEmail = _userService.Email;
            await _dbContext.SaveChangesAsync();
        }
    }
}
