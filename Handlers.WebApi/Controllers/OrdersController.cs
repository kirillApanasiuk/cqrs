using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Handlers.CqrsFramework;
using Handlers.UseCases.Order.Dto;
using Handlers.UseCases.Order.Queries.GetOrderById;

namespace Handlers.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IRequestHandler<GetOrderByIdQuery, OrderDto> _getOrderByIdHandler;

        public OrdersController(IRequestHandler<GetOrderByIdQuery, OrderDto> getOrderByIdHandler)
        {
            _getOrderByIdHandler = getOrderByIdHandler;
        }

        [HttpGet("{id}")]
        public Task<OrderDto> GetByIdAsync(int id)
        {
            return _getOrderByIdHandler.HandleAsync(new GetOrderByIdQuery {Id = id});
        }
    }
}
