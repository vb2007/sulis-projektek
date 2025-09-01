using RePontGame.Models;

namespace RePontGame.Core;

public class Map
{
    public int Width { get; }
    public int Height { get; }

    public Map(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public bool IsWithinBounds(Position pos)
    {
        return pos.X >= 0 && pos.X < Width && pos.Y >= 0 && pos.Y < Height;
    }
}