namespace Dohanyboltok_VB_Lib.Products
{
    public class Cigar : IProduct
    {
        public string Name { get; init; }
        public int Price { get; init; }
        public string Category => "Cigar";
    }
}
