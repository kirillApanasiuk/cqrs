﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Handlers.CqrsFramework
{
    public class HandlerDispathcer:IHandlerDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public HandlerDispathcer(IServiceProvider serviceProvider)
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