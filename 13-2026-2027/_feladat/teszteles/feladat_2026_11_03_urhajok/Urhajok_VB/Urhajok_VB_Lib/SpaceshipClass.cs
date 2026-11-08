namespace Urhajok_VB_Lib;

public class SpaceshipClass
{
    public string Name { get; set; }

    public SpaceshipClass(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Az osztály nevének megadása kötelező.", nameof(name));
        }

        Name = name;
    }
}