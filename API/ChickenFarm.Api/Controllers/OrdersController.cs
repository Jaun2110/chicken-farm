using ChickenFarm.Application.DTOs.Order;
using ChickenFarm.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChickenFarm.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController(OrderService orderService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await orderService.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderRequest request)
    {
        var created = await orderService.CreateAsync(request);
        return Ok(created);
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id, UpdateOrderStatusRequest request)
    {
        var updated = await orderService.UpdateStatusAsync(id, request);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await orderService.DeleteAsync(id);
        return NoContent();
    }
}