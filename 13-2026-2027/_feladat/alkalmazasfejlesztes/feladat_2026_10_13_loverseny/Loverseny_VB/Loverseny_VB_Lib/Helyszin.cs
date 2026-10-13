namespace Loverseny_VB_Lib
{
    public class Helyszin
    {
        public int HelyszinId { get; set; }
        public string Nev { get; set; }
        public string Telepules { get; set; }
        public string Orszag { get; set; }
        public int Kapacitas { get; set; }

        public Helyszin(int helyszinId, string nev, string telepules, string orszag, int kapacitas)
        {
            HelyszinId = helyszinId;
            Nev = nev;
            Telepules = telepules;
            Orszag = orszag;
            Kapacitas = kapacitas;
        }
    }
}
