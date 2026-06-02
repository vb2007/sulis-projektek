using Alapfilmek_VB_Lib;

namespace Alapfilmek_VB_Console;

internal class Program
{
    static void Main(string[] args)
    {
        DataStore.Init();

        Console.WriteLine($"4. feladat: {DataStore.Instance!.HuszadikSzazadiAlkotokSzama} db alkotó született a 20. században.");

        Console.WriteLine($"5. feladat: {DataStore.Instance!.OtvenEvesFilmekSzama} db film ünnepli idén készítésének 50. évfodulóját.");

        Console.WriteLine("6. feladat: Egy tanórán megnézhető filmek:");
        foreach (var (cim, mufaj, hossz) in DataStore.Instance!.FilmekEgyTanoranBelul)
        {
            Console.WriteLine($"{cim} ({mufaj}): {hossz} perc");
        }

        Console.Write("7. feladat: A film címe: ");
        string filmCim = Console.ReadLine()!;
        var eredmeny = DataStore.Instance!.FilmKereses(filmCim);
        if (eredmeny is null)
        {
            Console.WriteLine("Ilyen néven nem található film.");
        }
        else
        {
            Console.WriteLine($"Rendező: {eredmeny.Value.Rendezok}");
            Console.WriteLine($"Készítés éve: {eredmeny.Value.Ev}");
            Console.WriteLine($"Link: https://videotorium.hu/hu/recordings/{eredmeny.Value.FilmAzonosito}");
        }

        Console.WriteLine("8. feladat: A 2 legtöbb filmben főszereplő színész:");
        foreach (var (nev, darab) in DataStore.Instance!.Top2FoszereplosAlkotok)
        {
            Console.WriteLine($"{nev}: {darab} alkalom");
        }

        Console.WriteLine("9. feladat: Dajka Margit színésztársai:");
        foreach (var (filmNev, szinesztarsak) in DataStore.Instance!.DajkaMargitSzinesztarsai)
        {
            Console.WriteLine($"{filmNev}: {string.Join(", ", szinesztarsak)}");
        }
    }
}