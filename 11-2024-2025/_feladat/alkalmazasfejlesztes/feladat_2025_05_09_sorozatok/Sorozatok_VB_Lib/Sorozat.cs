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

        public Sorozat(string adatSor)
        {
            string[] darabolt = adatSor.Split(';');

            Cim = darabolt[0];
            Rendezo = darabolt[1];
            Szarmazas = darabolt[2];
            KezdesEve = int.Parse(darabolt[3]);
            Kategoria = darabolt[4];
            Evadok = int.Parse(darabolt[5]);
        }

        public int RendezokSzama()
        {
            //if (string.IsNullOrWhiteSpace(Rendezo))
            //    return 0;

            return Rendezo.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Length;
        }

        public override string ToString()
        {
            return $"{Cim};{Rendezo};{Szarmazas};{KezdesEve};{Kategoria};{Evadok}";
        }
    }
}
