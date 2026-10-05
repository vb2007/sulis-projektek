namespace Viragkoteszet_VB_Lib
{
    public class Katalogus
    {
        private readonly Dictionary<string, Alapanyag> _alapanyagok = new();

        public Katalogus(IEnumerable<Alapanyag> alapanyagok)
        {
            foreach (Alapanyag alapanyag in alapanyagok)
            {
                _alapanyagok.Add(alapanyag.Azonosito, alapanyag);
            }
        }

        public Alapanyag this[string azonosito]
        {
            get
            {
                if (!_alapanyagok.TryGetValue(azonosito, out Alapanyag? alapanyag))
                {
                    throw new KeyNotFoundException($"Nincs ilyen alapanyag: {azonosito}");
                }
                return alapanyag;
            }
        }
    }
}
