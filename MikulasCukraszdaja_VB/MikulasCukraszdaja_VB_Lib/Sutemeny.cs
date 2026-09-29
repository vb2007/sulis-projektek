namespace MikulasCukraszdaja_VB_Lib
{
    internal class Sutemeny : IEtel
    {
        public required string Azonosito { get; init; }
        public required string Tipus { get; init; }
        public required string Megnevezes { get; init; }
        public required int ElkeszitesiIdo { get; init; }
        public KeszitesAdat KeszitesiAdat { get; init; }

        public Sutemeny(string azonosito, string tipus, string megnevezes, KeszitesAdat keszitesAdat)
        {
            Azonosito = azonosito;
            Tipus = tipus;
            Megnevezes = megnevezes;
            ElkeszitesiIdo = keszitesAdat.ElkeszitesiIdo;
        }

        public override string ToString()
        {
            return Megnevezes;
        }
    }
}
