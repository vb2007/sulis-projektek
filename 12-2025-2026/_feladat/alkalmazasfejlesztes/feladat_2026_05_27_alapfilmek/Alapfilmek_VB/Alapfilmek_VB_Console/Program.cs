using Alapfilmek_VB_Lib;

namespace Alapfilmek_VB_Console;

internal class Program
{
    static void Main(string[] args)
    {
        DataStore.Init();

        Console.WriteLine($"4. feladat: {DataStore.Instance!.HuszadikSzazadiAlkotokSzama} db alkotó született a 20. században.");

        Console.WriteLine($"5. feladat: Az 50 éves filmek száma: {DataStore.Instance!.OtvenEvesFilmekSzama}");
    }
}