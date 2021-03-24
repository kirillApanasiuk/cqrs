using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApplicationServices.Interfaces.Product;

namespace Layers.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IReadOnlyProductService _readOnlyProductService;

        public ProductsController(
            IProductService productService,
            IReadOnlyProductService readOnlyProductService
            )
        {
            _productService = productService;
            _readOnlyProductService = readOnlyProductService;
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> GetByIdAsync(int id)
        {
            return await _readOnlyProductService.GetByIdAsync(id);
        }

        [HttpPost]
        public async  Task<int> CreateAsync([FromBody] ChangeProductDto dto)
        {
            return await _productService.CreateEntityAsync(dto);
        }

        [HttpPut]
        public  async Task UpdateAsync(int id, [FromBody]ChangeProductDto dto)
        {
            await _productService.UpdateEntityAsync(id, dto);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _productService.DeleteEntityAsync(id);
        }

        [HttpDelete]
        public Task DeleteAllAsync(DeleteAllDto dto)
        {
            return _productService.DeleteAllAsync(dto);
        }
    }
}
