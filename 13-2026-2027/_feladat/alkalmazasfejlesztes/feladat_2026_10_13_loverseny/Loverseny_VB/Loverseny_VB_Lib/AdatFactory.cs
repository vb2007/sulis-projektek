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
            }

            foreach(string loAdatSor in loAdatSorok)
            {
                string[] loAdat = loAdatSor.Split(';');
            }

            foreach(string versenyAdatSor in versenyAdatSorok)
            {
                string[] versenyAdat = versenyAdatSor.Split(';');
            }

            foreach(string versenyTipusAdatSor in versenyTipusAdatSorok)
            {
                string[] versenyTipusAdat = versenyTipusAdatSor.Split(';');
                _versenyTipusok.Add(new());
            }
        }
    }
}
