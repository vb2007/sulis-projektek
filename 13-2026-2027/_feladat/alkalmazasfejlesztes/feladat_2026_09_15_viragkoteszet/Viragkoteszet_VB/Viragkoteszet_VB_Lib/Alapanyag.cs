namespace Viragkoteszet_VB_Lib
{
    internal class Alapanyag
    {
        public string Azonosito { get; set; }
        public string Nev { get; set; }
        public int Ar { get; set; }
        public int ElkeszitesiIdo { get; set; }

        public Alapanyag(string adatSor)
        {
            string[] adatok = adatSor.Split(';');

            Azonosito = adatok[0];
            Nev = adatok[1];
            Ar = int.Parse(adatok[2]);
            ElkeszitesiIdo = int.Parse(adatok[3]);
        }
    }
}
