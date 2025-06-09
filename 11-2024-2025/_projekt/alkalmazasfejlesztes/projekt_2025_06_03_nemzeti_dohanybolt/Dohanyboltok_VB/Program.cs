using Dohanyboltok_VB_Lib;

namespace Dohanyboltok_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TobaccoStores tobaccoStores = new(File.ReadAllLines("tobaccostores.txt").Skip(1));

            Console.WriteLine($"5. feladat: Összesen {tobaccoStores.Count} dohánybolt adatai vannak eltárolva.");

            Console.WriteLine($"6. feladat: A dohányboltok összesített havi bevétele: {tobaccoStores.TotalMonthlyIncome} Ft");

            Dictionary<string, string> streetsAndProducts = tobaccoStores.StreetsAndProductsByCityName("Budapest");
            Console.WriteLine("7. feladat: A Budapesti dohányboltok utcáinak nevei és legnépszerűbb termékeik:");
            foreach (var storeData in streetsAndProducts)
            {
                Console.WriteLine($"\t{storeData.Key} - {storeData.Value}");
            }

            TobaccoStore storeWithMostTraffic = tobaccoStores.StoreWithMostTraffic;
            Console.WriteLine("8. feladat: A legformalmasabb dohánybolt adatai:");
            Console.WriteLine($"\tElhelyezkedése (város): {storeWithMostTraffic.City}");
            Console.WriteLine($"\tElhelyezkedése (utca): {storeWithMostTraffic.Street}");
            Console.WriteLine($"\tHavi bevétele: {storeWithMostTraffic.MonthlyIncome} Ft");
            Console.WriteLine($"\tForgalma: {storeWithMostTraffic.Traffic} ember/nap");
            Console.WriteLine($"\tLegnépszerűbb terméke: {storeWithMostTraffic.MostPopularProduct}");
        }
    }
}
