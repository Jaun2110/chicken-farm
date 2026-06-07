using ChickenFarm.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChickenFarm.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController(DashboardService dashboardService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
        => Ok(await dashboardService.GetAsync());
}