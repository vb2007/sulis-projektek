namespace RePontGame.Models.Items;

public class PocketKnife : IItem
{
    public Position Position { get; }
    public char Symbol => 'k';
    public ConsoleColor Color => ConsoleColor.Cyan;
    public string Name => "Zsebkés";

    public PocketKnife(Position position)
    {
        Position = position;
    }
}