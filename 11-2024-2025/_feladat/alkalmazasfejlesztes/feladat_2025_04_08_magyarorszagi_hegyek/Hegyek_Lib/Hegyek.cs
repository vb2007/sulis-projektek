namespace Hegyek_Lib
{
    public class Hegyek
    {
        private readonly List<Hegy> hegyek = new List<Hegy>();

        public Hegyek(IEnumerable<string> fajlSorok)
        {
            foreach (var item in fajlSorok)
            {
                hegyek.Add(new Hegy(item));
            }
        }

        public int HegyekSzama => hegyek.Count;
        public Hegy Legalacsonyabb => hegyek.MinBy(h => h.Magassag);
        public double AtlagMagassag => Math.Round(hegyek.Average(h => h.Magassag), 1);
        public int HegysegbenHegycsucsokSzama(string hegysegNeve) => hegyek.Count(x => x.Hegyseg == hegysegNeve);
        public int HegysegNevebenSzoSzama(string szo) => hegyek.Count(x => x.Hegycsucs.Contains(szo, StringComparison.OrdinalIgnoreCase));

        private List<string> HegysegekNevei => new List<string>(hegyek.Select(x => x.Hegyseg).Distinct().OrderBy(x => x).ToList());
        public string HegysegekNeveiString => string.Join("; ", HegysegekNevei);

        public int ErteknelMagasabbakSzama(double magassag) => hegyek.Count(x => x.LabraValtas > magassag);
        public IEnumerable<Hegy> SorbaRendezett => hegyek.OrderByDescending(x => x.Magassag);
    }
}
