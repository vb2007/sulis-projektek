namespace Viragkoteszet_VB_Lib
{
    public class FeladatKiosztas
    {
        private readonly Dolgozok _dolgozok;
        private readonly Termekek _termekek;

        public FeladatKiosztas(Dolgozok dolgozok, Termekek termekek)
        {
            _dolgozok = dolgozok;
            _termekek = termekek;
        }

        // sorok: a feladatkiosztas.txt tartalma fejléccel együtt
        // A hibás kiosztásokról a hibalista fájlba kerül üzenet.
        public void Kioszt(IEnumerable<string> sorok, string hibalistaEleresiUt)
        {
            List<string> hibak = new();

            foreach (string sor in AdatBeolvaso.Adatsorok(sorok))
            {
                string[] adatok = AdatBeolvaso.Darabol(sor);
                int dolgozoId = int.Parse(adatok[0]);
                int termekId = int.Parse(adatok[1]);

                try
                {
                    _dolgozok[dolgozoId].UjFeladatHozzaadasa(_termekek[termekId]);
                }
                catch (HibasFeladatException ex)
                {
                    hibak.Add($"{ex.Message} Dolgozó id: {dolgozoId}, termék id: {termekId}");
                }
            }

            File.WriteAllLines(hibalistaEleresiUt, hibak);
        }
    }
}
