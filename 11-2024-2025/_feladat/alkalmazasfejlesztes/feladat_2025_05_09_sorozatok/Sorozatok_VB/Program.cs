using Sorozatok_VB_Lib;

namespace Sorozatok_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sorozatok sorozatok = new Sorozatok(File.ReadAllLines("sorozatok.txt").Skip(1));

            Console.WriteLine("3. feladat:");
            Console.WriteLine($"Összesen {sorozatok.SorozatokSzama} sorozat adatait olvastam be.");

            Console.WriteLine("5. feladat:");
            Console.WriteLine($"Az egy rendezős sorozatok száma {sorozatok.EgyVsKetRendezosViszony()}, mint a két rendezős sorozatok száma.");

            Console.WriteLine("6. feladat:");
            Console.WriteLine($"A XX. században indult sorozatok átlagosan {sorozatok.AtlagEvadEvAlapjan(2000)} évadot értek meg.");

            Console.WriteLine("7. feladat:");
            Console.WriteLine($"A(z) {sorozatok.LegkevesebbKategoriaAlapjan} kategóriából van a legkevesebb");

            Console.WriteLine("8. feladat:");
            Console.Write("Melyik országból származó filmekre kíváncsi? ");
            string orszag = Console.ReadLine()!;

            FajlbaIras("szarmazas.txt", orszag, sorozatok);

            void FajlbaIras(string fajlnev, string orszagNev, Sorozatok sorozatok)
            {
                List<Sorozat> sorozatokSzarmazasAlapjan = sorozatok.SorozatokSzarmazasAlapjan(orszagNev);
                using StreamWriter sw = new(fajlnev);

                foreach (Sorozat sorozat in sorozatokSzarmazasAlapjan)
                {
                    sw.WriteLine(sorozat.ToString());
                }
            }
        }
    }
}
