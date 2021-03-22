using System.Threading;
using System.Threading.Tasks;
using Handlers.Entities;
using Microsoft.EntityFrameworkCore;

namespace Handlers.Infrastructure.Interfaces
{
    public interface IDbContext
    { 
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
