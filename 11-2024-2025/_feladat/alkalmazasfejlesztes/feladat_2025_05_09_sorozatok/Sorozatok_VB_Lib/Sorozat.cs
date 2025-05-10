namespace Sorozatok_VB_Lib
{
    public class Sorozat
    {
        //cim;rendezo;szarmazas;kezdesEve;kategoria;evadok
        public string Cim { get; init; }
        public string Rendezo { get; init; }
        public string Szarmazas { get; init; }
        public int KezdesEve { get; init; }
        public string Kategoria { get; init; }
        public int Evadok { get; init; }

        public Sorozat(string sor)
        {
            string[] adatok = sor.Split(';');

            Cim = adatok[0];
            Rendezo = adatok[1];
            Szarmazas = adatok[2];
            KezdesEve = int.Parse(adatok[3]);
            Kategoria = adatok[4];
            Evadok = int.Parse(adatok[5]);
        }
    }
}
