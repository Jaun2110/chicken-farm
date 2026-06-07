using ChickenFarm.Application.DTOs.EggRecord;
using ChickenFarm.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChickenFarm.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EggsController(EggService eggService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await eggService.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Create(CreateEggRecordRequest request)
    {
        var created = await eggService.CreateAsync(request);
        return Ok(created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await eggService.DeleteAsync(id);
        return NoContent();
    }
}