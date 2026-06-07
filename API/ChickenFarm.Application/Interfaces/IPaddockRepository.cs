using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChickenFarm.Domain.Entities;

namespace ChickenFarm.Application.Interfaces
{
    public interface IPaddockRepository
    {
        Task<List<Paddock>> GetAllAsync();
        Task AddAsync(Paddock paddock);
        Task DeleteAsync(int id);
    }
}