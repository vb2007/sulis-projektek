using KobolduldozokLib.Helpers;

namespace KobolduldozokLib.Entities.Objects;

public class Coin : IEntity
{
    public string Name { get; } = "Aprópénz";
    public CustomColors CustomColor { get; } = new("#FFD700"); //arany
    public bool CanMove { get; } = false;
    public char DisplaySymbol { get; } = 'C';
    public Position Position { get; set; }

    public static CustomColors Color { get; } = new("#FFD700"); //arany

    public Coin(Position position)
    {
        Position = position;
    }
}
