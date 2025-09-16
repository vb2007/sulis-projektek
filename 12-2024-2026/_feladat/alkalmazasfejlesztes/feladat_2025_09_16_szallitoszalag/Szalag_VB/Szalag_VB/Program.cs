using Szalag_VB_Lib;

namespace Szalag_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Feldolgozo szalagFeldolgozo = new Feldolgozo(File.ReadAllLines("szallit.txt"));
            //Console.WriteLine("1. feladat: Adatok beolvasva.");
            //Console.WriteLine();

            Console.WriteLine("2. feladat");
            Console.Write("Adja meg, melyik adatsorra kíváncsi! ");
            
            int sorszamInput = int.Parse(Console.ReadLine() ?? "0");
            Szallitas? keresettSzallitas = szalagFeldolgozo.SzallitasKereseseSorszamAlapjan(sorszamInput);
            Console.WriteLine(keresettSzallitas?.KiirasiFormatum ?? "Nincs ilyen sorszámú szállítás.");
            Console.WriteLine();

            Console.WriteLine("3. feladat");
            Console.WriteLine($"A legnagyobb távolság: {szalagFeldolgozo.LegnagyobbTavolsag}");
            Console.WriteLine($"A maximális távolságú szállítások sorszáma: {szalagFeldolgozo.LegnagyobbTavolsaguSzallitasokSorszamaiString}");
            Console.WriteLine();
            
            Console.WriteLine("4. feladat");
            Console.WriteLine($"A kezdőpont előtt elhaladó rekeszek össztömege: {szalagFeldolgozo.KezdopontElottElhaladtOssztomeg}");
            Console.WriteLine();

            Console.WriteLine("5. feladat");
            Console.Write("Adja meg a kívánt időpontot! ");
            
            int idopontInput = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine($"A szállított rekeszek halmaza: {szalagFeldolgozo.SzallitottRekeszekAdottIdopontbanString(idopontInput)}");
            Console.WriteLine();
            
            Console.WriteLine("6. feladat");
            Console.WriteLine(szalagFeldolgozo.TomegekFajlbaIrasa("tomeg.txt"));
        }
    }
}