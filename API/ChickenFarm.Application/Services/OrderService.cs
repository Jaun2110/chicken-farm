using ChickenFarm.Application.DTOs.Order;
using ChickenFarm.Application.Interfaces;
using ChickenFarm.Domain.Entities;
using ChickenFarm.Domain.Enums;

namespace ChickenFarm.Application.Services;

public class OrderService(IOrderRepository _orderRepo)
{
    public async Task<List<OrderDto>> GetAllAsync()
    {
        var orders = await _orderRepo.GetAllAsync();
        return orders.Select(MapToDto).ToList();
    }

    public async Task<OrderDto> CreateAsync(CreateOrderRequest request)
    {
        var order = new Order
        {
            Customer = request.Customer,
            Phone = request.Phone,
            DozensOrdered = request.DozensOrdered,
            PricePerDozen = request.PricePerDozen,
            DeliveryDate = request.DeliveryDate,
            Status = OrderStatus.Open
        };

        await _orderRepo.AddAsync(order);
        return MapToDto(order);
    }

    public async Task<OrderDto?> UpdateStatusAsync(int id, UpdateOrderStatusRequest request)
    {
        await _orderRepo.UpdateStatusAsync(id, request.Status);
        var order = await _orderRepo.GetByIdAsync(id);
        return order is null ? null : MapToDto(order);
    }

    public async Task DeleteAsync(int id)
    {
        await _orderRepo.DeleteAsync(id);
    }

    private static OrderDto MapToDto(Order o) => new()
    {
        Id = o.Id,
        Customer = o.Customer,
        Phone = o.Phone,
        DozensOrdered = o.DozensOrdered,
        PricePerDozen = o.PricePerDozen,
        Total = o.DozensOrdered * o.PricePerDozen,
        DeliveryDate = o.DeliveryDate,
        Status = o.Status
    };
}
