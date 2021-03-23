using CQ.UseCases.Order.Dto;

namespace CQ.UseCases.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommand
    {
        public int Id { get; set; }
        public ChangeOrderDto Dto { get; set; }
    }
}
