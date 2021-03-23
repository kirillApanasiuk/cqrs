﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Handlers.CqrsFramework;
using Handlers.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Handlers.UseCases.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : RequestHandler<UpdateOrderCommand>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected  override async Task HandleAsync(UpdateOrderCommand request)
        {
            var order = await _dbContext.Orders
                .Include(x => x.Items)
                .SingleAsync(o => o.Id == request.Id);

            _mapper.Map(request.Dto, order);
            await _dbContext.SaveChangesAsync();
        }
    }
}
