using RePontGame.Models.Enums;

namespace RePontGame.Models.Entities;

public class Enemy : IEntity
{
    public Position Position { get; set; }
    public EnemyType Type { get; private set; }
    public char Symbol { get; private set; }
    public ConsoleColor Color { get; private set; }
    public string Name { get; private set; }

    public Enemy(Position position, EnemyType type)
    {
        Position = position;
        Type = type;
        SetPropertiesByType(type);
    }

    //enemies
    private void SetPropertiesByType(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Zsebes:
                Name = "Barna kobold";
                Symbol = 'C';
                Color = ConsoleColor.Red;
                break;
            case EnemyType.PamKutya:
                Name = "Pamkutya Béla";
                Symbol = 'K';
                Color = ConsoleColor.DarkYellow;
                break;
            case EnemyType.BiztonsagiOr:
                Name = "Westend tetős Biztonsági őr";
                Symbol = 'Ő';
                Color = ConsoleColor.DarkCyan;
                break;
            default:
                Name = "Ismeretlen ellenfél";
                Symbol = '?';
                Color = ConsoleColor.Gray;
                break;
        }
    }
}