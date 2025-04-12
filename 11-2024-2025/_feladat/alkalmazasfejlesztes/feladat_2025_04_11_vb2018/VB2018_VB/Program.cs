using VB2018_VB_Lib;

namespace VB2018_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stadions stadions = new(File.ReadLines("vb2018.txt").Skip(1));

            Console.WriteLine($"2. Feladat: {stadions.NumberOfStadions} stadionban játszották a VB mérkőzéseit.");

            Stadion stadionWithLeastCapacity = stadions.StadionWithLeastCapacity;
            Console.WriteLine($"3. Feladat: Legkevesebb férőhellyel rendelkező stadion adatai:\n\tVárosa: {stadionWithLeastCapacity.City}\n\tNeve: {stadionWithLeastCapacity.Name1}\n\tAlternatív neve: {stadionWithLeastCapacity.Name2}\n\tFérőhelye: {stadionWithLeastCapacity.Capacity}");
        }
    }
}
