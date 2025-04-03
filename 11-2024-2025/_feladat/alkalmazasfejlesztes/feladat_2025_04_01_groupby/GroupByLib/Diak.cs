namespace GroupByLib
{
    public class Diak
    {
        public string Osztaly { get; init; }
        public string Nev { get; init; }
        public string Szint { get; init; }
        public int Pont { get; init; }

        public Diak(string osztaly, string nev, string szint, int pont)
        {
            Osztaly = osztaly;
            Nev = nev;
            Szint = szint;
            Pont = pont;
        }
    }
}
