namespace ByteFriend_Lib.Entities;

public abstract class AnimalBase : IAnimal
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public bool IsHealthy { get; set; } = true;
    public int Hunger { get; set; }
    public int Happiness { get; set; } = 50;
    public LifeState State { get; set; } = LifeState.Child;
    public abstract string TypeName { get; }
    public abstract string[] AsciiArt { get; }
    public abstract List<(string name, Action<IAnimal> action)> GetInteractions();

    protected void ModifyHunger(IAnimal animal, int amount)
    {
        animal.Hunger = Math.Clamp(animal.Hunger + amount, 0, 100);
    }

    protected void ModifyHappiness(IAnimal animal, int amount)
    {
        animal.Happiness = Math.Clamp(animal.Happiness + amount, 0, 100);
    }
}
