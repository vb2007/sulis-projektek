namespace Keresztrejtveny;

internal class Program
{
    static void Main(string[] args)
    {
        KeresztrejtvenyRacs racs = new KeresztrejtvenyRacs("kr2.txt");

        Console.WriteLine("5. feladat: A keresztrejtvény mérete");
        Console.WriteLine($"  Sorok száma: {racs.SorokDb}");
        Console.WriteLine($"  Oszlopok száma: {racs.OszlopokDb}");

        Console.WriteLine("6. feladat: A beolvasott keresztrejtvény");
        racs.MegjelenitRacs();

        int leghosszabb = racs.LeghosszabbFuggoSzo();
        Console.WriteLine($"7. feladat: A leghosszabb függ.: {leghosszabb} karakter");

        Console.WriteLine("8. feladat: Vízszintes szavak statisztikája");
        Dictionary<int, int> statisztika = racs.VizszintesSzavakStatisztika();
        foreach (var item in statisztika.OrderBy(x => x.Key))
        {
            Console.WriteLine($"  {item.Key} betűs: {item.Value} darab");
        }

        Console.WriteLine("9. feladat: A keresztrejtvény számokkal");
        racs.SzamozMezok();
        racs.MegjelenitSzamokkal();
    }
}
