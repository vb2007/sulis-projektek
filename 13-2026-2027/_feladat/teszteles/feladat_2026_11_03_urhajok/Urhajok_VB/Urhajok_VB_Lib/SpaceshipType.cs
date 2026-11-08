namespace Urhajok_VB_Lib;

public class SpaceshipType
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Skill> RequiredSkills { get; set; }

    public SpaceshipType(string name, string description, List<Skill>? requiredSkills = null)
    {
        Name = name;
        Description = description;
        RequiredSkills = requiredSkills ?? new List<Skill>();
    }
}