namespace Urhajok_VB_Lib;

public class Spaceship
{
    public string Name { get; set; }
    public string? Type { get; set; }
    public string? Class { get; set; }
    public int? ManufacturedOnYear { get; set; }
    public int? Capacity { get; set; }

    public Spaceship(string name, string type, string @class, int manufacturedOnYear, int capacity)
    {
        Name = name;
        Type = type;
        Class = @class;
        ManufacturedOnYear = manufacturedOnYear;
        Capacity = capacity;
    }
}