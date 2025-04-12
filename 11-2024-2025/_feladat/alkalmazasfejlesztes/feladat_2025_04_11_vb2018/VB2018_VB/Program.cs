using VB2018_VB_Lib;

namespace VB2018_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stadions stadions = new(File.ReadLines("vb2018.txt").Skip(1));

            foreach (var stadion in stadions.stadions)
            {
                Console.WriteLine($"Város: {stadion.City}, Név1: {stadion.Name1}, Név2: {stadion.Name2}, Férőhely: {stadion.Capacity}");
            }

            Console.WriteLine($"2. Feladat: {stadions.NumberOfStadions} stadionban játszották a VB mérkőzéseit.");

            Stadion stadionWithLeastCapacity = stadions.StadionWithLeastCapacity;
            Console.WriteLine($"3. Feladat: Legkevesebb férőhellyel rendelkező stadion adatai:\n\tVárosa: {stadionWithLeastCapacity.City}\n\tNeve: {stadionWithLeastCapacity.Name1}\n\tAlternatív neve: {stadionWithLeastCapacity.Name2}\n\tFérőhelye: {stadionWithLeastCapacity.Capacity}");

            Console.WriteLine($"4. Feladat: Stadionok átlag férőhelye: {stadions.StadionsAverageCapacity}");

            Console.WriteLine($"5. Feladat: {stadions.NumberOfStadionsWithAlernativeNames} stadion rendelkezik alternatív névvel.");

            Console.WriteLine($"6. Feladat: {stadions.NumberOfStadionsThatContainAName("Aréna")} db stadion nevében szerepel az \"Aréna\" szó.");
        }
    }
}
