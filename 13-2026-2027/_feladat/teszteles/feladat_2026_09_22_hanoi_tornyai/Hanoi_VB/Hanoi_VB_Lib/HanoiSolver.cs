namespace Hanoi_VB_Lib;

public static class HanoiSolver
{
    public static List<HanoiMove> Solve(HanoiGame game)
    {
        ArgumentNullException.ThrowIfNull(game);

        List<HanoiMove> moves = new List<HanoiMove>();
        SolveRecursive(game, game.DiskCount, 0, 2, 1, moves);
        return moves;
    }

    private static void SolveRecursive(HanoiGame game, int diskCount, int fromRod, int toRod, int helperRod, List<HanoiMove> moves)
    {
        if (diskCount == 0)
        {
            return;
        }

        SolveRecursive(game, diskCount - 1, fromRod, helperRod, toRod, moves);
        int movedDisk = game.Move(fromRod, toRod);
        moves.Add(new HanoiMove(fromRod, toRod, movedDisk));
        SolveRecursive(game, diskCount - 1, helperRod, toRod, fromRod, moves);
    }
}