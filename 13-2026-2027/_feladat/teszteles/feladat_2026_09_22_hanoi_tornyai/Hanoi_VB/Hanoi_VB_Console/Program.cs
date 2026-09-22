using Hanoi_VB_Lib;

namespace Hanoi_VB_Console;

internal class Program
{
    static void Main(string[] args)
    {
        int diskCount = ReadDiskCount(args);
        HanoiGame game = new HanoiGame(diskCount);
        List<HanoiMove> moves = HanoiSolver.Solve(game);

        Console.WriteLine($"Lépések: {moves.Count}");
        foreach (HanoiMove move in moves)
        {
            Console.WriteLine($"{move.Disk}: {move.FromRod} -> {move.ToRod}");
        }

        Console.WriteLine(game.IsCompleted ? "Kész" : "Nincs kész");
    }

    private static int ReadDiskCount(string[] args)
    {
        if (args.Length > 0 && int.TryParse(args[0], out int value) && value >= 1)
        {
            return value;
        }

        while (true)
        {
            Console.Write("Korongok száma (>=1): ");
            string input = Console.ReadLine()!;
            if (int.TryParse(input, out value) && value >= 1)
            {
                return value;
            }
        }
    }
}
