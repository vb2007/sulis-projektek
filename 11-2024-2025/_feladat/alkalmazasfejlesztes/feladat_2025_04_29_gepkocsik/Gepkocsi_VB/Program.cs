using Gepkocsi_VB_Lib;

namespace Gepkocsi_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicles vehicles = new(File.ReadAllLines("autok.txt").Skip(1));

            Console.WriteLine("3. feladat:");
            Console.WriteLine($"Összesen {vehicles.Count} db gépkocsi adatait olvastam be.");

            Console.WriteLine("5. feladat");
            Console.WriteLine($"A vidéki autók száma {(vehicles.ruralCount > vehicles.budapestCount ? "több" : "kevesebb")}, mint a Budapesti autóké.");
        }
    }
}
