using TicTacToe_VB_Lib;

namespace TicTacToe_VB_Test
{
    public class MatrixTesztek
    {
        [Test]
        public void UresTablavalKezdodoJatek()
        {
            Matrix jatek = new Matrix();

            Assert.That(jatek.AktivJatekos, Is.EqualTo('X'));
            Assert.That(jatek.Cella(0, 0), Is.EqualTo(' '));
            Assert.That(jatek.JatekVege, Is.False);
        }

        [Test]
        public void ErvenyesLepesJatekostValt()
        {
            Matrix jatek = new Matrix();

            bool lepett = jatek.Lepes(0, 0);

            Assert.That(lepett, Is.True);
            Assert.That(jatek.Cella(0, 0), Is.EqualTo('X'));
            Assert.That(jatek.AktivJatekos, Is.EqualTo('O'));
        }

        [Test]
        public void HaromEgysorbanXNyer()
        {
            Matrix jatek = new Matrix();

            jatek.Lepes(0, 0); //x
            jatek.Lepes(1, 0); //o
            jatek.Lepes(0, 1); //x
            jatek.Lepes(1, 1); //o
            jatek.Lepes(0, 2); //x nyer

            Assert.That(jatek.JatekVege, Is.True);
            Assert.That(jatek.Nyertes, Is.EqualTo('X'));
        }
    }
}
