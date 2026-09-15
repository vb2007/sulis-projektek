namespace Viragkoteszet_VB_Lib
{
    internal class Termek : ITermek
    {
        public int Id { get; init; }
        public string Tipus { get; init; }
        public string Megnevezes { get; init; }
        public int ElkeszitesiIdo { get; init; }
        public int Ar { get; init; }
        public List<string> Alapanyagok { get; init; }
        public List<int> AlapanyagMennyisegek { get; init; }
        public List<Katalogus> AlapanyagKatalogus { get; init; }

        public Termek(int id, string tipus, string megnevezes, int elkeszitesiIdo, int ar, List<string> alapanyagok, List<int> alapanyagMennyisegek, List<Katalogus> alapanyagKatalogus)
        {
            Id = id;
            Tipus = tipus;
            Megnevezes = megnevezes;
            ElkeszitesiIdo = elkeszitesiIdo;
            Ar = ar;
            Alapanyagok = alapanyagok;
            AlapanyagMennyisegek = alapanyagMennyisegek;
            AlapanyagKatalogus = alapanyagKatalogus;
        }
    }
}
