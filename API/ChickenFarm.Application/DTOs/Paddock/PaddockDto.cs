using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChickenFarm.Application.DTOs.Paddock
{
    public class PaddockDto  {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly DateIn { get; set; }
        public DateOnly? DateOut { get; set; }
        public string Notes { get; set; } = string.Empty;
        public int RestDays { get; set; }
    }
}