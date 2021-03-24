namespace Handlers.UseCases.Common.Commands.CreateEntity
{
    public abstract class CreateEntityCommand<TDto>
    {
        public TDto Dto { get; set; }
    }
}
