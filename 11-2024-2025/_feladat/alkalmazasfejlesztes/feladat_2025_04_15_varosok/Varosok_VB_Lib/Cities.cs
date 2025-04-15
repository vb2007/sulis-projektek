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

        //public bool IsThereSuchACountry(string country) =>
        //    citiesList.Contains(x => x.Country);

        public int NumberOfCitiesWithGivenPopulation(int millions) =>
            citiesList.Count(x => x.Population >= millions * 1000000);

        public IEnumerable<City> MostPopulatedCities(int count) =>
            citiesList.OrderByDescending(x => x.Population).Take(count);
    }
}
