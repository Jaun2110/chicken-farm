using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChickenFarm.Domain.Entities;

namespace ChickenFarm.Application.Interfaces
{
    public interface IFlockRepository
    {
        Task<List<Flock>> GetAllAsync();
        Task<Flock?> GetByIdAsync(int id);
        Task AddAsync(Flock flock);
        Task DeleteAsync(int id);
    }
}