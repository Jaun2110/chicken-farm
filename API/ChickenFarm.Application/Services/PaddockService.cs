using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChickenFarm.Application.DTOs.Paddock;
using ChickenFarm.Application.Interfaces;
using ChickenFarm.Domain.Entities;

namespace ChickenFarm.Application.Services
{
    public class PaddockService(IPaddockRepository _paddockRepo)
    {
        public async Task<List<PaddockDto>> GetAllAsync()
        {
            var paddocks = await _paddockRepo.GetAllAsync();
            return paddocks.Select(MapToDto).ToList();
        }
        public async Task<PaddockDto> CreateAsync(CreatePaddockRequest request)
        {
            var paddock = new Paddock
            {
                Name = request.Name,
                DateIn = request.DateIn,
                DateOut = request.DateOut,
                Notes = request.Notes
            };

            await _paddockRepo.AddAsync(paddock);
            return MapToDto(paddock);
        }

        public async Task DeleteAsync(int id)
        {
            await _paddockRepo.DeleteAsync(id);
        }
        private static PaddockDto MapToDto(Paddock p)
        {
            var restDays = p.DateOut.HasValue
                ? Math.Max(0, (DateTime.Today - p.DateOut.Value.ToDateTime(TimeOnly.MinValue)).Days)
                : 0;

            return new PaddockDto
            {
                Id = p.Id,
                Name = p.Name,
                DateIn = p.DateIn,
                DateOut = p.DateOut,
                Notes = p.Notes,
                RestDays = restDays
            };
        }
    }
}