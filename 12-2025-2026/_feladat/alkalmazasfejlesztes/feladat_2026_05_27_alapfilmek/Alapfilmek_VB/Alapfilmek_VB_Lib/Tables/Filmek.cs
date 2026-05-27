namespace Alapfilmek_VB_Lib.Tables
{
    internal class Filmek
    {
        public int FilmAzonosito { get; init; }
        public string Cim { get; init; }
        public int Ev { get; init; }
        public string Szines { get; init; }
        public string Mufaj { get; init; }
        public int Hossz { get; init; }

        internal Filmek(string dataLine)
        {
            string[] split = dataLine.Split('\t');

            FilmAzonosito = int.Parse(split[0]);
            Cim = split[1];
            Ev = int.Parse(split[2]);
            Szines = split[3];
            Mufaj = split[4];
            Hossz = int.Parse(split[5]);
        }
    }
}
