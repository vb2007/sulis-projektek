using Foldrenges_VB_Lib;

namespace Foldrenges_VB_Console;

internal abstract class Program
{
    private static void Main(string[] args)
    {
        DataStore.Init();
        
        Console.WriteLine($"4. feladat: {DataStore.Instance!.TelepulesekSzama} db.");

        Console.WriteLine($"5. feladat: Az átlagos intenzitás {DataStore.Instance.IntenzitasAtlag} volt.");

        Console.WriteLine($"6. feladat: A legnagyobb magnitudó {DataStore.Instance.LegnagyobbMagnitudo} volt.");

        Console.WriteLine($"7. feladat: Összesen {DataStore.Instance.NagyobbMint4MagnitudoFoldrengesekSzama} db 4-nél nagyobb magnitudójú földrengés volt.");

        Console.WriteLine($"8. feladat: {(DataStore.Instance.VoltFoldrenges2003Juliusban ? "Volt" : "Nem volt")} földrengés 2003 júliusában.");

        Console.Write("9. feladat: Adjon meg egy települést: ");
        string telepulesNev = Console.ReadLine()!;

        var telepules = DataStore.Instance.LegelsoFoldrengesTelepulesNevAlapjan(telepulesNev);
        if (telepules is not null)
        {
            Console.WriteLine($"\t{telepules.Value.Magnitudo} - {telepules.Value.Intenzitas} - {telepules.Value.Ido}");
        }
        else
        {
            Console.WriteLine("\tNincs ilyen nevű település");
        }

        Console.WriteLine("10. feladat: A 3 legnagyobb magnitúdójú földrengést elszenvedő település.");
        List<(string?, float?)> haromLegnagyobbatElszenvedo = DataStore.Instance.HaromLegnagyobbMagnitudotElszenvedoTelepules;
        foreach ((string?, float?) adat in haromLegnagyobbatElszenvedo)
        {
            Console.WriteLine($"\t{adat.Item1} - {adat.Item2}");
        }

        Console.Write("11. feladat: Kérem adjon meg egy vármegye nevet: ");
        string varmegyeNev = Console.ReadLine()!;
        
        List<(string, DateOnly, float?)> foldrengesekVarmegyeAlapjan = DataStore.Instance.FoldrengesekVarmegyeAlapjan(varmegyeNev);
        foreach ((string, DateOnly, float?) adat in foldrengesekVarmegyeAlapjan)
        {
            Console.WriteLine($"\t{adat.Item1} - {adat.Item2} ({adat.Item3})");
        }
    }
}