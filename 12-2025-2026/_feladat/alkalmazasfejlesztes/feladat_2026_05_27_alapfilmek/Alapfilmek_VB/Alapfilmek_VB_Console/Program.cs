using Alapfilmek_VB_Lib;

namespace Alapfilmek_VB_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataStore.Init();

            Console.WriteLine($"4. feladat: {DataStore.Instance!.HuszadikSzazadiAlkotokSzama} db alkotó született a 20. században.");
        }
    }
}
