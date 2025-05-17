namespace TreasureChest_VB_Lib
{
    public class TreasureFactory
    {
        public static readonly Random random = new();

        public ITreasure Create()
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
    }
}
