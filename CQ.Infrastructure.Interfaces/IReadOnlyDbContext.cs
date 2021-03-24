using CQ.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQ.Infrastructure.Interfaces
{
    public interface IReadOnlyDbContext
    { 
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<T> Set<T>() where T : Entity;
    }
}