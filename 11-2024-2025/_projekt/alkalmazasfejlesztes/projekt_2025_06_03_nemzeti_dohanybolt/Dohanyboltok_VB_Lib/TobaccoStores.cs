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
    }
}
