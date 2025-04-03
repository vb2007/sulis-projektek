namespace Berek2020
{
    internal class Dolgozo
    {
        public string Nev { get; set; }

        private string nem;
        public string Nem
        {
            get { return nem; }
            set
            {
                if (value == "férfi" || value == "nő")
                {
                    nem = value;
                }
            }
        }

        public string Reszleg { get; set; }

        private int belepes;
        public int Belepes
        {
            get { return belepes; }
            set
            {
                if (value > 1970)
                {
                    belepes = value;
                }
            }
        }

        private int ber;
        public int Ber
        {
            get { return ber; }
            set
            {
                if (value > 100000)
                {
                    ber = value;
                }
            }
        }

        //Név;Neme;Részleg;Belépés;Bér
        public Dolgozo(string nev, string nem, string reszleg, int belepes, int ber)
        {
            Nev = nev;
            Nem = nem;
            Reszleg = reszleg;
            Belepes = belepes;
            Ber = ber;
        }
    }
}
