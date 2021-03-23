using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Handlers.CqrsFramework;
using Handlers.Infrastructure.Interfaces;

namespace Handlers.UseCases.Order.Commands.CreateOrder
{
   public  class CreateOrderHandler : IRequestHandler<CreateOrderCommand, int>
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
        public async Task<int> HandleAsync(CreateOrderCommand request)
        {
            var order = _mapper.Map<Entities.Order>(request.Dto);
            order.UserEmail = _userService.Email;
            await _dbContext.SaveChangesAsync();
            return order.Id;
        }
    }
}
