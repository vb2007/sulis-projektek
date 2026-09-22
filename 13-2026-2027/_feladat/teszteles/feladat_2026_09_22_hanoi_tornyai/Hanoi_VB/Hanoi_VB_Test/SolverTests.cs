using Hanoi_VB_Lib;

namespace Hanoi_VB_Test;

internal class SolverTests
{
    HanoiGame _game = null!;

    [SetUp]
    public void SetUp()
    {
        _game = new HanoiGame(3);
    }

    [Test]
    [Description("3 korong esetén 7 lépést kell adnia.")]
    public void SolveReturns7MovesFor3Disks()
    {
        var moves = HanoiSolver.Solve(_game);

        Assert.That(moves.Count, Is.EqualTo(7));
    }

    [Test]
    [Description("A megoldás után a játék kész állapotban van.")]
    public void SolveCompletesTheGame()
    {
        HanoiSolver.Solve(_game);

        Assert.That(_game.IsCompleted, Is.True);
    }

    [Test]
    [Description("3 korongnál az egyszerű elvárt lépéssor egyezzen.")]
    public void SolveReturnsExpectedMovesFor3Disks()
    {
        var expected = new List<HanoiMove>
        {
            new(0, 2, 1),
            new(0, 1, 2),
            new(2, 1, 1),
            new(0, 2, 3),
            new(1, 0, 1),
            new(1, 2, 2),
            new(0, 2, 1)
        };

        var actual = HanoiSolver.Solve(_game);

        Assert.That(actual, Is.EqualTo(expected));
    }
}