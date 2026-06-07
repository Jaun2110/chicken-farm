using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChickenFarm.Domain.Entities;
using ChickenFarm.Domain.Enums;

namespace ChickenFarm.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task AddAsync(Order order);
        Task UpdateStatusAsync(int id, OrderStatus status);
        Task DeleteAsync(int id);
    }
}