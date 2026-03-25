namespace ByteFriend_Lib.Entities.Animals;

public class Goldfish : AnimalBase
{
    public bool AquariumSmashed { get; set; }

    public override string TypeName => "Aranyhal";

    public override string[] AsciiArt =>
    [
        "  ;,//;,    ,;/",
        " o:::::::;;///",
        ">::::::::;;\\\\\\",
        "  ''\\\\\\\\\\'\" ';\\"
    ];

    public override List<(string name, Action<IAnimal> action)> GetInteractions()
    {
        return
        [
            ("Akvárium takarítása", a =>
            {
                ModifyHappiness(a, 15);
                ModifyHunger(a, 3);
            }),
            ("Akvárium földhöz vágása", a =>
            {
                if (a is Goldfish hal)
                {
                    hal.AquariumSmashed = true;
                }
            })
        ];
    }
}