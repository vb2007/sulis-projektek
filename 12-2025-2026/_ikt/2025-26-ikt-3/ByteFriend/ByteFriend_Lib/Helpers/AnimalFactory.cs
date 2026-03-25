using ByteFriend_Lib.Entities;
using ByteFriend_Lib.Entities.Animals;

namespace ByteFriend_Lib.Helpers;

public static class AnimalFactory
{
    public static IAnimal FromSaveData(SaveData data)
    {
        var allat = Create(data.TypeName);
        allat.Name = data.Name;
        allat.Age = data.Age;
        allat.IsHealthy = data.IsHealthy;
        allat.Hunger = data.Hunger;
        allat.Happiness = data.Happiness;
        allat.State = data.State;

        if (allat is Goldfish hal)
        {
            hal.AquariumSmashed = data.AquariumSmashed;
        }

        return allat;
    }

    public static SaveData ToSaveData(IAnimal animal)
    {
        var data = new SaveData
        {
            Name = animal.Name,
            TypeName = animal.TypeName,
            Age = animal.Age,
            IsHealthy = animal.IsHealthy,
            Hunger = animal.Hunger,
            Happiness = animal.Happiness,
            State = animal.State,
            CloseTime = DateTime.UtcNow
        };

        if (animal is Goldfish hal)
        {
            data.AquariumSmashed = hal.AquariumSmashed;
        }

        return data;
    }
    
    private static IAnimal Create(string tipusNev)
    {
        return tipusNev switch
        {
            "Majom" => new Monkey(),
            "Aranyhal" => new Goldfish(),
            "Macska" => new Cat(),
            _ => throw new InvalidOperationException($"Ismeretlen állat típus: {tipusNev}")
        };
    }
}
