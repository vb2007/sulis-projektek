using Croods_VB_Lib;

namespace Croods_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Caves caves = new(File.ReadAllLines("feljegyzesek.csv").Skip(1));

            //3.
            Cave favouriteCave = caves.GetCaveByIndex(163);
            Console.WriteLine("3. feladat: Croodek kedvenc barlangjának adatai:");
            Console.WriteLine($"\tNév: {favouriteCave.Name}");
            Console.WriteLine($"\tHossz: {favouriteCave.Length} m");
            Console.WriteLine($"\tMélység: {favouriteCave.Depth} m");
            Console.WriteLine($"\tMagasság: {favouriteCave.Height} m");
            Console.WriteLine($"\tTelepülés: {favouriteCave.City}");

            //4.
            Console.WriteLine($"4. feladat: A látogatott barlangok teljes hossza: {caves.TotalLengthInKm} km");

            //5.
            Cave deepestCave = caves.DeepestCave;
            Console.WriteLine("5. feladat: A legmélyebb barlang adatai:");
            Console.WriteLine($"\tNév: {deepestCave.Name}");
            Console.WriteLine($"\tMélység: {deepestCave.Depth}");
            Console.WriteLine($"\tTelepülés: {deepestCave.City}");

            //7.
            Console.Write("7. feladat: ");
            if (caves.CavesWithOldNamesCount == 0)
            {
                Console.Write("Nincs régies barlangnév!");
            }
            else
            {
                Console.Write($"Régies nevű barlangok száma: {caves.CavesWithOldNamesCount} db");
                Console.WriteLine($"\nRégies nevű barlangok nevei: \n\t{caves.CavesWithOldNamesString}");
            }

            //8.
            Console.WriteLine($"8. feladat: Az Égerszög-ön található barlangok átlagos hossza: {caves.AverageLengthByCity(favouriteCave.City)} m");

            //9.
            Console.WriteLine("9. feladat:");
            ExportWithErrorHandling("javitott.csv", true);

            //10.
            Console.WriteLine("10. feladat: Egyes települések barlangjai:");
            foreach (var line in caves.GetCavesByCity())
            {
                Console.WriteLine($"{line}");
            }

            //11.
            Console.WriteLine("11. feladat: A négy leghosszabb magyarországi barlang:");
            foreach (Cave cave in caves.LongestCaves(4))
            {
                Console.WriteLine($"\t{cave.Name} ({cave.City}): {cave.Length} m");
            }

            //12.
            Console.WriteLine("12. feladat:");
            ExportWithErrorHandling("megnemjartuk.csv", false);

            void ExportWithErrorHandling(string fileName, bool visited)
            {
                try
                {
                    caves.ExportFile(fileName, visited);
                    Console.WriteLine($"\tAdatok sikeresen kiírva a(z) \"{fileName}\" fájlba.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hiba lépett fel a fájlbaírás során: {ex.Message}");
                }
            }
        }
    }
}
