namespace ByteFriend_Lib.Entities;

public interface IAnimal
{
    string Name { get; set; }
    int Age { get; set; }
    bool IsHealthy { get; set; }
    int Hunger { get; set; }
    int Happiness { get; set; }
    LifeState State { get; set; }
    string TypeName { get; }
    string[] AsciiArt { get; }
    List<(string name, Action<IAnimal> action)> GetInteractions();
}