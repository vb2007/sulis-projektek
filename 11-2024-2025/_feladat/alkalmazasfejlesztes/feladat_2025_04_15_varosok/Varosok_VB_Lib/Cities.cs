namespace Varosok_VB_Lib
{
    public class Cities
    {
        private readonly List<City> citiesList = new();

        public Cities(IEnumerable<string> dataLines)
        {
            foreach (var item in dataLines)
            {
                citiesList.Add(new (item));
            }
        }

        public IEnumerable<City> List => citiesList;

        public Dictionary<int, int> NumberOfCitiesByYear =>
            citiesList.GroupBy(x => x.Date.Year)
            .ToDictionary(x => x.Key, x => x.Count())
            .OrderBy(x => x.Key).ToDictionary();

        public int NumberOfCities => citiesList.Count();

        public int TotalPopulationByCountryName(string countryName) =>
            (int)citiesList
                .Where(x => x.Country.Equals(countryName, StringComparison.OrdinalIgnoreCase))
                .Sum(x => x.Population);

        public City CityWithLargestPopulation => citiesList.MaxBy(x => x.Population);

        public bool IsThereACityFromThatCountry(string country) =>
            citiesList.Any(x => x.Country.Equals(country, StringComparison.OrdinalIgnoreCase));

        private List<string> CitiesFromThatCountry(string country) =>
            citiesList
                .Where(x => x.Country.Equals(country, StringComparison.OrdinalIgnoreCase))
                .Select(x => x.Name)
                .OrderBy(x => x)
                .ToList();
        public string CitiesFromThatCountryString(string country) => string.Join(';', CitiesFromThatCountry(country));

        public int NumberOfCitiesWithGivenPopulation(int tousands) =>
            citiesList.Count(x => x.Population >= tousands * 1000);

        private List<string> Countries => 
            citiesList
                .Select(x => x.Country)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
        public string CountriesString => string.Join(';', Countries);

        public IEnumerable<City> MostPopulatedCities(int count) =>
            citiesList.OrderByDescending(x => x.Population).Take(count);
    }
}
