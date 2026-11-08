namespace Urhajok_VB_Lib;

public class Spaceship
{
    public string Name { get; set; }
    public SpaceshipType? Type { get; set; }
    public SpaceshipClass? Class { get; set; }
    public int? ManufacturedOnYear { get; set; }
    public int? Capacity { get; set; }
    public List<CrewMember> Crew { get; } = new List<CrewMember>();

    public bool Launchable
    {
        get
        {
            if (Type == null)
            {
                return false;
            }

            return Type.RequiredSkills.All(required =>
                Crew.SelectMany(member => member.Skills)
                    .Where(skill => skill.Name == required.Name)
                    .Sum(skill => skill.Level) >= required.Level);
        }
    }

    public Spaceship(string name, SpaceshipType type, SpaceshipClass @class, int manufacturedOnYear, int capacity)
    {
        Name = name;
        Type = type;
        Class = @class;
        ManufacturedOnYear = manufacturedOnYear;
        Capacity = capacity;
    }
}