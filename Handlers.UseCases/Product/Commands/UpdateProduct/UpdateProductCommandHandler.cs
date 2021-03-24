using AutoMapper;
using Handlers.Infrastructure.Interfaces;
using Handlers.UseCases.Common.Commands.UpdateEntity;
using Handlers.UseCases.Product.Dto;

namespace Handlers.UseCases.Product.Commands.UpdateProduct
{
    public class
        UpdateProductCommandHandler : UpdateEntityCommandHandler<UpdateProductCommand, Entities.Product,
            ChangeProductDto>
    {
        public UpdateProductCommandHandler(IDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {

        }

    }

}
