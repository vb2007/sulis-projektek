using ByteFriend_Lib.Entities;

namespace ByteFriend_Lib.Helpers;

public static class RandomEventManager
{
    private static readonly Random Rng = new();

    private const double SicknessChance = 0.15;
    private const double HungerSpikeChance = 0.20;

    public static string? ProcessRandomEvent(IAnimal animal)
    {
        double roll = Rng.NextDouble();

        if (roll < SicknessChance && animal.IsHealthy)
        {
            animal.IsHealthy = false;
            return $"{animal.Name} megbetegedett!";
        }

        if (roll < SicknessChance + HungerSpikeChance)
        {
            int spike = Rng.Next(10, 25);
            animal.Hunger = Math.Clamp(animal.Hunger + spike, 0, 100);
            return $"{animal.Name} nagyon megéhezett! (+{spike} éhség)";
        }

        return null;
    }
}

