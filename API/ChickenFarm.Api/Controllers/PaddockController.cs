using ChickenFarm.Application.DTOs.Paddock;
using ChickenFarm.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChickenFarm.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaddocksController(PaddockService paddockService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await paddockService.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Create(CreatePaddockRequest request)
    {
        var created = await paddockService.CreateAsync(request);
        return Ok(created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await paddockService.DeleteAsync(id);
        return NoContent();
    }
}