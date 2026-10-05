using TicTacToe_VB_Lib;

namespace TicTacToe_VB_Test
{
    internal class TablaTesztek
    {
        [Test]
        public void UresCellaraIrasSikeres()
        {
            Tabla tabla = new Tabla();

            bool siker = tabla.Iras(1, 1, 'X');

            Assert.That(siker, Is.True);
            Assert.That(tabla.Cella(1, 1), Is.EqualTo('X'));
        }

        [Test]
        public void FoglaltCellaraIrasSikertelen()
        {
            Tabla tabla = new Tabla();
            tabla.Iras(1, 1, 'X');

            bool siker = tabla.Iras(1, 1, 'O');

            Assert.That(siker, Is.False);
            Assert.That(tabla.Cella(1, 1), Is.EqualTo('X'));
        }

        [Test]
        public void SorKitalalasaMukodik()
        {
            Tabla tabla = new Tabla();
            tabla.Iras(0, 0, 'X');
            tabla.Iras(0, 1, 'X');
            tabla.Iras(0, 2, 'X');

            bool nyertes = GyoztesCheck.VanNyertes(tabla, 'X');

            Assert.That(nyertes, Is.True);
        }

        [Test]
        public void TablaSzovegetAdVissza()
        {
            Matrix jatek = new Matrix();
            jatek.Lepes(0, 0);

            string rajz = TablaMegjelenito.Kirajzol(jatek);

            Assert.That(rajz, Does.Contain(" X |"));
            Assert.That(rajz, Does.Contain("---+---+---"));
        }
    }
}
