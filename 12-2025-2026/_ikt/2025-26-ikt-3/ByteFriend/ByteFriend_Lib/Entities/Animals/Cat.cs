namespace ByteFriend_Lib.Entities.Animals;

public class Cat : AnimalBase
{
    public override string TypeName => "Macska";

    public override string[] AsciiArt =>
    [
        " /\\_/\\",
        " ( o.o )",
        " > ^ <"
    ];

    public override List<(string name, Action<IAnimal> action)> GetInteractions()
    {
        return
        [
            ("Simogatás", a =>
            {
                ModifyHappiness(a, 20);
                ModifyHunger(a, 3);
            }),
            ("Szőr kefélése", a =>
            {
                ModifyHappiness(a, 10);
                a.IsHealthy = true;
            })
        ];
    }
}