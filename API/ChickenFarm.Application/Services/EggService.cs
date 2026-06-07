using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChickenFarm.Application.DTOs.EggRecord;
using ChickenFarm.Application.Interfaces;
using ChickenFarm.Domain.Entities;


namespace ChickenFarm.Application.Services
{
    public class EggService(IEggRepository _eggRepo)
    {
        public async Task<List<EggRecordDto>> GetAllAsync()
        {
            var eggs = await _eggRepo.GetAllAsync();
            return eggs.Select(MapToDto).ToList();
        }
        public async Task<EggRecordDto> CreateAsync(CreateEggRecordRequest request)
        {
            var egg = new EggRecord
            {
                Date = request.Date,
                Collected = request.Collected,
                Sold = request.Sold,
                PricePerDozen = request.PricePerDozen,
                Customer = request.Customer,
                Revenue = request.Sold / 12m * request.PricePerDozen
            };

            await _eggRepo.AddAsync(egg);
            return MapToDto(egg);
        }
        public async Task DeleteAsync(int id)
        {
            await _eggRepo.DeleteAsync(id);
        }
        private static EggRecordDto MapToDto(EggRecord e)
        {
            return new EggRecordDto
            {
                Id = e.Id,
                Date = e.Date,
                Collected = e.Collected,
                Sold = e.Sold,
                PricePerDozen = e.PricePerDozen,
                Customer = e.Customer,
                Revenue = e.Revenue
            };
        }
    }
}