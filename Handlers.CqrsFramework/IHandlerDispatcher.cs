using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Handlers.CqrsFramework
{
    public interface IHandlerDispatcher
    {
        Task<TResponse> SendAsync<TRequest, TResponse>(TRequest request);
    }

    public class HandlerDispathcedr:IHandlerDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public HandlerDispathcedr(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public Task<TResponse> SendAsync<TRequest, TResponse>(TRequest request)
        {
            var handler = _serviceProvider.GetRequiredService<IRequestHandler<TRequest, TResponse>>();
            return handler.HandleAsync(request);
        }

    }
}
