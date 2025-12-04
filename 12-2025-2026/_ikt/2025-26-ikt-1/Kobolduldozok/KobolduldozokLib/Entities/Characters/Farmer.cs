using KobolduldozokLib.Helpers;

namespace KobolduldozokLib.Entities.Characters;

internal class Farmer : IEntity
{
    public string Name { get; } = "Paraszt";
    public CustomColors CustomColor { get; } = new("#FFFF00"); //citromsárga
    public bool CanMove { get; } = true;
    public char DisplaySymbol { get; } = 'P';
    public Position Position { get; set; }

    public Farmer(Position position)
    {
        Position = position;
    }
}
