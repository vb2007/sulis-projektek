namespace Viragkoteszet_VB_Lib
{
    public class Alapanyag
    {
        public string Azonosito { get; }
        public string Nev { get; }
        public int Ar { get; }
        public int ElkeszitesiIdo { get; }

        public Alapanyag(string azonosito, string nev, int ar, int elkeszitesiIdo)
        {
            Azonosito = azonosito;
            Nev = nev;
            Ar = ar;
            ElkeszitesiIdo = elkeszitesiIdo;
        }
    }
}
