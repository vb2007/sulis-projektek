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
        public int HegysegbenHegycsucs(string hegysegNeve) => hegyek.Count(x => x.Hegyseg == hegysegNeve);

        public int ErteknelMagasabbakSzama(double magassag) => hegyek.Count(x => x.LabraValtas > magassag);
        public IEnumerable<Hegy> SorbaRendezett => hegyek.OrderByDescending(x => x.Magassag);
    }
}
