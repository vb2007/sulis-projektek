using KobolduldozokLib.Helpers;

namespace KobolduldozokLib.Entities.Objects;

public class House : IEntity
{
    public string Name { get; } = "Ház";
    public CustomColors CustomColor { get; } = new("#808080"); //szürke
    public bool CanMove { get; } = false;
    public char DisplaySymbol { get; } = 'H';
    public Position Position { get; set; }

    public static CustomColors Color { get; } = new("#808080"); //szürke

    public House(Position position)
    {
        Position = position;
    }
}
