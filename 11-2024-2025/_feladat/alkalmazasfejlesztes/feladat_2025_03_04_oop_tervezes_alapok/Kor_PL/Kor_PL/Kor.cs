using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kor_PL
{
    class Kor
    {

        //propfull snippet
        private double r;

        public double Sugar
        {
            get 
            { 
                return r; 
            }
            set 
            {
                if (value>0)
                {
                    r = value;
                }
                else
                {
                    r = 1;
                }
            }
        }

        //ctor snippet

        /// <summary>
        /// 1 sugarú kör létrehozása
        /// </summary>
        public Kor()
        {
            //Alapértelmezett konstruktor vagy parampéter nélküli
            r = 1;
            // Sugar = 1;
        }

        /// <summary>
        /// A paraméterben megadott sugarú kör létrehozása.
        /// Negatív paraméter esetén 1 sugarú kört hoz létre.
        /// </summary>
        /// <param name="r">A sugár nagysága.</param>
        public Kor(double r)
        {
            //this.r = r;
            Sugar = r;
        }


        public double Kerulet()
        {
            return 2 * r * Math.PI;
        }

        public double Terulet()
        {
            return Sugar* Sugar* Math.PI;
        }

        public double FelKerulet
        {
            get 
            {
                return r * Math.PI;
            }
        }

        public double FelKerulet2 => r * Math.PI;


        public string Info()
        {
            return $"A kör sugara: {Sugar} kerülete: {Kerulet()}  területe: {Terulet()}";
        }


    }
}
