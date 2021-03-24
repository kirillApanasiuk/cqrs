using CQ.DataAccess.MsSql;
using CQ.Entities;
using CQ.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Handlers.DataAccess.MsSql
{
    public class AppDbContext : ReadOnlyAppDbContext, IDbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = true;
        }
       
    }
}
