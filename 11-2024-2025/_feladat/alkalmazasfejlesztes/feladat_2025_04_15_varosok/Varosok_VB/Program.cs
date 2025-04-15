using Varosok_VB_Lib;

internal class Program
{
    private static void Main(string[] args)
    {
        Cities cities = new(File.ReadAllLines("varosok.csv").Skip(1));

        foreach (City city in cities.List)
        {
            Console.WriteLine(city);
        }

        Console.WriteLine($"2. feladat: Városok száma évenként:");
        foreach (var item in cities.NumberOfCitiesByYear)
        {
            Console.WriteLine($"\t{item.Key} - {item.Value}");
        }

        Console.WriteLine($"3. feladat: Városok száma: {cities.NumberOfCities} db");

        Console.WriteLine($"4. feladat: Indiai nagyvárosok lakosságának összege: {cities.TotalPopulationByCountryName("India")} fő");

        City cityWithLargestPopulation = cities.CityWithLargestPopulation;
        Console.WriteLine($"5. feladat: A legnagyobb lakosságú város adatai:\n\tNév: {cityWithLargestPopulation.Name}\n\tOrszág: {cityWithLargestPopulation.Country}\n\tLakosság: {cityWithLargestPopulation.ThousandPeople} ezer fő");

        Console.Write($"8. feladat: Adja meg legalább hány millió lakossal rendelkező városok számára kíváncsi: ");
        int millions = int.Parse(Console.ReadLine()!);
        Console.WriteLine($"\tA legalább {millions} millió lakossal rendelkező városok száma: {cities.NumberOfCitiesWithGivenPopulation(millions)} db");

        //10. feladat
        void WriteToFile(string fileName)
        {
            StreamWriter streamWriter = new(fileName);

            foreach (var item in cities.MostPopulatedCities(5))
            {
                streamWriter.WriteLine(item);
            }

            streamWriter.Close();
            Console.WriteLine($"10. feladat: Adatok sikeresen kiírva a(z) \"{fileName}\" fájlba.");
        }

        WriteToFile("otlegnagyobb.txt");
    }
}