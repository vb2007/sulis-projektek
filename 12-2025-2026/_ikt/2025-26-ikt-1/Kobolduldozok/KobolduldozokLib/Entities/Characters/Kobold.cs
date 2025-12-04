using KobolduldozokLib.Helpers;

namespace KobolduldozokLib.Entities.Characters;

public class Kobold : IEntity
{
    public string Name { get; } = "Barna Kobold";
    public CustomColors CustomColor { get; } = new("#8B4513"); //barna
    public bool CanMove { get; } = true;
    public char DisplaySymbol { get; } = 'K';
    public Position Position { get; set; }
    public static int CoinsCollected { get; set; } = 0;

    public static CustomColors Color { get; } = new("#8B4513"); //barna

    public Kobold(Position position)
    {
        Position = position;
    }

    public void MoveTo(Position newPosition)
    {
        Position = newPosition;
    }
}
