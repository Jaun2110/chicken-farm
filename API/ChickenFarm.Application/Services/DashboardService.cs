using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChickenFarm.Application.DTOs;
using ChickenFarm.Application.Interfaces;
using ChickenFarm.Domain.Entities;
using ChickenFarm.Domain.Enums;

namespace ChickenFarm.Application.Services
{
    public class DashboardService(
        IFlockRepository _flockRepo,
        IEggRepository _eggRepo,
        IOrderRepository _orderRepo
    )
    {
        public async Task<DashboardDto> GetAsync()
        {
            var flocks = await _flockRepo.GetAllAsync();
            var eggs = await _eggRepo.GetAllAsync();
            var orders = await _orderRepo.GetAllAsync();

            var totalBirds = flocks.Sum(f => f.CurrentBirds);
            var totalEggs = eggs.Sum(e => e.Collected);
            var totalRevenue = eggs.Sum(e => e.Revenue);
            var openOrders = orders.Count(o => o.Status == OrderStatus.Open);
            var firstFlock = flocks.OrderBy(f => f.ArrivalDate).FirstOrDefault();
            var cycleAdvice = BuildCycleAdvice(firstFlock);
            return new DashboardDto
            {
                TotalBirds = totalBirds,
                TotalEggsCollected = totalEggs,
                TotalEggRevenue = totalRevenue,
                OpenOrders = openOrders,
                CycleAdvice = cycleAdvice
            };
        }

        private static string BuildCycleAdvice(Flock? flock)
        {
            if (flock is null)
                return "Add your first flock to see age-based guidance.";

            var ageWeeks = (DateTime.Today - flock.ArrivalDate.ToDateTime(TimeOnly.MinValue)).Days / 7;
            var stage = ageWeeks switch
            {
                < 4 => "Brooder",
                < 20 => "Grower / Tractor",
                <= 80 => "Laying",
                _ => "Sell hens / Replace flock"
            };

            var tip = (ageWeeks >= 20 && ageWeeks <= 80)
                ? "Track laying percentage: eggs collected ÷ hens × 100."
                : "Follow the raising schedule and prepare for laying at week 20.";

            return $"Main flock is {ageWeeks} weeks old. Stage: {stage}. {tip}";
        }
    }
}