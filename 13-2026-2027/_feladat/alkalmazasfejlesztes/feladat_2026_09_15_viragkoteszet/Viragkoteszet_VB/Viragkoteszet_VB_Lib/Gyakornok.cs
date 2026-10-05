namespace Viragkoteszet_VB_Lib
{
    public class Gyakornok : Dolgozo
    {
        private static readonly int[] LehetsegesGyakorlottsagok = { 70, 80, 90 };

        private readonly HashSet<int> _elkeszithetoTermekek;

        public override double Gyakorlottsag { get; }

        // Minden feladat annyival tovább tart, ahány százalék hiányzik a 100-hoz.
        public override int MunkaraForditottIdo => (int)Math.Round(
            FeladatLista.Feladatok.Sum(t => t.ElkeszitesiIdo * (1 + (100 - Gyakorlottsag) / 100)),
            MidpointRounding.AwayFromZero);

        public Gyakornok(int id, string nev, IEnumerable<int> elkeszithetoTermekek) : base(id, nev)
        {
            _elkeszithetoTermekek = new HashSet<int>(elkeszithetoTermekek);
            Gyakorlottsag = LehetsegesGyakorlottsagok[Random.Shared.Next(LehetsegesGyakorlottsagok.Length)];
        }

        public override void UjFeladatHozzaadasa(Termek termek)
        {
            if (!_elkeszithetoTermekek.Contains(termek.Id))
            {
                throw new HibasFeladatException();
            }

            base.UjFeladatHozzaadasa(termek);
        }

        public override string ToString()
        {
            return base.ToString() + " (gyakornok)";
        }
    }
}
