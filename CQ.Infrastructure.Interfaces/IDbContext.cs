using System.Threading;
using System.Threading.Tasks;
using CQ.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQ.Infrastructure.Interfaces
{
    public interface IDbContext:IReadOnlyDbContext
    { 
        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
