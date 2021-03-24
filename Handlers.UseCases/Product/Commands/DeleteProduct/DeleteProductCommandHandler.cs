
using Handlers.Infrastructure.Interfaces;
using Handlers.UseCases.Common.Commands.DeleteEntity;

namespace Handlers.UseCases.Product.Commands.DeleteProduct
{
    class DeleteProductCommandHandler:DeleteEntityCommandHandler<DeleteProductCommand,Entities.Product>
    {
        public DeleteProductCommandHandler(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
