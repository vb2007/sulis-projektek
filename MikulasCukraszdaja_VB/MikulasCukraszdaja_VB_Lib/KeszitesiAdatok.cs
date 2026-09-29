namespace MikulasCukraszdaja_VB_Lib
{
    public class KeszitesiAdatok
    {
        private readonly List<KeszitesAdat> _keszitesiAdatok = new();

        public KeszitesiAdatok(IEnumerable<string> adatSorok)
        {
            foreach (string adatSor in adatSorok)
            {
                string[] adatok = adatSor.Split(';');
                _keszitesiAdatok.Add(new KeszitesAdat(adatok[0], adatok[1], int.Parse(adatok[2])));
            }
        }
    }
}
