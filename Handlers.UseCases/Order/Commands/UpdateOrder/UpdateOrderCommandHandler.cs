using System.Threading.Tasks;
using AutoMapper;
using Handlers.CqrsFramework;
using Handlers.Infrastructure.Interfaces;
using Handlers.UseCases.Common.Commands.UpdateEntity;
using Handlers.UseCases.Order.Dto;
using Microsoft.EntityFrameworkCore;

namespace Handlers.UseCases.Order.Commands.UpdateOrder
{
    public class UpdateProductCommandHandler : UpdateEntityCommandHandler<UpdateOrderCommand,Entities.Order,ChangeOrderDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IDbContext dbContext,IMapper mapper):base(dbContext,mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected  override async Task HandleAsync(UpdateOrderCommand request)
        {
           
        }

        protected override async Task<Entities.Order> GetTrackedEntityAsync(int id)
        {
            return await _dbContext.Orders
                .Include(x => x.Items)
                .SingleAsync(o => o.Id == id);
        }
    }

}
