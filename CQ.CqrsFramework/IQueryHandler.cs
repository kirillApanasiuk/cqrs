using System;
using System.Threading.Tasks;

namespace CQ.CqrsFramework
{
    public interface IQueryHandler<TRequest,TResponse>
    {
        Task<TResponse> HandleAsync(TRequest request);
    }

    public interface ICommandHandler<TRequest>
    {
        Task HandleAsync(TRequest request);
    }
}
