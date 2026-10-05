namespace Viragkoteszet_VB_Lib
{
    internal class Dolgozo
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        // public string Beosztas { get; set; }

        public float Gyakorlottsag { get; set; }
        public int MunkaraForditottIdo { get; set; }

        public Dolgozo(int id, string nev)
        {
            Id = id;
            Nev = nev;
        }

        // public void UjFeladatHozzaadasa(Termek termek)
        // {
        //     Dolgozo._feladatLista.Add(new Dolgozo(Id, termek));
        // }

        public override string ToString()
        {
            return $"Név: {Nev}, Munkára fordított idő percben: {MunkaraForditottIdo}";
        }
    }
}
