using Urhajok_VB_Lib;

namespace Urhajok_VB_Console;

class Program
{
    static void Main(string[] args)
    {
        SpaceshipType type = new SpaceshipType("Explorer", "Deep space exploration", new List<Skill> { new Skill("Piloting", 5) });
        Spaceship ship = new Spaceship("Voyager", type, new SpaceshipClass("Alpha"), 2150, 2);

        CrewMember anna = new CrewMember("Anna", "Hungarian", new DateTime(1990, 5, 1), "F", new List<Skill> { new Skill("Piloting", 3) });
        CrewMember bob = new CrewMember("Bob", "British", new DateTime(1985, 3, 12), "M", new List<Skill> { new Skill("Piloting", 2) });
        CrewMember cid = new CrewMember("Cid", "Spanish", new DateTime(1992, 7, 20), "M");

        SpaceCommand command = new SpaceCommand();
        command.Spaceships.Add(ship);
        command.FreeCrew.AddRange(new[] { anna, bob, cid });

        Console.WriteLine($"Indítható (üres legénység): {YesNo(ship.Launchable)}");

        Console.WriteLine($"Anna hozzárendelése: {YesNo(command.Assign(anna, ship))}");
        Console.WriteLine($"Indítható (Piloting 3/5): {YesNo(ship.Launchable)}");

        Console.WriteLine($"Bob hozzárendelése: {YesNo(command.Assign(bob, ship))}");
        Console.WriteLine($"Indítható (Piloting 5/5): {YesNo(ship.Launchable)}");

        Console.WriteLine($"Cid hozzárendelése (a hajó megtelt): {YesNo(command.Assign(cid, ship))}");

        Console.WriteLine($"Bob visszavonása: {YesNo(command.Unassign(bob))}");
        Console.WriteLine($"Indítható (Piloting 3/5): {YesNo(ship.Launchable)}");
        Console.WriteLine($"Szabad legénység: {string.Join(", ", command.FreeCrew.Select(c => c.Name))}");
    }

    static string YesNo(bool value) =>
        value ? "igen" : "nem";
}