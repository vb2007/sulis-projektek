using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoember
{
    class HoEmber
    {
        private const int LOPAS = 66;
        private int gombocokSzama;
        private int meret;
        private int fagyott;

        public bool VanSepru { get; set; }
        public int GombocokSzama
        {
            get { return gombocokSzama; }
            private set
            {
                if (value == 2 || value == 3)
                {
                    gombocokSzama = value;
                }
            }
        }
        public int Meret
        {
            get { return meret; }
            set
            {
                if (value < 0)
                {
                    meret = 0;
                }
                else if (value > 100)
                {
                    meret = 100;
                }
                else
                {
                    meret = value;
                }
            }
        }
        public int Fagyott
        {
            get { return fagyott; }
            set
            {
                if (value < 0)
                {
                    fagyott = 0;
                }
                else if (value > 100)
                {
                    fagyott = 100;
                }
                else
                {
                    fagyott = value;
                }
            }
        }
        public HoEmber()
        {
            GombocokSzama = Random.Shared.Next(2, 4);
            meret = 100;
            fagyott = 100;
            VanSepru = true;
        }
        public HoEmber(int gomboc, bool sepru)
        {
            GombocokSzama = gomboc;
            meret = 100;
            fagyott = 100;
            VanSepru = sepru;
        }
        public HoEmber(string sor)
        {
            string[] darabolt = sor.Split(';');
            GombocokSzama = int.Parse(darabolt[0]);
            meret = int.Parse(darabolt[1]);
            fagyott = int.Parse(darabolt[1]);
            VanSepru = darabolt[3] != "0";
        }
        public string Info()
        {
            return $"Gombóc: {gombocokSzama}, méret: {meret}, fagyott: {fagyott}, seprű: {VanSepru}";
        }
        public void Olvad(int ertek)
        {
            Fagyott -= ertek;
            Meret -= ertek;
        }
        public void Visszafagy(int ertek)
        {
            Fagyott += ertek;
        }
        public bool SepruLopas(int ertek)
        {
            int esely = ertek + (100 - Fagyott);
            if (esely > LOPAS)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
