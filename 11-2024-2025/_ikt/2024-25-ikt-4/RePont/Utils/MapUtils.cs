using RePontGame.Core;
using RePontGame.Models;

namespace RePontGame.Utils;

public static class MapUtils
{
    public static List<Position> GetAdjacentPositions(Position pos, Map map)
    {
        var positions = new List<Position>
        {
            pos with { Y = pos.Y - 1 }, pos with { Y = pos.Y + 1 },
            pos with { X = pos.X - 1 }, pos with { X = pos.X + 1 }
        };

        positions.RemoveAll(p => !map.IsWithinBounds(p));
        return positions;
    }
}