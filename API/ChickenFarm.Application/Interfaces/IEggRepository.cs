using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChickenFarm.Domain.Entities;


namespace ChickenFarm.Application.Interfaces
{
    public interface IEggRepository
    {
        Task<List<EggRecord>> GetAllAsync();
        Task AddAsync(EggRecord egg);
        Task DeleteAsync(int id);
    }
}