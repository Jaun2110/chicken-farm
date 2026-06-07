using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChickenFarm.Domain.Entities
{
    public class Flock
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly ArrivalDate { get; set; }
        public int StartBirds { get; set; }
        public int CurrentBirds { get; set; }
        public string Breed { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}