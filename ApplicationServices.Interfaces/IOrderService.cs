using System;
using System.Threading.Tasks;

namespace ApplicationServices.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> GetByIdAsync(int id);
        Task<int> CreateOrderAsync(ChangeOrderDto dto);
        Task UpdateOrderAsync(int id,ChangeOrderDto dto);
    }
}
