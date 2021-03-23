using Handlers.UseCases.Order.Dto;

namespace Handlers.UseCases.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommand
    {
        public int Id { get; set; }
        public ChangeOrderDto Dto { get; set; }
    }
}
