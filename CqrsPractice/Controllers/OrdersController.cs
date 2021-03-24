using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApplicationServices.Interfaces;
using ApplicationServices.Interfaces.Common;
using ApplicationServices.Interfaces.Order;

namespace Layers.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IReadOnlyOrderService _readOnlyOrderService;

        public OrdersController(
            IOrderService orderService,
            IReadOnlyOrderService readOnlyOrderService
            )
        {
            _orderService = orderService;
            _readOnlyOrderService = readOnlyOrderService;
        }

        [HttpGet("{id}")]
        public Task<OrderDto> GetByIdAsync(int id)
        {
            return _readOnlyOrderService.GetByIdAsync(id);
        }

        [HttpPost]
        public Task<int> CreateAsync([FromBody] ChangeOrderDto dto)
        {
            return _orderService.CreateEntityAsync(dto);
        }

        [HttpPut("{id}")]
        public  async Task UpdateAsync(int id, [FromBody]ChangeOrderDto dto)
        {
            await _orderService.UpdateEntityAsync(id, dto);
        }

    }
}
