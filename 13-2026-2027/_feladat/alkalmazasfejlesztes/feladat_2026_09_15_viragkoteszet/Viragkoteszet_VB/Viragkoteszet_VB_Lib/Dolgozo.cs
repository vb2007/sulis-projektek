namespace Viragkoteszet_VB_Lib
{
    public abstract class Dolgozo
    {
        public int Id { get; }
        public string Nev { get; }
        public FeladatLista FeladatLista { get; protected set; } = new();

        // Nincs megvalósítás: a leszármazottak döntik el.
        public abstract double Gyakorlottsag { get; }
        public abstract int MunkaraForditottIdo { get; }

        protected Dolgozo(int id, string nev)
        {
            Id = id;
            Nev = nev;
        }

        public virtual void UjFeladatHozzaadasa(Termek termek)
        {
            FeladatLista += termek;
        }

        public override string ToString()
        {
            return $"{Nev}, munkára fordított idő: {MunkaraForditottIdo} perc";
        }
    }
}
