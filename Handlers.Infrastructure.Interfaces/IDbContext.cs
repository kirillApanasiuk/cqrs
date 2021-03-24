using System.Threading;
using System.Threading.Tasks;
using Handlers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Handlers.Infrastructure.Interfaces
{
    public interface IDbContext:IReadOnlyDbContext
    { 
        Task<int> SaveChangesAsync(CancellationToken token = default);
        IDbContextTransaction BeginTransaction();
    }
}
