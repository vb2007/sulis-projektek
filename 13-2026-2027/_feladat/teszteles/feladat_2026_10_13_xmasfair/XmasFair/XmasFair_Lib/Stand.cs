namespace XmasFair_Lib
{
    public class Stand
    {
        public string Name { get; }
        public List<string> ProductTypes { get; }

        public Stand(string name, string productType)
            : this(name, new List<string> { productType })
        {

        }

        public Stand(string name, List<string> productTypes)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("A bódénak kell nevet adni.", nameof(name));
            if (productTypes == null || productTypes.Count == 0 || productTypes.Any(string.IsNullOrWhiteSpace))
                throw new ArgumentException("A bódénak legalább egy terméktípust meg kell adni.", nameof(productTypes));

            Name = name;
            ProductTypes = new List<string>(productTypes);
        }
    }
}
