namespace OnlineJatek_VB_Lib
{
    public class Jatekok
    {
        private readonly List<Jatek> jatekok = new();

        public Jatekok(IEnumerable<string> adatSorok)
        {
            foreach (var item in adatSorok)
            {
                jatekok.Add(new(item));
            }
        }

        public int HanyszorJelentEgyHonapban(int honapSzama) =>
            jatekok
                .Where(x => x.MegjelenesIdeje.Month == honapSzama)
                .Count();

        public Jatek LegtobbAktivJatekos =>
            jatekok
                .MaxBy(x => x.AktivJatekosok);

        public double AtlagosMegjelenesiIdoEvekben =>
            Math.Round(
                DateTime.Now.Year -
                jatekok
                    .Average(x => double.Parse(x.MegjelenesIdeje.Year.ToString())),
            0);

        public Dictionary<string, int> MufajStatisztika() =>
            jatekok
                .GroupBy(x => x.Mufaj)
                .ToDictionary(x => x.Key, x => x.Count());

        public Jatek JatekKeresesNevAlapjan(string nev) =>
            jatekok
                .Find(x => x.Nev.ToLower() == nev.ToLower());

        public Jatek LegregebbiJatek =>
            jatekok
                .MinBy(x => x.MegjelenesIdeje);

        //egyébként hibás vagy a feladatleírás, vagy a példa
        //leírás szerint "azoknak a játékoknak a nevét, amelyeknek több mint 100 ezer aktív játékosa van" kell kiválasztani
        //a példában pedig azok is ki vannak írva, amik pont 100 ezer aktív játékossal rendelkeznek
        //tehát nem tudjuk, hogy ">" vagy ">="-t kellett volna használni
        private List<string> TobbMintXAktivJatekos(int jatekosSzam) => jatekok
                .Where(x => x.AktivJatekosok > jatekosSzam)
                .OrderByDescending(x => x.AktivJatekosok)
                .Select(x => x.Nev)
                .Distinct()
                .ToList();

        public string TobbMintXAktivJatekosString(int jatekosokSzama) =>
            string.Join(", ", TobbMintXAktivJatekos(jatekosokSzama));

        public (int KezdoEv, int ZaroEv) Aranykor(string mufaj)
        {
            var sikeresJatekok = jatekok
                .Where(x => x.Mufaj.ToLower() == mufaj.ToLower() && x.AktivJatekosok >= 50)
                .OrderBy(x => x.MegjelenesIdeje.Year)
                .ToList();

            if (!sikeresJatekok.Any())
            {
                throw new InvalidOperationException($"\tA(z) {mufaj} műfajnak nem volt idáig aranykora.");
            }

            int maxJatekSzam = 0;
            int kezdoEv = 0;
            for (int i = 0; i < sikeresJatekok.Count; i++)
            {
                int aktualisEv = sikeresJatekok[i].MegjelenesIdeje.Year;
                int zaroEv = aktualisEv + 4;

                int jatekSzam = sikeresJatekok
                    .Count(j => j.MegjelenesIdeje.Year >= aktualisEv && j.MegjelenesIdeje.Year <= zaroEv);

                if (jatekSzam > maxJatekSzam)
                {
                    maxJatekSzam = jatekSzam;
                    kezdoEv = aktualisEv;
                }
            }

            return (kezdoEv, kezdoEv + 4);
        }
    }
}
