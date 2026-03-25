namespace ByteFriend_Lib.Entities.Animals;

public class Monkey : AnimalBase
{
    public override string TypeName => "Majom";

    public override string[] AsciiArt =>
    [
        "  /~\\",
        " C oo",
        " _( ^)",
        "/   ~\\"
    ];

    public override List<(string name, Action<IAnimal> action)> GetInteractions()
    {
        return
        [
            ("Etetés (banán)", a =>
            {
                ModifyHunger(a, -25);
                ModifyHappiness(a, 5);
            }),
            ("Barátkozás", a =>
            {
                ModifyHappiness(a, 20);
                ModifyHunger(a, 5);
            })
        ];
    }
}