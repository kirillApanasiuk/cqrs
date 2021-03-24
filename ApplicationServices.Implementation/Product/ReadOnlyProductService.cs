using ApplicationServices.Implementation.Common;
using ApplicationServices.Interfaces.Product;
using AutoMapper;
using Infrastructure.Interfaces;

namespace ApplicationServices.Implementation.Product
{
    public class ReadOnlyProductService : ReadOnlyEntityService<Entities.Product, ProductDto>, IReadOnlyProductService
    {
        public ReadOnlyProductService(IReadOnlyDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }
    }
}