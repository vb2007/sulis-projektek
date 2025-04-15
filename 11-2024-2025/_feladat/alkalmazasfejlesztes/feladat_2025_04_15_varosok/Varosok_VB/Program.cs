using Varosok_VB_Lib;

internal class Program
{
    private static void Main(string[] args)
    {
        Cities cities = new(File.ReadAllLines("varosok.csv").Skip(1));

        //foreach (City city in cities.List)
        //{
        //    Console.WriteLine(city);
        //}

        Console.WriteLine($"2. feladat: Városok száma évenként:");
        foreach (var item in cities.NumberOfCitiesByYear)
        {
            Console.WriteLine($"\t{item.Key} - {item.Value}");
        }
    }
}