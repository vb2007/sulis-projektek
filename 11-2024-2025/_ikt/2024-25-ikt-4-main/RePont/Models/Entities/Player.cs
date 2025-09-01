namespace RePontGame.Models.Entities;

public class Player : IEntity
{
    public Position Position { get; set; }
    public int BottlesCollected { get; internal set; } = 0;
    public bool HasKnife { get; internal set; } = false;
    public char Symbol => '@';
    public ConsoleColor Color => ConsoleColor.Yellow;

    public int TemporarySpeedBoostTurns { get; internal set; } = 0;

    public Player(Position startPosition)
    {
        Position = startPosition;
    }
}