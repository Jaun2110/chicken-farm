using ChickenFarm.Application.Interfaces;
using ChickenFarm.Domain.Entities;
using ChickenFarm.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ChickenFarm.Infrastructure.Repositories;

public class FlockRepository(AppDbContext _context) : IFlockRepository
{
    public async Task<List<Flock>> GetAllAsync()
        => await _context.Flocks.ToListAsync();

    public async Task<Flock?> GetByIdAsync(int id)
        => await _context.Flocks.FindAsync(id);

    public async Task AddAsync(Flock flock)
    {
        _context.Flocks.Add(flock);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var flock = await _context.Flocks.FindAsync(id);
        if (flock is not null)
        {
            _context.Flocks.Remove(flock);
            await _context.SaveChangesAsync();
        }
    }
}