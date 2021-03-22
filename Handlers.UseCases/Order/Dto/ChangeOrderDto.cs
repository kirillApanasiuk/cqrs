using System.Collections.Generic;

namespace Handlers.UseCases.Order.Dto
{
    public class ChangeOrderDto
    {
        public List<OrderItemDto> Items { get; set; }
    }
}