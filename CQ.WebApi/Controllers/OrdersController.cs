using CQ.CqrsFramework;
using CQ.UseCases.Order.Commands.CreateOrder;
using CQ.UseCases.Order.Commands.UpdateOrder;
using CQ.UseCases.Order.Dto;
using CQ.UseCases.Order.Queries.GetLastOrderId;
using CQ.UseCases.Order.Queries.GetOrderById;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


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
        public async Task<int> CreateAsync(
            [FromBody] ChangeOrderDto dto,
            [FromServices] ICommandHandler<CreateOrderCommand> commandHandler,
            [FromServices] IQueryHandler<GetLastOrderIdQuery,int> queryHandler
            )
        {
            var command = new CreateOrderCommand {Dto = dto};
            await commandHandler.HandleAsync(command);

            var id = await queryHandler.HandleAsync(new GetLastOrderIdQuery());
            return id;
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
