namespace Varosok_VB_Lib
{
    public class Cities
    {
        private readonly List<City> citiesList = new();

        public Cities(IEnumerable<string> dataLines)
        {
            foreach (var item in dataLines)
            {
                citiesList.Add(new City(item));
            }
        }

        public IEnumerable<City> List => citiesList;

        public Dictionary<int, int> NumberOfCitiesByYear =>
            citiesList.GroupBy(x => x.Date.Year)
            .ToDictionary(x => x.Key, x => x.Count())
            .OrderBy(x => x.Key).ToDictionary();
    }
}
