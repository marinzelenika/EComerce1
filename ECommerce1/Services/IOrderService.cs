using ECommerce1.DTOs;
using ECommerce1.Models;

namespace ECommerce1.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
        Task<Order> AddAsync(OrderDTO orderDto);
        Task<Order> UpdateAsync(int id, OrderDTO orderDto);
        Task<OrderDTO> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);

    }
}
