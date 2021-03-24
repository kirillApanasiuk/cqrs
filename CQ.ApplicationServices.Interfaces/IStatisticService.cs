using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQ.ApplicationServices.Interfaces
{
    public interface IStatisticService
    { 
        Task WriteStatisticAsync(string area, int productId);
        Task WriteStatisticAsync(string area, IEnumerable<int> productIds);

    }
}
