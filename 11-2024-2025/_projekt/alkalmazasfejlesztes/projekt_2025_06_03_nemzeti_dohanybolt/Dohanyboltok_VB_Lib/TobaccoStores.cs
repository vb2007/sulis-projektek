namespace Dohanyboltok_VB_Lib
{
    public class TobaccoStores
    {
        private readonly List<TobaccoStore> tobaccoStores = new List<TobaccoStore>();

        public TobaccoStores(IEnumerable<string> dataLines)
        {
            foreach (var store in dataLines)
            {
                tobaccoStores.Add(new(store));
            }
        }

        public int Count => tobaccoStores.Count;

        public int TotalMonthlyIncome =>
            tobaccoStores
                .Sum(x => x.MonthlyIncome);

        public Dictionary<string, string> StreetsAndProductsByCityName(string cityName) =>
            tobaccoStores
                .Where(x => x.City.Equals(cityName, StringComparison.OrdinalIgnoreCase))
                .ToDictionary(x => x.Street, y => y.MostPopularProduct);

        public TobaccoStore StoreWithMostTraffic =>
            tobaccoStores
                .MaxBy(x => x.Traffic);
    }
}
