using System.Threading.Tasks;
using Handlers.CqrsFramework;
using Handlers.Entities;
using Handlers.Infrastructure.Interfaces;

namespace Handlers.UseCases.Common.Commands.DeleteEntity
{
    public abstract  class DeleteEntityCommandHandler<TRequest,TEntity>:RequestHandler<TRequest> 
        where TRequest:DeleteEntityCommand 
        where TEntity:Entity,new()
    {
        private readonly IDbContext _dbContext;

        protected DeleteEntityCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override async  Task HandleAsync(TRequest request)
        {
            _dbContext.Set<TEntity>().Remove(new TEntity {Id = request.Id});
            await _dbContext.SaveChangesAsync();
        }
    }
}
