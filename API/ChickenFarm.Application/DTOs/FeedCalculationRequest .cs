using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChickenFarm.Application.DTOs
{
    public class FeedCalculationRequest
    {
        public string FeedType { get; set; } = string.Empty;
        public decimal TotalKg { get; set; }
    }
}