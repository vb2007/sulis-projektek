using Hanoi_VB_Lib;

namespace Hanoi_VB_Test;

internal class MoveTests
{   
    HanoiGame _game = new HanoiGame(3);

    [Test]
    [Description("Mozoghat-e érvényes lépéssel?")]
    public void CanMoveFrom0To1()
    {
        int fromRod = 0;
        int toRod = 1;
        bool outcome = _game.CanMove(fromRod, toRod);

        Assert.That(outcome, Is.EqualTo(true), "Érvényes lépésekkel engedélyeznie kéne a műveletet.");
    }

    [Test]
    [Description("Mozoghat-e érvényes lépéssel?")]
    public void CanMoveFrom0To2()
    {
        int fromRod = 0;
        int toRod = 1;
        bool outcome = _game.CanMove(fromRod, toRod);

        Assert.That(outcome, Is.EqualTo(true), "Érvényes lépésekkel engedélyeznie kéne a műveletet.");
    }

    [Test]
    [Description("Mozoghat-e érvényes lépéssel?")]
    public void CanMoveFrom0To3()
    {
        int fromRod = 0;
        int toRod = 1;
        bool outcome = _game.CanMove(fromRod, toRod);

        Assert.That(outcome, Is.EqualTo(true), "Érvényes lépésekkel engedélyeznie kéne a műveletet.");
    }

    [Test]
    [Description("Mozgathat-e érvénytelen lépéssel?")]
    public void CantMoveFrom0To0()
    {
        int fromRod = 0;
        int toRod = 0;
        bool outcome = _game.CanMove(fromRod, toRod);

        Assert.That(outcome, Is.EqualTo(false), "Érvényes lépésekkel nem kéne engedélyeznie a műveletet.");
    }

    [Test]
    [Description("Mozgathat-e érvénytelen lépéssel?")]
    public void CantMoveFrom0ToMinus1()
    {
        int fromRod = 0;
        int toRod = -1;
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            _game.CanMove(fromRod, toRod),
            "Érvénytelen rúd index esetén kivételt kell dobnia."
        );
    }

    [Test]
    [Description("Mozgathat-e érvénytelen lépéssel?")]
    public void CantMoveFromMinus1To0()
    {
        int fromRod = -1;
        int toRod = 0;
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            _game.CanMove(fromRod, toRod),
            "Érvénytelen rúd index esetén kivételt kell dobnia."
        );
    }
}
