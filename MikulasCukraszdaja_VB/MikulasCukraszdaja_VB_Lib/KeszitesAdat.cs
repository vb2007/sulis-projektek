namespace MikulasCukraszdaja_VB_Lib
{
    public class KeszitesAdat
    {
        public string Azonosito { get; init; }
        public string Tipus {  get; init; }
        public int ElkeszitesiIdo { get; init; }

        public KeszitesAdat(string azonosito, string tipus, int elkeszitesiIdo)
        {
            Azonosito = azonosito;
            Tipus = tipus;
            ElkeszitesiIdo = elkeszitesiIdo;
        }
    }
}
