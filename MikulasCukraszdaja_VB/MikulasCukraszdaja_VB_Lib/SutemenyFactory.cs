namespace MikulasCukraszdaja_VB_Lib
{
    public class SutemenyFactory
    {
        public Sutemeny Factory(string adatSor, KeszitesAdatok keszitesAdatok)
        {
            string[] adatok = adatSor.Split(';');

            string azonosito = adatok[0];
            string tipus = adatok[1];
            string megnevezes = adatok[2];

            if (tipus == "f")
            {
                IEnumerable<string> osszetevoAzonositok = adatok.Skip(3);
                return new DiszitettSutemeny(azonosito, tipus, megnevezes, keszitesAdatok, osszetevoAzonositok);
            }

            return new AlapSutemeny(azonosito, tipus, megnevezes, keszitesAdatok);
        }
    }
}
