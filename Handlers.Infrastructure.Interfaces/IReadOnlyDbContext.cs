using Handlers.Entities;
using Microsoft.EntityFrameworkCore;

namespace Handlers.Infrastructure.Interfaces
{
    public interface IReadOnlyDbContext
    { 
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
    }
}