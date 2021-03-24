using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Handlers.CqrsFramework;
using Handlers.UseCases.Order.Commands.CreateOrder;
using Handlers.UseCases.Order.Commands.UpdateOrder;
using Handlers.UseCases.Order.Dto;
using Handlers.UseCases.Order.Queries.GetOrderById;
using Handlers.UseCases.Product.Commands.CreateProduct;
using Handlers.UseCases.Product.Commands.DeleteProduct;
using Handlers.UseCases.Product.Commands.UpdateProduct;
using Handlers.UseCases.Product.Dto;
using Handlers.UseCases.Product.Queries.GetProductById;

namespace Handlers.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IRequestHandler<GetProductByIdQuery, ProductDto > _getProductByIdHandler;

        public ProductsController(
            IRequestHandler<GetProductByIdQuery, ProductDto> getProductByIdHandler
            )
        {
            _getProductByIdHandler = getProductByIdHandler;
        }

        [HttpGet("{id}")]
        public Task<ProductDto> GetByIdAsync(int id)
        {
            return _getProductByIdHandler.HandleAsync(new GetProductByIdQuery() { Id = id});
        }

        [HttpPost]
        public async Task<int> CreateAsync(
            [FromBody] ChangeProductDto dto,
            [FromServices] IRequestHandler<CreateProductCommand,int> handler)
        {
            var id = await handler.HandleAsync(new CreateProductCommand() {Dto = dto});
            return id;
        }

        [HttpPut("{id}")]
        public async Task UpdateAsync(
           int id,
            [FromBody] ChangeProductDto dto,
            [FromServices] IRequestHandler<UpdateProductCommand>  handler
        )
        {
            var result = await handler.HandleAsync(new UpdateProductCommand() {Dto = dto, Id = id});
        }

        [HttpDelete("{id}")]
        public  Task DeleteAsync(int id,[FromServices] IRequestHandler<DeleteProductCommand> handler)
        {
            return  handler.HandleAsync(new DeleteProductCommand {Id = id});
        }
    }
}
