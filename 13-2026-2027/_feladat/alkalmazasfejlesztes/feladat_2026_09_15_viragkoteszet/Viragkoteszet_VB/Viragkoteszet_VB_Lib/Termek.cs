namespace Viragkoteszet_VB_Lib
{
    internal class Termek : ITermek
    {
        public int Id { get; set; }
        public string Tipus { get; init; }
        public string Megnevezes { get; init; }
        public int ElkeszitesiIdo { get; set; }
        public int Ar { get; set; }

        public Termek(int id, string tipus, string megnevezes, int elkeszitesiIdo, int ar)
        {
            Id = id;
            Tipus = tipus;
            Megnevezes = megnevezes;
            ElkeszitesiIdo = elkeszitesiIdo;
            Ar = ar;
        }
    }
}
