using Uzemanyag_Lib;

namespace Uzemanyag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Uzemanyagok uzemanyagok = new Uzemanyagok(File.ReadAllLines("uzemanyag.txt"));

            Console.WriteLine($"3. feladat: Változások száma: {uzemanyagok.ValtozasokSzama}");

            Console.WriteLine($"4. feladat: A legkisebb különbség: {uzemanyagok.LegkisebbArKulonbseg}");

            Console.WriteLine($"5. feladat: A legkisebb különbség előfordulása: {uzemanyagok.LegkisebbArKulonbsegElofordulas}");
        }
    }
}
