namespace XmasFair_Lib
{
    public class Good
    {
        public string Name { get; }
        public string ProductType { get; }
        public int Value { get; }

        public Good(string name, string productType, int value)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("A terméknek kell nevet adni.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(productType))
            {
                throw new ArgumentException("A termék típusát meg kell adni.", nameof(productType));
            }

            Name = name;
            ProductType = productType;
            Value = value < 0 ? 0 : value;
        }
    }
}
