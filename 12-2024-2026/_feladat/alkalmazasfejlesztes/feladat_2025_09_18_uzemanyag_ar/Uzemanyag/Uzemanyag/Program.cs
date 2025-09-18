using Uzemanyag_Lib;

namespace Uzemanyag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Uzemanyagok uzemanyagok = new Uzemanyagok(File.ReadAllLines("uzemanyag.txt"));

            Console.WriteLine($"3. feladat: Változások száma: {uzemanyagok.ValtozasokSzama}");
        }
    }
}
