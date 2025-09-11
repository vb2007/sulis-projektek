namespace Hegyek_VB_Lib
{
    public class Hegyek
    {
        public readonly List<Hegy> hegyek = new List<Hegy>();

        public Hegyek(IEnumerable<string> adatSorok)
        {
            foreach (var sor in adatSorok)
            {
                hegyek.Add(new Hegy(sor));
            }
        }

        public int HegyekSzama => hegyek.Count;
        public Hegy LegalacsonyabbHegy => hegyek.MinBy(x => x.Magassag)!;
        public double AtlagMagassag => Math.Round(hegyek.Average(x => x.Magassag), 1);
        public int HegycsucsokSzamaHegysegAlapjan(string hegysegNeve) => hegyek.Count(x => x.Hegyseg == hegysegNeve);
        public int HegycsucsokSzamaNevAlapjan(string nevReszlet) => hegyek.Count(x => x.Hegycsucs.Contains(nevReszlet, StringComparison.OrdinalIgnoreCase));

        private List<string> HegysegekNevei => new List<string>(hegyek.Select(x => x.Hegyseg).Distinct().OrderBy(x => x).ToList());
        public string HegysegekNeveiString => string.Join("; ", HegysegekNevei);

        public int HegyekSzamaMagasabbMint(int magassag) => hegyek.Count(x => x.LabraValtas > magassag);

        private IEnumerable<Hegy> HegyekMagassagSzerintCsokkenoben => hegyek.OrderByDescending(x => x.Magassag);
        public string FajlbaIras(int darabszam, string fajlnev)
        {
            try
            {
                List<string> hegyek = new List<string>();

                foreach (Hegy hegy in HegyekMagassagSzerintCsokkenoben.Take(darabszam))
                {
                    hegyek.Add(hegy.FajlbairasFormatum);
                }

                File.WriteAllLines(fajlnev, hegyek);

                return $"Top {darabszam} legmagasabb hegy sikeresen kiírva a {fajlnev} fájlba.";
            }
            catch (Exception ex)
            {
                return $"Hiba a fájl írása során: {ex.Message}";
            }   
        }
    }
}
