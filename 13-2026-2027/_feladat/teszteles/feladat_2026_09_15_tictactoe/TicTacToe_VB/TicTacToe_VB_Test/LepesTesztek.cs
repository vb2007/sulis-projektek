using TicTacToe_VB_Lib;

namespace TicTacToe_VB_Test
{
    internal class LepesTesztek
    {
        [Test]
        public void LepesParser_HelyesBemenetFeldolgozhato()
        {
            bool jo = LepesParser.LepesFeldolgozas("2-3", out int sor, out int oszlop);

            Assert.That(jo, Is.True);
            Assert.That(sor, Is.EqualTo(2));
            Assert.That(oszlop, Is.EqualTo(1));
        }

        [Test]
        public void LepesParser_HibasBemenetSikertelen()
        {
            bool jo = LepesParser.LepesFeldolgozas("abc", out int sor, out int oszlop);

            Assert.That(jo, Is.False);
            Assert.That(sor, Is.EqualTo(-1));
            Assert.That(oszlop, Is.EqualTo(-1));
        }
    }
}
