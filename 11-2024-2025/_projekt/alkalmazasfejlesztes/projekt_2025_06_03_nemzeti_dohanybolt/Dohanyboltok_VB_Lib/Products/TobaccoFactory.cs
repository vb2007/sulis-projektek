namespace Dohanyboltok_VB_Lib.Products
{
    public class TobaccoFactory
    {
        private readonly List<IProduct> products = new List<IProduct>();

        private static readonly Random rnd = new();
        private readonly List<string> CigaretteNames = new List<string> { "Marlboro Gold", "Yellow Camel", "Marlboro Blue Ice", "Pall Mall Gold", "Marlboro Red" };
        private readonly List<string> CigarNames = new List<string> { "Djarum Black Ruby", "Amigos Mini Filter", "Davidoff Demi Tasse", "Djarum Black Emerald", "Marlboro Leaf Beyond Blue" };

        public TobaccoFactory(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                products.Add(Create());
            }
        }

        private IProduct Create()
        {
            int cigaretteOrCigar = rnd.Next(0, 2);
            int price = rnd.Next(700, 2501); // 700-2500 Ft

            if (cigaretteOrCigar == 0) //cigaretta
            {
                int nicotineContent = rnd.Next(0, 21); // 0-20 mg
                string name = CigaretteNames[rnd.Next(CigaretteNames.Count)];

                return new Cigarette(name, price, nicotineContent);
            }
            else //szivarka
            {
                int length = rnd.Next(5, 31); // 5-30 cm
                string name = CigarNames[rnd.Next(CigarNames.Count)];

                return new Cigar(name, price, length);
            }
        }

        public IProduct CheapestProduct =>
            products
                .MinBy(x => x.Price);
    }
}
