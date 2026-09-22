using Hanoi_VB_Lib;

namespace Hanoi_VB_Test;

internal class MoveTests
{   
    HanoiGame _game = new HanoiGame(3);

    [Test]
    [Description("Mozoghat-e érvényes lépéssel?")]
    public void CanMoveWithValidSteps()
    {
        int fromRod = 0;
        int toRod = 1;
        bool outcome = _game.CanMove(fromRod, toRod);

        Assert.That(outcome, Is.EqualTo(true), "Érvényes lépésekkel engedélyeznie kéne a műveletet.");
    }

    [Test]
    [Description("Mozgathat-e érvénytelen lépéssel?")]
    public void CanMoveWithInvalidSteps()
    {
        int fromRod = 0;
        int toRod = 0;
        bool outcome = _game.CanMove(fromRod, toRod);

        Assert.That(outcome, Is.EqualTo(false), "Érvényes lépésekkel nem kéne engedélyeznie a műveletet.");
    }
}
