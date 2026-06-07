using ChickenFarm.Application.Interfaces;
using ChickenFarm.Domain.Entities;
using ChickenFarm.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ChickenFarm.Infrastructure.Repositories;

public class EggRepository(AppDbContext _context) : IEggRepository
{
    public async Task<List<EggRecord>> GetAllAsync()
        => await _context.EggRecords.ToListAsync();

    public async Task AddAsync(EggRecord egg)
    {
        _context.EggRecords.Add(egg);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var egg = await _context.EggRecords.FindAsync(id);
        if (egg is not null)
        {
            _context.EggRecords.Remove(egg);
            await _context.SaveChangesAsync();
        }
    }
}