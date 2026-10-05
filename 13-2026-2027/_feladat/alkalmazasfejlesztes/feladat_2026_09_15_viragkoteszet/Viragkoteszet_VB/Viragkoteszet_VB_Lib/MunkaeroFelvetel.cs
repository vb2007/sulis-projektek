namespace Viragkoteszet_VB_Lib
{
    public class MunkaeroFelvetel
    {
        private const string GyakornokBeosztas = "gy";
        private const string ViragkotoBeosztas = "v";

        // sorok: a dolgozok.txt tartalma fejléccel együtt
        public Dolgozok Felvesz(IEnumerable<string> sorok)
        {
            Dolgozok dolgozok = new();

            foreach (string sor in sorok.Skip(1).Where(x => !string.IsNullOrWhiteSpace(x)))
            {
                dolgozok.Hozzaad(Letrehoz(sor));
            }

            return dolgozok;
        }

        private static Dolgozo Letrehoz(string sor)
        {
            string[] adatok = sor.Split(';').Select(x => x.Trim()).ToArray();
            int id = int.Parse(adatok[0]);
            string nev = adatok[1];
            string beosztas = adatok[2];

            return beosztas switch
            {
                GyakornokBeosztas => new Gyakornok(id, nev, adatok.Skip(3).Select(int.Parse)),
                ViragkotoBeosztas => new Viragkoto(id, nev),
                _ => throw new FormatException($"Ismeretlen beosztás: {beosztas}")
            };
        }
    }
}
