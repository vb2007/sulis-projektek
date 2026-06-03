using Foldrenges_VB_Lib;

namespace Foldrenges_VB_Console;

class Program
{
    static void Main(string[] args)
    {
        DataStore.Init();
        
        Console.WriteLine($"4. feladat: {DataStore.Instance!.TelepulesekSzama} db");

        Console.WriteLine($"5. feladat: Az átlagos intenzitás {DataStore.Instance.IntenzitasAtlag} volt");
    }
}