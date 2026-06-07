using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChickenFarm.Application.DTOs
{
    public class DashboardDto
    {
        public int TotalBirds { get; set; }
        public int TotalEggsCollected { get; set; }
        public decimal TotalEggRevenue { get; set; }
        public int OpenOrders { get; set; }
        public string CycleAdvice { get; set; } = string.Empty;
    }
}