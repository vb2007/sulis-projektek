namespace Viragkoteszet_VB_Lib
{
    internal class Termek : ITermek
    {
        public int Id { get; init; }
        public string Tipus { get; init; }
        public string Megnevezes { get; init; }
        private List<(Alapanyag alapanyag, int mennyiseg)> _alapanyagok;

        public int ElkeszitesiIdo
        {
            get
            {
                int osszeg = 0;
                foreach (var (alapanyag, mennyiseg) in _alapanyagok)
                {
                    osszeg += alapanyag.ElkeszitesiIdo * mennyiseg;
                }
                return osszeg;
            }
        }

        public int Ar
        {
            get
            {
                int osszeg = 0;
                foreach (var (alapanyag, mennyiseg) in _alapanyagok)
                {
                    osszeg += alapanyag.Ar * mennyiseg;
                }
                return osszeg;
            }
        }

        public Termek(int id, string tipus, string megnevezes, List<(Alapanyag alapanyag, int mennyiseg)> alapanyagok)
        {
            Id = id;
            Tipus = tipus;
            Megnevezes = megnevezes;
            _alapanyagok = alapanyagok;
        }
    }
}
