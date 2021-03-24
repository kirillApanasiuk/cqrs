using System.Linq;
using System.Threading.Tasks;
using ApplicationServices.Implementation.Common;
using ApplicationServices.Interfaces;
using ApplicationServices.Interfaces.Order;
using ApplicationServices.Interfaces.Product;
using AutoMapper;
using Infrastructure.Interfaces;

namespace ApplicationServices.Implementation.Product
{
    public class ProductService :EntityService<Entities.Product,ChangeProductDto>, IProductService
    {
        public ProductService(
            IDbContext dbContext,
            IMapper mapper
             ):base(dbContext,mapper)
        {
          
        }
    }
}
