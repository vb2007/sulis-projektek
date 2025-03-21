using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrszagokVB
{
    internal class Orszagok
    {
        public string Orszag { get; set; }
        private int terulet;
        public int Terulet
        {
            get { return terulet; }
            set
            {
                if (value > 0)
                {
                    terulet = value;
                }
            }
        }

        private int lakossag;
        public int Lakossag
        {
            get { return lakossag; }
            set
            {
                if (value > 20000)
                {
                    lakossag = value;
                }
            }
        }

        public string Fovaros { get; set; }

        private int tavolsag;
        public int Tavolsag
        {
            get { return tavolsag; }
            init
            {
                if (value >= 200 && value <= 25000)
                {
                    tavolsag = value;
                }
            }
        }

        public Orszagok()
        {
            Orszag = "Ismertetlen";
            Fovaros = "Ismertetlen";
            terulet = 1;
            lakossag = 20001;
            tavolsag = 200;
        }

        //Ország;Terület;Lakosság;Főváros;Távolság
        public Orszagok(string orszag, int terulet, int lakossag, string fovaros, int tavolsag)
        {
            Orszag = orszag;
            Terulet = terulet;
            Lakossag = lakossag;
            Fovaros = fovaros;
            Tavolsag = tavolsag;
        }

        public string Info()
        {
            return $"{Orszag} Területe: {Terulet} km²\n Lakossága: {Lakossag} fő\n Dővárosa: {Fovaros}\n Távolság: {Tavolsag} km";
        }
    }
}
