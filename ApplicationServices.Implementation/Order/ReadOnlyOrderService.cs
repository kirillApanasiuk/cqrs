using ApplicationServices.Implementation.Common;
using ApplicationServices.Interfaces;
using ApplicationServices.Interfaces.Order;
using AutoMapper;
using Infrastructure.Interfaces;

namespace ApplicationServices.Implementation.Order
{
    public class ReadOnlyOrderService : ReadOnlyEntityService<Entities.Order, OrderDto>, IReadOnlyOrderService
    {
        public ReadOnlyOrderService(IReadOnlyDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }
    }
}