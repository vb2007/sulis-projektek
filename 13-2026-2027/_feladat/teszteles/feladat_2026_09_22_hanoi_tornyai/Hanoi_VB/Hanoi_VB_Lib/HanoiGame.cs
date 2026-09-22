namespace Hanoi_VB_Lib;

public class HanoiGame
{
    private readonly Stack<int>[] _rods =
    [
        new Stack<int>(),
        new Stack<int>(),
        new Stack<int>()
    ];

    public HanoiGame(int diskCount)
    {
        if (diskCount < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(diskCount), "Disk count must be at least 1.");
        }

        DiskCount = diskCount;

        for (var disk = diskCount; disk >= 1; disk--)
        {
            _rods[0].Push(disk);
        }
    }

    public int DiskCount { get; }

    public bool IsCompleted => _rods[2].Count == DiskCount;

    public bool CanMove(int fromRod, int toRod)
    {
        ValidateRodIndex(fromRod);
        ValidateRodIndex(toRod);

        if (fromRod == toRod || _rods[fromRod].Count == 0)
        {
            return false;
        }

        if (_rods[toRod].Count == 0)
        {
            return true;
        }

        return _rods[fromRod].Peek() < _rods[toRod].Peek();
    }

    public int Move(int fromRod, int toRod)
    {
        if (!CanMove(fromRod, toRod))
        {
            throw new InvalidOperationException("Érvénytelen lépés.");
        }

        var disk = _rods[fromRod].Pop();
        _rods[toRod].Push(disk);
        return disk;
    }

    public IReadOnlyList<int> GetRodDisks(int rodIndex)
    {
        ValidateRodIndex(rodIndex);
        return _rods[rodIndex].Reverse().ToArray();
    }

    private static void ValidateRodIndex(int rodIndex)
    {
        if (rodIndex is < 0 or > 2)
        {
            throw new ArgumentOutOfRangeException(nameof(rodIndex), "Rod index must be between 0 and 2.");
        }
    }
}