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
            Console.WriteLine($"\tMagasság: {favouriteCave.Heigth} m");
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
            Console.WriteLine($"7. feladat: Régies nevű barlangok száma: {caves.CavesWithOldNamesCount} db");
            Console.WriteLine($"Régies nevű barlangok nevei: \n\t{caves.CavesWithOldNamesString}");
        }
    }
}
