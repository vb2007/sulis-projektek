﻿using Dohanyboltok_VB_Lib;
using Dohanyboltok_VB_Lib.Products;

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

            //12. feladat
            TobaccoFactory tobaccoFactory = new(20);

            IProduct cheapestProduct = tobaccoFactory.CheapestProduct;
            Console.WriteLine("13. feladat: A legolcsóbb dohánytermék adatai:");
            Console.WriteLine($"\tKategória: {cheapestProduct.Category}");
            Console.WriteLine($"\tNév: {cheapestProduct.Name}");
            Console.WriteLine($"\tÁr: {cheapestProduct.Price} Ft");

            Console.Write("14. feladat: ");
            tobaccoFactory.WriteToFile("products.txt");

            Cigarette cigaretteWithMostNicotine = tobaccoFactory.CigaretteWithMostNicotine;
            Console.WriteLine("15. feladat: Legtöbb nikotint tartalmazó cigaretta:");
            Console.WriteLine($"\tNeve: {cigaretteWithMostNicotine.Name}");
            Console.WriteLine($"\tNikotintartalma: {cigaretteWithMostNicotine.NicotineContent} mg");
        }
    }
}
