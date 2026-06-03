using Foldrenges_VB_Lib;

namespace Foldrenges_VB_Console;

class Program
{
    static void Main(string[] args)
    {
        DataStore.Init();
        
        Console.WriteLine($"4. feladat: {DataStore.Instance!.TelepulesekSzama} db.");

        Console.WriteLine($"5. feladat: Az átlagos intenzitás {DataStore.Instance.IntenzitasAtlag} volt.");

        Console.WriteLine($"6. feladat: A legnagyobb magnitudó {DataStore.Instance.LegnagyobbMagnitudo} volt.");

        Console.WriteLine($"7. feladat: Összesen {DataStore.Instance.NagyobbMint4MagnitudoFoldrengesekSzama} db 4-nél nagyobb magnitudójú földrengés volt.");

        Console.WriteLine($"8. feladat: {(DataStore.Instance.VoltFoldrenges2003Juliusban ? "Volt" : "Nem volt")} földrengés 2003 júliusában.");
    }
}