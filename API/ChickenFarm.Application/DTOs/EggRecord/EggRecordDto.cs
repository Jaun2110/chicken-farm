using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChickenFarm.Application.DTOs.EggRecord
{
    public class EggRecordDto

    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public int Collected { get; set; }
        public int Sold { get; set; }
        public decimal PricePerDozen { get; set; }
        public string Customer { get; set; } = string.Empty;
        public decimal Revenue { get; set; }
    }
}