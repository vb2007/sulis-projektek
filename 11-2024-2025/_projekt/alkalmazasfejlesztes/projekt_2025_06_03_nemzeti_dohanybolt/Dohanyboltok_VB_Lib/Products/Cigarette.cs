namespace Dohanyboltok_VB_Lib.Products
{
    public class Cigarette : IProduct
    {
        public string Name { get; init; }
        public int Price { get; init; }
        public string Category => "Cigarette";
        public int NicotineContent { get; init; } // mg-ban

        public Cigarette(string name, int price, int nicotineContent)
        {
            Name = name;
            Price = price;
            NicotineContent = nicotineContent;
        }
    }
}
