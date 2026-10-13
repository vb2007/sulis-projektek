namespace Loverseny_VB_Lib
{
    public class Lo
    {
        public int LoId { get; set; }
        public string Nev { get; set; }
        public int VersenyTipusId { get; set; }

        public int VersenyzesselToltottIdo { get; }

        public Lo(int loId, string nev, int versenyTipusId)
        {
            LoId = loId;
            Nev = nev;
            VersenyTipusId = versenyTipusId;
        }
    }
}
