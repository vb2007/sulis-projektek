namespace Uzemanyag_Lib
{
    public class Uzemanyagok
    {
        private readonly List<Uzemanyag> uzemanyagArak = new List<Uzemanyag>();

        public Uzemanyagok(IEnumerable<string> sorok)
        {
            foreach (string sor in sorok)
            {
                uzemanyagArak.Add(new Uzemanyag(sor));
            }
        }

        //3. Feladat
        public int ValtozasokSzama => uzemanyagArak.Count;
        //4. Feladat
        public int LegkisebbArKulonbseg => uzemanyagArak.Min(x => x.ArKulonbseg);
        //5. Feladat
        public int LegkisebbArKulonbsegElofordulas => uzemanyagArak.Count(x => x.ArKulonbseg == LegkisebbArKulonbseg);
        //6. Feladat
        public bool VoltSzokonaponValtozas => uzemanyagArak.Any(x => (x.Valtozas.Year % 4 == 0 && (x.Valtozas.Month == 2 && x.Valtozas.Day == 24)));
        
        //7. Feladat
        public string FajlbaIras(string fajlNev)
        {
            try
            {
                const double euro = 307.7;
                List<string> uzemanyagArakEuroban = new List<string>();

                foreach (Uzemanyag uzemanyag in uzemanyagArak)
                {
                    uzemanyagArakEuroban.Add(
                        $"{uzemanyag.Valtozas.Year}.{uzemanyag.Valtozas.Month}.{uzemanyag.Valtozas.Day};{uzemanyag.BenzinAr / euro:.00};{uzemanyag.GazolajAr / euro:.00}");
                }

                File.WriteAllLines(fajlNev, uzemanyagArakEuroban);

                return $"Adatok sikeresen kiírva a(z) {fajlNev} fájlba.";
            }
            catch (Exception ex)
            {
                return $"Hiba történt a(z) {fajlNev} fájlba írás közben: {ex.Message}";
            }
        }
    }
}
