using CQ.CqrsFramework;
using CQ.UseCases.Order.Queries.GetOrderById;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;
using CQ.UseCases.Order.Commands.CreateOrder;
using CQ.UseCases.Order.Commands.UpdateOrder;
using CQ.UseCases.Order.Dto;


namespace Handlers.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        [HttpGet("{id}")]
        public Task<OrderDto> GetByIdAsync(
            int id,
            [FromServices] IQueryHandler<GetOrderByIdQuery, OrderDto> handler)
        {
            return handler.HandleAsync(new GetOrderByIdQuery {Id = id});
        }

        [HttpPost]
        public async Task CreateAsync(
            [FromBody] ChangeOrderDto dto,
            [FromServices] ICommandHandler<CreateOrderCommand> handler)
        {
            await handler.HandleAsync(new CreateOrderCommand {Dto = dto});
        }

        [HttpPut("{id}")]
        public async Task UpdateAsync(
           int id,
            [FromBody] ChangeOrderDto dto,
            [FromServices] ICommandHandler<UpdateOrderCommand>  handler
        )
        {
            await handler.HandleAsync(new UpdateOrderCommand {Dto = dto, Id = id});
        }
    }
}
