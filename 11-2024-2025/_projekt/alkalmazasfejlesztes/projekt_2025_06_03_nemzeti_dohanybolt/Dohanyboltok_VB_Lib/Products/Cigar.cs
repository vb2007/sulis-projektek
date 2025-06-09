namespace Dohanyboltok_VB_Lib.Products
{
    public class Cigar : IProduct
    {
        public string Name { get; init; }
        public int Price { get; init; }
        public string Category => "Szivarka";
        public int Length { get; init; } // cm-ben

        public Cigar(string name, int price, int length)
        {
            Name = name;
            Price = price;
            Length = length;
        }
    }
}
