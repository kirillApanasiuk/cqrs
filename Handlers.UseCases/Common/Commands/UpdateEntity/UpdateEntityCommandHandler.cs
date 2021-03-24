using System.Threading.Tasks;
using AutoMapper;
using Handlers.CqrsFramework;
using Handlers.Entities;
using Handlers.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Handlers.UseCases.Common.Commands.UpdateEntity
{
    public abstract class UpdateEntityCommandHandler<TRequest,TEntity,TDto> : RequestHandler<TRequest>
    where  TEntity:Entity
    where  TRequest:UpdateEntityCommand<TDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        protected UpdateEntityCommandHandler(IDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected  override async Task HandleAsync(TRequest request)
        {
            var entity = await GetTrackedEntityAsync(request.Id);

            _mapper.Map(request.Dto, entity);

            await _dbContext.SaveChangesAsync();
        }

        protected virtual async Task<TEntity> GetTrackedEntityAsync(int id)
        {
           return  await _dbContext.Set<TEntity>()
                .SingleAsync(o => o.Id == id);
        }
    }
}
