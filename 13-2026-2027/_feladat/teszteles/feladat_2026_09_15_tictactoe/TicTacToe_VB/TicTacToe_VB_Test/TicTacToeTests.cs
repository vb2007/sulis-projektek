using TicTacToe_VB_Lib;

namespace TicTacToe_VB_Test
{
    internal class TicTacToeTests
    {
        [Test]
        public void UresTablaXelKezdodik()
        {
            TicTacToeGame game = new TicTacToeGame();

            Assert.That(game.CurrentPlayer, Is.EqualTo('X'));
            Assert.That(game.GetCell(0, 0), Is.EqualTo(' '));
            Assert.That(game.GetCell(1, 1), Is.EqualTo(' '));
            Assert.That(game.GetCell(2, 2), Is.EqualTo(' '));
            Assert.That(game.IsGameOver, Is.False);
        }
    }
}
