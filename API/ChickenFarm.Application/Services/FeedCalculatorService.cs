using ChickenFarm.Application.DTOs;

namespace ChickenFarm.Application.Services;

public class FeedCalculatorService
{
    private static readonly Dictionary<string, Dictionary<string, decimal>> _mixes = new()
    {
        ["Starter"] = new()
        {
            ["Maize"] = 45,
            ["Soybean meal"] = 30,
            ["Wheat bran"] = 10,
            ["Fish meal / high protein source"] = 10,
            ["Premix + lime + salt"] = 5
        },
        ["Grower"] = new()
        {
            ["Maize"] = 50,
            ["Soybean meal"] = 22,
            ["Wheat bran"] = 20,
            ["Sunflower oilcake"] = 5,
            ["Premix + lime + salt"] = 3
        },
        ["Layer"] = new()
        {
            ["Maize"] = 45,
            ["Soybean meal"] = 20,
            ["Wheat bran"] = 15,
            ["Limestone / shell grit"] = 15,
            ["Premix + salt"] = 5
        }
    };

    public FeedCalculationResult Calculate(FeedCalculationRequest request)
    {
        if (!_mixes.TryGetValue(request.FeedType, out var mix))
            throw new ArgumentException($"Unknown feed type: {request.FeedType}");

        var ingredients = mix.Select(kvp => new FeedIngredient
        {
            Name = kvp.Key,
            Percentage = kvp.Value,
            Kg = Math.Round(request.TotalKg * kvp.Value / 100, 1)
        }).ToList();

        return new FeedCalculationResult
        {
            FeedType = request.FeedType,
            TotalKg = request.TotalKg,
            Ingredients = ingredients
        };
    }
}