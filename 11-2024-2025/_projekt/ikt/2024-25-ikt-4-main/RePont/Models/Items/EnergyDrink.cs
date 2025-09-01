namespace RePontGame.Models.Items;

public class EnergyDrink : IItem
{
    public Position Position { get; }
    public char Symbol => 'E';
    public ConsoleColor Color => ConsoleColor.DarkYellow;
    public string Name => "Energiaital";

    public EnergyDrink(Position position)
    {
        Position = position;
    }
}