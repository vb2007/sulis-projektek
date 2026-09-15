using TicTacToe_VB_Lib;

namespace TicTacToe_VB_Test
{
    public class TicTacToeTests
    {
        [Test]
        public void UresTablavalKezdodoJatek()
        {
            var game = new Matrix();

            Assert.That(game.AktivJatekos, Is.EqualTo('X'));
            Assert.That(game.Cella(0, 0), Is.EqualTo(' '));
            Assert.That(game.JatekVege, Is.False);
        }

        [Test]
        public void ErvenyesLepesJatekostValt()
        {
            var game = new Matrix();

            var moved = game.Lepes(0, 0);

            Assert.That(moved, Is.True);
            Assert.That(game.Cella(0, 0), Is.EqualTo('X'));
            Assert.That(game.AktivJatekos, Is.EqualTo('O'));
        }

        [Test]
        public void HaromEgysorbanXNyer()
        {
            var game = new Matrix();

            game.Lepes(0, 0); //x
            game.Lepes(1, 0); //o
            game.Lepes(0, 1); //x
            game.Lepes(1, 1); //o
            game.Lepes(0, 2); //x nyer

            Assert.That(game.JatekVege, Is.True);
            Assert.That(game.Nyertes, Is.EqualTo('X'));
        }
    }
}
