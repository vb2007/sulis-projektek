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

        Console.WriteLine($"6. feladat: {(cities.IsThereACityFromThatCountry("Magyarország") ? "Van" : "Nincs")} magyar város az adatok között");

        //Kínai városok nevei
        Console.WriteLine($"7. feladat: {cities.CitiesFromThatCountryString("Kína")}");

        Console.Write($"8. feladat: Adja meg legalább hány ezer lakossal rendelkező városok számára kíváncsi: ");
        int thousands = int.Parse(Console.ReadLine()!);
        Console.WriteLine($"\tA legalább {thousands} ezer lakossal rendelkező városok száma: {cities.NumberOfCitiesWithGivenPopulation(thousands)} db");

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