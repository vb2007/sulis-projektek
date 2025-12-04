using KobolduldozokLib.Helpers;

namespace KobolduldozokLib.Entities.Characters;

public class Angel : IEntity
{
    public string Name { get; } = "Angyal";
    public CustomColors CustomColor { get; } = new("#00FF00"); //zöld
    public bool CanMove { get; } = true;
    public char DisplaySymbol { get; } = 'A';
    public Position Position { get; set; }
    public bool IsActive { get; set; } = false; //true, ha elérnek egy házat

    public static CustomColors Color { get; } = new("#00FF00"); //zöld

    public Angel(Position position)
    {
        Position = position;
    }

    public void MoveTo(Position newPosition)
    {
        Position = newPosition;
    }

    public void Activate()
    {
        IsActive = true;
    }
}
