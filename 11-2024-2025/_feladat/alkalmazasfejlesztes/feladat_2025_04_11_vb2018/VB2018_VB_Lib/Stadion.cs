namespace VB2018_VB_Lib
{
    public class Stadion
    {
        public string Varos { get; init; }
        public string Nev1 { get; init; }
        public string Nev2 { get; init; }
        public int Ferohely { get; init; }

        public Stadion(string dataLines)
        {
            string[] splitted = dataLines.Split(';');

            Varos = splitted[0];
            Nev1 = splitted[1];
            Nev2 = splitted[2];
            Ferohely = int.Parse(splitted[3]);
        }
    }
}
