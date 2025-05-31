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
            Console.WriteLine($"7. feladat: Hiányos állomásnevek:\n\t{trips.IncorrectNamesString}");

            //8. feladat
            int startElevation = int.Parse(File.ReadLines("kektura.csv").First());
            var (highestEndPoint, highestElevation) = trips.GetHighestEndPoint(startElevation);
            Console.WriteLine($"8. feladat: A túra legmagasabban fekvő végpontja:");
            Console.WriteLine($"\tA végpont neve: {highestEndPoint}");
            Console.WriteLine($"\tA végpont engerszint feletti magassága: {highestElevation} m");

            //9. feladat
            trips.WriteToCsv("kektura2.csv", startElevation);
        }
    }
}
