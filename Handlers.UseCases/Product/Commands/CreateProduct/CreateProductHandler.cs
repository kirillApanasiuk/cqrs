using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Handlers.ApplicationServices.Interfaces;
using Handlers.Infrastructure.Interfaces;
using Handlers.UseCases.Common.Commands.CreateEntity;
using Handlers.UseCases.Order.Commands.CreateOrder;
using Handlers.UseCases.Order.Dto;
using Handlers.UseCases.Product.Dto;

namespace Handlers.UseCases.Product.Commands.CreateProduct
{
   public  class CreateProductCommandHandler : CreateEntityCommandHandler<CreateProductCommand,Entities.Product,ChangeProductDto>
    {
        public CreateProductCommandHandler(
            IDbContext dbContext,
            IMapper mapper
            ):base(dbContext,mapper)
        {
        }
    }
}
