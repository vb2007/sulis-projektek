using Hanoi_VB_Lib;

namespace Hanoi_VB_Test
{
    internal class MoveTests
    {
        [Test]
        [Description("Mozoghat-e érvényes lépésekkkel?")]
        public void CanMoveWithValidSteps()
        {
            HanoiGame game = new HanoiGame(3);

            int fromRod = 0;
            int toRod = 0;
            bool outcome = game.CanMove(fromRod, toRod);

            Assert.That(outcome, Is.EqualTo(false));
        }
    }
}
