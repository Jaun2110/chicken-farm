using ChickenFarm.Application.DTOs;
using ChickenFarm.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChickenFarm.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedController(FeedCalculatorService feedCalculatorService) : ControllerBase
{
    [HttpPost("calculate")]
    public IActionResult Calculate(FeedCalculationRequest request)
    {
        var result = feedCalculatorService.Calculate(request);
        return Ok(result);
    }
}