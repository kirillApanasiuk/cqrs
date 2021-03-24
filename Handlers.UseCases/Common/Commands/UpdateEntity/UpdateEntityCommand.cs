using Handlers.UseCases.Order.Dto;

namespace Handlers.UseCases.Common.Commands.UpdateEntity
{
    public abstract class UpdateEntityCommand<TDto>
    {
        public int Id { get; set; }
        public TDto Dto { get; set; }
    }
}
