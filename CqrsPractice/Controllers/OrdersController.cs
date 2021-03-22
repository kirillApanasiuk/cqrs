using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApplicationServices.Interfaces;

namespace Layers.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(
            IOrderService orderService
            )
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public Task<OrderDto> GetByIdAsync(int id)
        {
            return _orderService.GetByIdAsync(id);
        }

        [HttpPost]
        public Task<int> CreateAsync([FromBody] ChangeOrderDto dto)
        {
            return _orderService.CreateOrderAsync(dto);
        }

        [HttpPut("{id}")]
        public  async Task UpdateAsync(int id, [FromBody]ChangeOrderDto dto)
        {
            await _orderService.UpdateOrderAsync(id, dto);
        }

    }
}
