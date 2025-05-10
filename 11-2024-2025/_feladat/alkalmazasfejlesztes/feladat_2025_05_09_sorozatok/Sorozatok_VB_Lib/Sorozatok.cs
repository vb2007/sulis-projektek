namespace Sorozatok_VB_Lib
{
    public class Sorozatok
    {
        private readonly List<Sorozat> sorozatok = new();

        public Sorozatok(IEnumerable<string> adatSorok)
        {
            foreach (var item in adatSorok)
            {
                sorozatok.Add(new(item));
            }
        }

        public int SorozatokSzama => sorozatok.Count;

        public string EgyVsKetRendezosViszony()
        {
            int egyRendezos = sorozatok.Count(s => s.RendezokSzama() == 1);
            int ketRendezos = sorozatok.Count(s => s.RendezokSzama() == 2);

            if (egyRendezos > ketRendezos)
                return "több";
            else if (egyRendezos < ketRendezos)
                return "kevesebb";
            else
                return "egyenlő";
        }

        public double AtlagEvadEvAlapjan(int ev) =>
            Math.Round(
            sorozatok
                .Where(x => x.KezdesEve <= ev)
                .Average(x => x.Evadok),
            1);

        public string LegkevesebbKategoriaAlapjan =>
            sorozatok
                .GroupBy(x => x.Kategoria)
                .OrderBy(x => x.Count())
                .FirstOrDefault()?.Key ?? "-- nincs adat --";

        public List<Sorozat> SorozatokSzarmazasAlapjan(string szarmazas) =>
            sorozatok
                .Where(x => x.Szarmazas.Equals(szarmazas, StringComparison.OrdinalIgnoreCase))
                .ToList();
    }
}
