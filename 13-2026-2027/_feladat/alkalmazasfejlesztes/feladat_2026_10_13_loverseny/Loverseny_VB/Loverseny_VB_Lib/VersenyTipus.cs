namespace Loverseny_VB_Lib
{
    public class VersenyTipus
    {
        public int VersenyTipusId { get; set; }
        public string TipusNev { get; set; }

        public VersenyTipus(int versenyTipusId, string tipusNev)
        {
            VersenyTipusId = versenyTipusId;
            TipusNev = tipusNev;
        }
    }
}
