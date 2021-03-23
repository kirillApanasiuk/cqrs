using System.Collections.Generic;

namespace CQ.UseCases.Order.Dto
{
    public class ChangeOrderDto
    {
        public List<OrderItemDto> Items { get; set; }
    }
}