using CQ.Infrastructure.Interfaces;
using CQ.UseCases.Common.DeleteEntity;

namespace CQ.UseCases.Products.DeleteProduct
{
    class DeleteProductCommandHandler:DeleteEntityCommandHandler<DeleteProductCommand,Entities.Product>
    {
        public DeleteProductCommandHandler(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
