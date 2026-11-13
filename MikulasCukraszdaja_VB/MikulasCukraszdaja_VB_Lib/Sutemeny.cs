namespace MikulasCukraszdaja_VB_Lib
{
    public abstract class Sutemeny : IEtel
    {
        public string Azonosito { get; init; }
        public string Tipus { get; init; }
        public string Megnevezes { get; init; }
        public abstract int ElkeszitesiIdo { get; }
        public KeszitesAdatok KeszitesAdatok { get; init; }

        public Sutemeny(string azonosito, string tipus, string megnevezes, KeszitesAdatok keszitesAdatok)
        {
            Azonosito = azonosito;
            Tipus = tipus;
            Megnevezes = megnevezes;
            //ElkeszitesiIdo = keszitesAdat.ElkeszitesiIdo;
            KeszitesAdatok = keszitesAdatok;
        }

        public override string ToString()
        {
            return Megnevezes;
        }
    }
}
