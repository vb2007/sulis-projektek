using Kektura_VB_Lib;

namespace Kektura_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Trips trips = new(File.ReadAllLines("kektura.csv").Skip(1));

            //3. feladat
            Console.WriteLine($"3. feladat: Szakaszok száma: {trips.Count} db");

            //4. feladat
            Console.WriteLine($"4. feladat: A túra teljes hossza: {trips.FullLength} km");

            //5. feladat
            Trip shortestTrip = trips.ShortestTrip;
            Console.WriteLine($"5. feladat: A legrövidebb szakasz adatai:");
            Console.WriteLine($"\tKedete: {shortestTrip.StartPoint}");
            Console.WriteLine($"\tVége: {shortestTrip.EndPoint}");
            Console.WriteLine($"\tTávolság: {shortestTrip.Length} km");

            //6. + 7. feladat
        }
    }
}
