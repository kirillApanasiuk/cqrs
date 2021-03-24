using System.Threading.Tasks;
using ApplicationServices.Interfaces.Common;
using AutoMapper;
using Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationServices.Implementation.Common
{
    public abstract class EntityService<TEntity,TDto> : IEntityService<TDto>  where  TEntity:Entity
    {
        private readonly IDbContext _dbContext;
        private readonly  IMapper _mapper;

        protected EntityService(IDbContext dbContext, IMapper mapper)
             
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
  
        public virtual async Task<int> CreateEntityAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            InitializeNewEntity(entity);
            _dbContext.Set<TEntity>().Add(entity);
            await  _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        protected virtual void InitializeNewEntity(TEntity entity)
        {
        }

        public virtual async Task UpdateEntityAsync(int id,TDto dto)
        {
            var entity = await GetTrackedEntity(id);
            _mapper.Map(dto,entity);
            await _dbContext.SaveChangesAsync();
        }

        protected virtual async Task<Entity> GetTrackedEntity(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);

        }
    }
}
