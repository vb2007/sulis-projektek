namespace ByteFriend_Lib.Entities;

public class SaveData
{
    public string Name { get; init; } = string.Empty;
    public string TypeName { get; init; } = string.Empty;
    public int Age { get; init; }
    public bool IsHealthy { get; init; } = true;
    public int Hunger { get; init; }
    public int Happiness { get; init; } = 50;
    public LifeState State { get; init; } = LifeState.Child;
    public bool AquariumSmashed { get; set; }
    public DateTime CloseTime { get; init; } = DateTime.UtcNow;
}
