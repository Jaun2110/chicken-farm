using ChickenFarm.Application.DTOs.Flock;
using ChickenFarm.Application.Interfaces;
using ChickenFarm.Domain.Entities;

namespace ChickenFarm.Application.Services
{
    public class FlockService(IFlockRepository _flockRepo)
    {
        public async Task<List<FlockDto>> GetAllAsync()
        {
            var flocks = await _flockRepo.GetAllAsync();
            return flocks
            .Select(MapToDto)
            .ToList();
        }
        public async Task<FlockDto?> GetByIdAsync(int id)
        {
            var flock = await _flockRepo.GetByIdAsync(id);
            return flock is null ? null : MapToDto(flock);
        }
        public async Task<FlockDto> CreateAsync(CreateFlockRequest request)
        {
            var flock = new Flock
            {
                Name = request.Name,
                ArrivalDate = request.ArrivalDate,
                StartBirds = request.StartBirds,
                CurrentBirds = request.CurrentBirds,
                Breed = request.Breed,
                Notes = request.Notes
            };

            await _flockRepo.AddAsync(flock);
            return MapToDto(flock);
        }
        public async Task DeleteAsync(int id)
        {
            await _flockRepo.DeleteAsync(id);
        }


        private FlockDto MapToDto(Flock f)
        {
            var ageWeeks = (DateTime.Today - f.ArrivalDate.ToDateTime(TimeOnly.MinValue)).Days / 7;
            return new FlockDto
            {
                Id = f.Id,
                Name = f.Name,
                ArrivalDate = f.ArrivalDate,
                StartBirds = f.StartBirds,
                CurrentBirds = f.CurrentBirds,
                Breed = f.Breed,
                Notes = f.Notes,
                AgeWeeks = ageWeeks,
                Stage = GetStage(ageWeeks)
            };
        }


        private static string GetStage(int weeks) => weeks switch
        {
            < 4 => "Brooder",
            < 20 => "Grower/ Tractor",
            <= 80 => "Laying",
            _ => "Sell hens / Replace flock"
        };
    }
}