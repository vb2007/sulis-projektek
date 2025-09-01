namespace RePontGame.Models.Entities;

public interface IEntity
{
    Position Position { get; set; }
    char Symbol { get; }
    ConsoleColor Color { get; }
}