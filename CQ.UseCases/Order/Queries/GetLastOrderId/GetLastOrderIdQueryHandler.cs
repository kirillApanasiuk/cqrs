using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQ.CqrsFramework;
using CQ.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CQ.UseCases.Order.Queries.GetLastOrderId
{
    public class GetLastOrderIdQueryHandler : IQueryHandler<GetLastOrderIdQuery, int>
    {
        private readonly IDbContext _dbContext;

        public GetLastOrderIdQueryHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> HandleAsync(GetLastOrderIdQuery request)
        {
            var id= await _dbContext.Orders
                .OrderByDescending(x => x.Id)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();
            return id;
        }
    }
}
