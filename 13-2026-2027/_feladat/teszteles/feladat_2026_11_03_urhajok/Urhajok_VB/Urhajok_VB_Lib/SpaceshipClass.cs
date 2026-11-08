namespace Urhajok_VB_Lib;

public class SpaceshipClass
{
    public string Name { get; set; }

    public SpaceshipClass(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name;
    }
}