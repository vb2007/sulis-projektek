using Hegyek_VB_Lib;

namespace Hegyek_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hegyek hegyek = new Hegyek(File.ReadAllLines("hegyekMo.txt").Skip(1));

            //1. Feladat
            Console.WriteLine($"1. Feladat: {hegyek.HegyekSzama} hegy adatai találhatók a fájlban.");
        }
    }
}
