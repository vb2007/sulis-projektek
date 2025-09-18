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

        //8. Feladat
        public int EvszamOlvasas(int minimumEv, int maximumEv)
        {
            int evInput = 0;
            while (evInput < minimumEv || evInput > maximumEv)
            {
                Console.Write($"8. feladat: Kérem adja meg az évszámot [{minimumEv}..{maximumEv}]: ");
                evInput = int.Parse(Console.ReadLine()!);
            }
            return evInput;
        }

        //9. Feladat
        private int NapokSzamaArvaltozasokKozott(DateTime elozo, DateTime aktualis)
        {
            int[] napokSzama = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (elozo.Year % 4 == 0)
            {
                napokSzama[1] = 29;
            }

            if (elozo.Month == aktualis.Month)
            {
                return aktualis.Day - elozo.Day;
            }

            return napokSzama[elozo.Month - 1] - elozo.Day + aktualis.Day;
        }

        //10. Feladat
        public int LeghosszabbIdoszak(int evInput)
        {
            List<Uzemanyag> adottEviValtozasok = uzemanyagArak
                .Where(x => x.Valtozas.Year == evInput)
                .OrderBy(x => x.Valtozas)
                .ToList();
            
            int maxNapok = 0;
            for (int i = 1; i < adottEviValtozasok.Count; i++)
            {
                DateTime elozo = adottEviValtozasok[i - 1].Valtozas;
                DateTime aktualis = adottEviValtozasok[i].Valtozas;

                int napokSzama = NapokSzamaArvaltozasokKozott(elozo, aktualis);

                if (napokSzama > maxNapok)
                {
                    maxNapok = napokSzama;
                }
            }

            return maxNapok;
        }
    }
}
