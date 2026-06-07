using ChickenFarm.Application.Interfaces;
using ChickenFarm.Domain.Entities;
using ChickenFarm.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ChickenFarm.Infrastructure.Repositories;

public class PaddockRepository(AppDbContext _context) : IPaddockRepository
{
    public async Task<List<Paddock>> GetAllAsync()
        => await _context.Paddocks.ToListAsync();

    public async Task AddAsync(Paddock paddock)
    {
        _context.Paddocks.Add(paddock);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var paddock = await _context.Paddocks.FindAsync(id);
        if (paddock is not null)
        {
            _context.Paddocks.Remove(paddock);
            await _context.SaveChangesAsync();
        }
    }
}