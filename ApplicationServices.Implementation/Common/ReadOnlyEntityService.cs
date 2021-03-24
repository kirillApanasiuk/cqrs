using System.Linq;
using System.Threading.Tasks;
using ApplicationServices.Interfaces;
using ApplicationServices.Interfaces.Common;
using ApplicationServices.Interfaces.Order;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationServices.Implementation.Common
{
    public abstract class ReadOnlyEntityService<TEntity,TDto> : IReadOnlyEntityService<TDto> where TEntity:Entity
    {

        private readonly IReadOnlyDbContext _dbContext;
        private readonly IMapper _mapper;

        public ReadOnlyEntityService(IReadOnlyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<TDto> GetByIdAsync(int id)
        {
            var result = await _dbContext.Set<TEntity>()
                .Where(x => x.Id == id)
                .ProjectTo<TDto>(_mapper.ConfigurationProvider)
                .SingleAsync();
            return result;
        }
    }
}