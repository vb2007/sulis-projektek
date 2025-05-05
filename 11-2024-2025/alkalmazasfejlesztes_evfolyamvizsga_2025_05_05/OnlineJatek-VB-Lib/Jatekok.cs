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
                .Select(x => x.MegjelenesIdeje.Month.ToString() == honapSzama.ToString())
                .Count();

        public Jatek LegtobbAktivJatekos =>
            jatekok
                .MaxBy(x => x.AktivJatekosok);

        public double AtlagIdoMegjelenesEsNapjainkKozott =>
            Math.Round(
                DateTime.Now.Year -
                jatekok
                    .Average(x => double.Parse(x.MegjelenesIdeje.Year.ToString())),
            0);

        //public List<Jatek> MufajokJatekszamAlapjan =>
        //    jatekok
        //        .GroupBy(x => x.Mufaj);

        public Jatek JatekKeresesNevAlapjan(string nev) =>
            jatekok
                .Find(x => x.Nev == nev);
                //.Select(x => x);

        public Jatek LegregebbiJatekAdatai =>
            jatekok
                .MinBy(x => x.MegjelenesIdeje);

        private List<string> TobbMintXAktivJatekos(int jatekosSzam) => jatekok
                .Where(x => x.AktivJatekosok > jatekosSzam)
                .Select(x => x.Nev)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

        //.OrderBy(x => x.AktivJatekosok);
        public string TobbMintXAktivJatekosString(int jatekosokSzama) =>
            string.Join(", ", TobbMintXAktivJatekos(jatekosokSzama));
    }
}
