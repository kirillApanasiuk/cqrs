using System.Linq;
using System.Threading.Tasks;
using ApplicationServices.Implementation.Common;
using ApplicationServices.Interfaces;
using ApplicationServices.Interfaces.Order;
using ApplicationServices.Interfaces.Product;
using AutoMapper;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationServices.Implementation.Product
{
    public class ProductService :EntityService<Entities.Product,ChangeProductDto>, IProductService
    {
        private readonly IDbContext _dbContext;

        public ProductService(
            IDbContext dbContext,
            IMapper mapper
             ):base(dbContext,mapper)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteAllAsync(DeleteAllDto dto)
        {
            using (var transaction = _dbContext.BeginTransaction())
            {
                var tasks = dto.Ids.Select(x => DeleteEntityAsync(x));

                await Task.WhenAll(tasks);

                await transaction.CommitAsync();
            }
        }
    }
}
