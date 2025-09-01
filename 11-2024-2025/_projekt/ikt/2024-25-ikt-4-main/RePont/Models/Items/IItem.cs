namespace RePontGame.Models.Items;

public interface IItem
{
    Position Position { get; }
    char Symbol { get; }
    ConsoleColor Color { get; }
    string Name { get; }
}