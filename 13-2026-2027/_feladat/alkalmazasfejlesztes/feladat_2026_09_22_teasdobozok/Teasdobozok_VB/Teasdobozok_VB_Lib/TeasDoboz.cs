namespace Teasdobozok_VB_Lib
{
    internal class TeasDoboz : IDoboz
    {
        public int DarabSzam { get; set; }
        public List<Filterek> Filterek { get; set; }
        public string Nev { get; set; }
        public int Ar { get; set; }

        public TeasDoboz(int darabSzam)
        {
            DarabSzam = darabSzam;
        }
    }
}
