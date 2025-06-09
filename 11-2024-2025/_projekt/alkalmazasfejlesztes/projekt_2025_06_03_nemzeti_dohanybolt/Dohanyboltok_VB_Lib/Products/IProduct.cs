namespace Dohanyboltok_VB_Lib.Products
{
    public interface IProduct
    {
        string Name { get; }
        int Price { get; }
        string Category { get; }

        string ToString() => $"{Category}: {Name}, Ár: {Price} Ft";
    }
}
