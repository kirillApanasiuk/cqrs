using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CQ.CqrsFramework;
using CQ.UseCases.Products.DeleteProduct;

namespace Handlers.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        [HttpDelete("{id}")]
        public  Task DeleteAsync(int id,[FromServices] ICommandHandler<DeleteProductCommand> handler)
        {
            return  handler.HandleAsync(new DeleteProductCommand {Id = id});
        }
    }
}
