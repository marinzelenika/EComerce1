using Mapster;
using ECommerce1.DTOs;
using ECommerce1.Models;
using ECommerce1.Repositories;

namespace ECommerce1.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IOrderRepository repository, ILogger<OrderService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _repository.GetAllOrdersAsync();
            return orders.Adapt<IEnumerable<OrderDTO>>();
        }
        public async Task<Order> AddAsync(OrderDTO orderDto)
        {
            Order order = orderDto.Adapt<Order>();
            return await _repository.AddAsync(order);
        }
        public async Task<Order> UpdateAsync(int id, OrderDTO orderDto)
        {
            Order existingOrder = await _repository.GetByIdAsync(id);
            if (existingOrder == null)
            {
                return null;
            }

            orderDto.Adapt(existingOrder);
            return await _repository.UpdateAsync(existingOrder);
        }
        public async Task<OrderDTO> GetByIdAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id);
            if (order == null)
            {
                return null;
            }

            return order.Adapt<OrderDTO>();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id);
            if (order == null)
            {
                return false;
            }

            await _repository.DeleteAsync(order);
            return true;
        }

    }
}
