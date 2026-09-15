namespace Viragkoteszet_VB_Lib
{
    internal class Katalogus
    {
        private List<Alapanyag> _alapanyagok { get; } = new List<Alapanyag>();

        public Katalogus(IEnumerable<Alapanyag> alapanyagok)
        {
            foreach (var alapanyag in alapanyagok)
            {
                _alapanyagok.Add(alapanyag);
            }
        }

        public Alapanyag this[string azonosito]
        {
            get
            {
                return _alapanyagok.FirstOrDefault(a => a.Azonosito == azonosito)!;
            }
        }
    }
}
