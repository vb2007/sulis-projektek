namespace Szalag_VB_Lib
{
    public class Feldolgozo
    {
        private readonly List<Szallitas> _szallitasok = new();
        private int SzalagHossz { get; }
        private int Idoegyseg { get; }

        public Feldolgozo(IEnumerable<string> adatSorok)
        {
            string[] elsoSor = adatSorok.First().Split(' ');
            SzalagHossz = int.Parse(elsoSor[0]);
            Idoegyseg = int.Parse(elsoSor[1]);

            int sorszam = 1;
            foreach (var sor in adatSorok.Skip(1))
            {
                _szallitasok.Add(new Szallitas(sor, sorszam++, SzalagHossz, Idoegyseg));
            }
        }

        //2. feladat
        public Szallitas? SzallitasKereseseSorszamAlapjan(int sorszam) => _szallitasok
            .FirstOrDefault(sz => sz.Sorszam == sorszam);

        //3. feladat
        public int LegnagyobbTavolsag => _szallitasok.Max(sz => sz.Tavolsag);
        
        private IEnumerable<int> LegnagyobbTavolsaguSzallitasokSorszamai => _szallitasok
            .Where(sz => sz.Tavolsag == LegnagyobbTavolsag)
            .Select(sz => sz.Sorszam);
        public string LegnagyobbTavolsaguSzallitasokSorszamaiString => string.Join(" ", LegnagyobbTavolsaguSzallitasokSorszamai);

        //4. feladat
        public int KezdopontElottElhaladtOssztomeg => _szallitasok
            .Where(sz => sz.IndulasiHely > sz.CelHely && sz.IndulasiHely != 0 && sz.CelHely != 0)
            .Sum(sz => sz.Tomeg);

        //5. feladat
        private List<int> SzallitottRekeszekAdottIdopontban(int idopont) => _szallitasok
            .Where(sz => idopont >= sz.IndulasiIdo && idopont < sz.ErkezesiIdo)
            .Select(sz => sz.Sorszam)
            .ToList();
        public string SzallitottRekeszekAdottIdopontbanString(int idopont) => SzallitottRekeszekAdottIdopontban(idopont).Any() ? string.Join(" ", SzallitottRekeszekAdottIdopontban(idopont)) : "üres";
        
        //6. feladat
        public string TomegekFajlbaIrasa(string fajlnev)
        {
            try
            {
                IEnumerable<string> tomegekIndulasiHelyenkent = _szallitasok
                    .GroupBy(sz => sz.IndulasiHely)
                    .Select(g => new { Hely = g.Key, OsszTomeg = g.Sum(sz => sz.Tomeg) })
                    .OrderBy(x => x.Hely)
                    .Select(x => $"{x.Hely} {x.OsszTomeg}");

                File.WriteAllLines(fajlnev, tomegekIndulasiHelyenkent);
                return $"{fajlnev} sikeresen létrehozva";
            }
            catch (Exception ex)
            {
                return $"Hiba a fájl írása során: {ex.Message}";
            }
        }
    }
}