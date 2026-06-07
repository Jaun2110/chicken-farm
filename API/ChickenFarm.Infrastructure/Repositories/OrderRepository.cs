using ChickenFarm.Application.Interfaces;
using ChickenFarm.Domain.Entities;
using ChickenFarm.Domain.Enums;
using ChickenFarm.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ChickenFarm.Infrastructure.Repositories;

public class OrderRepository(AppDbContext _context) : IOrderRepository
{
    public async Task<List<Order>> GetAllAsync()
        => await _context.Orders.ToListAsync();

    public async Task<Order?> GetByIdAsync(int id)
        => await _context.Orders.FindAsync(id);

    public async Task AddAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateStatusAsync(int id, OrderStatus status)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order is not null)
        {
            order.Status = status;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order is not null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}