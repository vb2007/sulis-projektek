namespace Dohanyboltok_VB_Lib.Products
{
    public class TobaccoFactory
    {
        private readonly List<IProduct> products = new List<IProduct>();

        private static readonly Random rnd = new();
        private readonly List<string> CigaretteNames = new List<string> { "Marlboro Gold", "Yellow Camel", "Marlboro Blue Ice", "Pall Mall Gold", "Marlboro Red" };
        private readonly List<string> CigarNames = new List<string> { "Djarum Black Ruby", "Amigos Mini Filter", "Davidoff Demi Tasse", "Djarum Black Emerald", "Marlboro Leaf Beyond Blue" };

        public TobaccoFactory()
        {

        }
    }
}
