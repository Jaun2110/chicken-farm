using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChickenFarm.Application.DTOs
{
    public class FeedCalculationResult
    {
        public string FeedType { get; set; } = string.Empty;
        public decimal TotalKg { get; set; }
        public List<FeedIngredient> Ingredients { get; set; } = new();
    }
    public class FeedIngredient
    {
        public string Name { get; set; } = string.Empty;
        public decimal Percentage { get; set; }
        public decimal Kg { get; set; }
    }
}