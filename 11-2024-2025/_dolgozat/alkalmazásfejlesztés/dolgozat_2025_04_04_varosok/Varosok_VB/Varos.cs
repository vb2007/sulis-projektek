namespace Varosok_VB
{
    internal class Varos
    {
        public string Nev { get; set; }
        public string Varmegye { get; set; }
        public int Nepesseg { get; set; }
        public double Terulet { get; set; }

        private string nyilvanitasEve;
        public int NyilvanitasEve
        {
            get
            {
                return int.TryParse(nyilvanitasEve, out int year) ? year : 1800;
            }
            set
            {
                nyilvanitasEve = value.ToString();
            }
        }

        public Varos(string nev, string varmegye, int nepesseg, double terulet, string nyilvanitasEve)
        {
            Nev = nev;
            Varmegye = varmegye;
            Nepesseg = nepesseg;
            Terulet = terulet;
            NyilvanitasEve = int.TryParse(nyilvanitasEve, out int year) ? year : 1800;
        }
    }
}
