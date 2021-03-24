using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handlers.CqrsFramework;
using Handlers.Infrastructure.Interfaces;
using Handlers.UseCases.Product.Commands.DeleteProduct;
using Microsoft.Extensions.DependencyInjection;

namespace Handlers.UseCases.Product.Commands.DeleteAllProducts
{
    class DeleteAllProductsCommandHandler:RequestHandler<DeleteAllProductsCommand>
    {
        private readonly IHandlerDispatcher _handlerDispatcher;
        private readonly IDbContext _context;

        public DeleteAllProductsCommandHandler(IHandlerDispatcher handlerDispatcher,IDbContext context)
        {
            _handlerDispatcher = handlerDispatcher;
            _context = context;
        }
        protected  override async Task HandleAsync(DeleteAllProductsCommand request)
        {
            using (var transaction = _context.BeginTransaction())
            {

                var tasks = request.Dto.Ids.Select(x =>
                    {
                        var command = new DeleteProductCommand {Id = x};
                        return  _handlerDispatcher.SendAsync<DeleteProductCommand, Task>(command);
                       
                    }
                );

                await Task.WhenAll(tasks);

                await transaction.CommitAsync();
            }
        }
    }
}
