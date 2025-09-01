namespace RePontGame.Models.Items;

public class Bottle : IItem
{
    public Position Position { get; }
    public char Symbol => 'b';
    public ConsoleColor Color => ConsoleColor.Green;
    public string Name => "50 Ft-os visszaváltós palack";

    public Bottle(Position position)
    {
        Position = position;
    }
}