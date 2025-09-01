namespace RePontGame.Models;

public class RePont
{
    public Position Position { get; }
    public char Symbol => 'R';
    public ConsoleColor Color => ConsoleColor.Magenta;

    public RePont(Position position)
    {
        Position = position;
    }
}