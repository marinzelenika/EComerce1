using ECommerce1.Models;

namespace ECommerce1.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> AddAsync(Order order);
        Task<Order> UpdateAsync(Order order);
        Task<Order> GetByIdAsync(int id);
        Task DeleteAsync(Order order);

    }
}
