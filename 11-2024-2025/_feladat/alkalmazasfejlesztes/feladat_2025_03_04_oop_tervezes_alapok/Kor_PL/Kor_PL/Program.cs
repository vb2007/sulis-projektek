using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kor_PL
{
    class Program
    {
        static void Main(string[] args)
        {
            Kor kor = new Kor();
            Console.WriteLine($"A kör sugara: {kor.Sugar} kerülete: {kor.Kerulet()}  területe: {kor.Terulet()}");
            Console.WriteLine(kor.Info());

            kor.Sugar = 0;
            Console.WriteLine("0-ra állított sugár");
            Console.WriteLine(kor.Info());

            kor.Sugar = -6;
            Console.WriteLine("-6-ra állított sugár");
            Console.WriteLine(kor.Info());

            kor.Sugar = 6;
            Console.WriteLine("6-ra állított sugár");
            Console.WriteLine(kor.Info());

            Kor kor2 = new Kor(0);
            Console.WriteLine("0-ra állított sugár");
            Console.WriteLine(kor2.Info());


            _ = Console.ReadKey();
        }
    }
}
