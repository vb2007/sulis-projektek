namespace Viragkoteszet_VB_Lib
{
    public class Termek : ITermek
    {
        private readonly List<(Alapanyag alapanyag, int mennyiseg)> _alapanyagok = new();

        public int Id { get; }
        public string Tipus { get; }
        public string Megnevezes { get; }

        public int ElkeszitesiIdo => _alapanyagok
            .Sum(x => x.alapanyag.ElkeszitesiIdo * x.mennyiseg);

        public int Ar => _alapanyagok
            .Sum(x => x.alapanyag.Ar * x.mennyiseg);

        // alapanyagok: alapanyag azonosítója -> szükséges mennyiség
        public Termek(int id, string tipus, string megnevezes, IReadOnlyDictionary<string, int> alapanyagok, Katalogus katalogus)
        {
            Id = id;
            Tipus = tipus;
            Megnevezes = megnevezes;

            foreach (var (azonosito, mennyiseg) in alapanyagok)
            {
                _alapanyagok.Add((katalogus[azonosito], mennyiseg));
            }
        }

        public override string ToString()
        {
            return $"{Id}. {Megnevezes} ({Tipus}) - ár: {Ar} Ft, elkészítési idő: {ElkeszitesiIdo} perc";
        }
    }
}
