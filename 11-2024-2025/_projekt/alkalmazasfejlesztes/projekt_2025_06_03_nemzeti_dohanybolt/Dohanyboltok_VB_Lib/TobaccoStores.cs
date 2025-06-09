namespace Dohanyboltok_VB_Lib
{
    public class TobaccoStores
    {
        private readonly List<TobaccoStore> tobaccoStores = new();

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
                .Where(store => store.City.Equals(cityName, StringComparison.OrdinalIgnoreCase))
                .ToDictionary(store => store.Street, store => store.MostPopularProduct);
    }
}
