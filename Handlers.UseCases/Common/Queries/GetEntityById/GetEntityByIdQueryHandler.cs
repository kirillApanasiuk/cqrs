using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Handlers.CqrsFramework;
using Handlers.Entities;
using Handlers.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Handlers.UseCases.Common.Queries.GetEntityById
{
    public abstract  class GetEntityByIdQueryHandler<TRequest,TEntity,TDto>:IRequestHandler<TRequest,TDto> 
        where TEntity:Entity
        where TRequest:GetEntityByIdQuery
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        protected GetEntityByIdQueryHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public virtual async Task<TDto> HandleAsync(TRequest request)
        {
            var result = await _dbContext.Set<TEntity>()
                .Where(x => x.Id == request.Id)
                .ProjectTo<TDto>(_mapper.ConfigurationProvider)
                .SingleAsync();
            return result;
        }
    }
}
