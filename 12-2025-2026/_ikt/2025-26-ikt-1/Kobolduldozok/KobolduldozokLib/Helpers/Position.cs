namespace KobolduldozokLib.Helpers;

public class Position
{
    public int X { get; set; }
    public int Y { get; set; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    private Position(Position other)
    {
        X = other.X;
        Y = other.Y;
    }

    public int ManhattanDistanceTo(Position other)
    {
        return Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
    }

    public override bool Equals(object? obj)
    {
        if (obj is Position other)
        {
            return X == other.X && Y == other.Y;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }

    public static bool operator ==(Position? a, Position? b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.Equals(b);
    }

    public static bool operator !=(Position? a, Position? b)
    {
        return !(a == b);
    }

    public static Position? FindPath(Position start, Position target, int maxX, int maxY, Func<Position, bool> isWalkable)
    {
        if (start == target) return null;

        Queue<Position> queue = new Queue<Position>();
        Dictionary<Position, Position?> cameFrom = new Dictionary<Position, Position?>();
        HashSet<Position> visited = new HashSet<Position>();

        queue.Enqueue(start);
        cameFrom[start] = null;
        visited.Add(start);

        while (queue.Count > 0)
        {
            Position current = queue.Dequeue();

            if (current == target)
            {
                Position step = current;
                while (cameFrom[step] != null && cameFrom[step] != start)
                {
                    step = cameFrom[step]!;
                }
                return step;
            }

            List<Position> neighbors = new List<Position>
            {
                new Position(current.X + 1, current.Y),
                new Position(current.X - 1, current.Y),
                new Position(current.X, current.Y + 1),
                new Position(current.X, current.Y - 1)
            };

            Random random = new Random(HashCode.Combine(current.X, current.Y, target.X, target.Y));
            neighbors = neighbors.OrderBy(n => random.Next()).ToList();

            foreach (var neighbor in neighbors)
            {
                if (neighbor.X < 0 || neighbor.X >= maxX || neighbor.Y < 0 || neighbor.Y >= maxY)
                    continue;

                if (visited.Contains(neighbor))
                    continue;

                if (isWalkable(neighbor) || neighbor == target)
                {
                    queue.Enqueue(neighbor);
                    cameFrom[neighbor] = current;
                    visited.Add(neighbor);
                }
            }
        }

        return GetGreedyStep(start, target);
    }

    private static Position GetGreedyStep(Position start, Position target)
    {
        Position nextPos = new Position(start);

        int dx = target.X - start.X;
        int dy = target.Y - start.Y;

        Random random = new Random(HashCode.Combine(start.X, start.Y, target.X, target.Y));
        bool preferX = random.Next(2) == 0;

        if (preferX && dx != 0)
            nextPos.X += Math.Sign(dx);
        else if (dy != 0)
            nextPos.Y += Math.Sign(dy);
        else if (dx != 0)
            nextPos.X += Math.Sign(dx);

        return nextPos;
    }
}
