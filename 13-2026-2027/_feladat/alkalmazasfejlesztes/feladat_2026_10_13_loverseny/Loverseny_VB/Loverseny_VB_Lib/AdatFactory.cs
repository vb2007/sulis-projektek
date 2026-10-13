namespace Loverseny_VB_Lib
{
    public class AdatFactory
    {
        private readonly List<Helyszin> _helyszinek = new();
        private readonly List<Lo> _lovak = new();
        private readonly List<Verseny> _versenyek = new();
        private readonly List<VersenyTipus> _versenyTipusok = new();

        public AdatFactory(
            IEnumerable<string> helyszinAdatSorok,
            IEnumerable<string> loAdatSorok,
            IEnumerable<string> versenyAdatSorok,
            IEnumerable<string> versenyTipusAdatSorok)
        {
            foreach(string helyszinAdatSor in helyszinAdatSorok)
            {
                string[] helyszinAdat = helyszinAdatSor.Split(';');
                _helyszinek.Add(new Helyszin(
                    helyszinId: int.Parse(helyszinAdat[0]),
                    nev: helyszinAdat[1],
                    telepules: helyszinAdat[2],
                    orszag: helyszinAdat[3],
                    kapacitas: int.Parse(helyszinAdat[4])
                ));
            }

            foreach(string loAdatSor in loAdatSorok)
            {
                string[] loAdat = loAdatSor.Split(';');
                _lovak.Add(new Lo(
                    loId: int.Parse(loAdat[0]),
                    nev: loAdat[1],
                    versenyTipusId: int.Parse(loAdat[2])
                ));
            }

            foreach(string versenyAdatSor in versenyAdatSorok)
            {
                string[] versenyAdat = versenyAdatSor.Split(';');
                _versenyek.Add(new Verseny(
                    versenyId: int.Parse(versenyAdat[0]),
                    loId: int.Parse(versenyAdat[1]),
                    helyszinId: int.Parse(versenyAdat[2]),
                    datum: DateOnly.Parse(versenyAdat[3]),
                    kezdesIdo: TimeOnly.Parse(versenyAdat[4]),
                    orakSzama: int.Parse(versenyAdat[5])
                ));
            }

            foreach(string versenyTipusAdatSor in versenyTipusAdatSorok)
            {
                string[] versenyTipusAdat = versenyTipusAdatSor.Split(';');
                _versenyTipusok.Add(new VersenyTipus(
                    versenyTipusId: int.Parse(versenyTipusAdat[0]),
                    tipusNev: versenyTipusAdat[1]
                ));
            }
        }
    }
}
