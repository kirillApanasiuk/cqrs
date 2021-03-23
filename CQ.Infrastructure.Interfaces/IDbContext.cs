using System.Threading;
using System.Threading.Tasks;
using CQ.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQ.Infrastructure.Interfaces
{
    public interface IDbContext
    { 
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
