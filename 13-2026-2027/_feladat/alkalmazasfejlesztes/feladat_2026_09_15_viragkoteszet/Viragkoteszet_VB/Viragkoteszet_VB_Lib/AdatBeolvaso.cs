namespace Viragkoteszet_VB_Lib
{
    public static class AdatBeolvaso
    {
        // sorok: az alapanyagok.txt tartalma fejléccel együtt
        public static Katalogus AlapanyagokBeolvasasa(IEnumerable<string> sorok)
        {
            List<Alapanyag> alapanyagok = new();

            foreach (string sor in Adatsorok(sorok))
            {
                string[] adatok = Darabol(sor);
                alapanyagok.Add(new Alapanyag(adatok[0], adatok[1], int.Parse(adatok[2]), int.Parse(adatok[3])));
            }

            return new Katalogus(alapanyagok);
        }

        // sorok: a termekek.txt tartalma fejléccel együtt
        public static Termekek TermekekBeolvasasa(IEnumerable<string> sorok, Katalogus katalogus)
        {
            Termekek termekek = new();

            foreach (string sor in Adatsorok(sorok))
            {
                string[] adatok = Darabol(sor);

                // A 4. elemtől kezdve alapanyag-azonosító és mennyiség párok következnek.
                Dictionary<string, int> alapanyagok = new();
                for (int i = 3; i + 1 < adatok.Length; i += 2)
                {
                    alapanyagok[adatok[i]] = int.Parse(adatok[i + 1]);
                }

                termekek.Hozzaad(new Termek(int.Parse(adatok[0]), adatok[1], adatok[2], alapanyagok, katalogus));
            }

            return termekek;
        }

        internal static IEnumerable<string> Adatsorok(IEnumerable<string> sorok)
        {
            return sorok.Skip(1).Where(s => !string.IsNullOrWhiteSpace(s));
        }

        internal static string[] Darabol(string sor)
        {
            return sor.Split(';').Select(x => x.Trim()).ToArray();
        }
    }
}
