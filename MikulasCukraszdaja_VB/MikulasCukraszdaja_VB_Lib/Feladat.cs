namespace MikulasCukraszdaja_VB_Lib
{
    public class Feladat
    {
        public string SutemenyTipus { get; set; }
        public int Darabszam { get; set; }
        public int ElkeszitesiIdo { get; set; }

        private static int maximumMunkaora = 8;
        private static int maximumMunkaperc = maximumMunkaora * 60;

        public Feladat(Sutemeny sutemeny, int darabszam)
        {
            SutemenyTipus = sutemeny.Tipus;
            Darabszam = darabszam;
            ElkeszitesiIdo = sutemeny.ElkeszitesiIdo * darabszam;

            if (ElkeszitesiIdo > maximumMunkaperc)
            {
                throw new TulSokFeladatException();
            }
        }
    }
}
