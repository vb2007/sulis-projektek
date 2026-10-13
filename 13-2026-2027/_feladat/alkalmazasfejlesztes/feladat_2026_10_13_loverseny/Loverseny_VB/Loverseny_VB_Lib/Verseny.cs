namespace Loverseny_VB_Lib
{
    public class Verseny
    {
        public int VersenyId { get; set; }
        public int LoId { get; set; }
        public int HelyszinId { get; set; }
        public DateOnly Datum { get; set; }
        public TimeOnly KezdesIdo { get; set; }
        public int OrakSzama { get; set; }

        public Verseny()
        {
            
        }
    }
}
