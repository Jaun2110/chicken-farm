using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChickenFarm.Application.DTOs.Flock;
using ChickenFarm.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChickenFarm.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlocksController(FlockService flockService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await flockService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var flock = await flockService.GetByIdAsync(id);
            return flock is null ? NotFound() : Ok(flock);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFlockRequest request)
        {
            var created = await flockService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await flockService.DeleteAsync(id);
            return NoContent();
        }
    }
}