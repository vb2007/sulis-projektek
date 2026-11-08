namespace Urhajok_VB_Lib;

public class Skill
{
    public string Name { get; set; }
    public int Level { get; set; }

    public Skill(string name, int level)
    {
        Name = name;
        Level = level;
    }
}