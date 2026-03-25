using ByteFriend_Lib.Entities;

namespace ByteFriend_Lib.Helpers;

public static class TimeManager
{
    private const int HungerPerHour = 5;
    private const int HappinessLossPerHour = 3;
    private const int AgePerHour = 1;

    private const int ChildMaxAge = 24;
    private const int AdultMaxAge = 72;
    private const int ElderMaxAge = 120;

    public static void ApplyElapsedTime(IAnimal animal, DateTime closeTime)
    {
        double elapsedHours = (DateTime.UtcNow - closeTime).TotalHours;
        if (elapsedHours <= 0) return;

        int hours = (int)Math.Floor(elapsedHours);

        animal.Hunger = Math.Clamp(animal.Hunger + hours * HungerPerHour, 0, 100);
        animal.Happiness = Math.Clamp(animal.Happiness - hours * HappinessLossPerHour, 0, 100);
        animal.Age += hours * AgePerHour;

        if (animal.IsHealthy && hours >= 6)
        {
            animal.IsHealthy = false;
        }

        UpdateLifeState(animal);
    }

    public static void Tick(IAnimal animal)
    {
        animal.Hunger = Math.Clamp(animal.Hunger + 2, 0, 100);
        animal.Happiness = Math.Clamp(animal.Happiness - 1, 0, 100);
        animal.Age++;

        UpdateLifeState(animal);
    }

    private static void UpdateLifeState(IAnimal animal)
    {
        animal.State = animal.Age switch
        {
            < ChildMaxAge => LifeState.Child,
            < AdultMaxAge => LifeState.Adult,
            _ => LifeState.Elder
        };
    }

    public static bool IsNaturalDeath(IAnimal animal)
    {
        //return animal.State == LifeState.Elder && animal.Age >= ElderMaxAge;
        return animal is { State: LifeState.Elder, Age: >= ElderMaxAge };
    }

    public static bool IsStarvationDeath(IAnimal animal)
    {
        return animal.Hunger >= 100;
    }

    public static string GetStateName(LifeState state)
    {
        return state switch
        {
            LifeState.Child => "Gyerek",
            LifeState.Adult => "Felnőtt",
            LifeState.Elder => "Idős",
            _ => "Ismeretlen"
        };
    }
}


