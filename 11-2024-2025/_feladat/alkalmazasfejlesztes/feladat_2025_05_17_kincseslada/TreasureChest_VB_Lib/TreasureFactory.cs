using System.Collections;

namespace TreasureChest_VB_Lib
{
    public class TreasureFactory : IEnumerable<ITreasure>
    {
        private readonly List<ITreasure> treasures = new();

        private static readonly Random random = new();

        public TreasureFactory(int numberOfTreasures)
        {
            for (int i = 0; i < numberOfTreasures; i++)
            {
                treasures.Add(Create());
            }
        }

        private ITreasure Create()
        {
            int treasureType = random.Next(2);

            if (treasureType == 0)
            {
                // Érme: 0=arany, 1=ezüst, 2=réz
                int coinType = random.Next(3);
                return new Coin(coinType);
            }
            else
            {
                // Drágakő: 0=Sapphire, 1=Emerald, 2=Diamond; size 0=Small, 1=Medium, 2=Large
                int gemType = random.Next(3);
                int gemSize = random.Next(3);
                return new Gem(gemType, gemSize);
            }
        }

        public int TotalValue =>
            treasures.Sum(x => x.Value);

        public IDictionary<string, int> ContentByName =>
            treasures
            .GroupBy(x => x.Name)
            .OrderBy(x => x.Key)
            .ToDictionary(x => x.Key.ToLower(), x => x.Count());

        //hogy a Program.cs-ben működjön a foreach
        public IEnumerator<ITreasure> GetEnumerator() => treasures.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
