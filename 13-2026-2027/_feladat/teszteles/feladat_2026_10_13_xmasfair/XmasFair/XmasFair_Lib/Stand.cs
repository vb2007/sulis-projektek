namespace XmasFair_Lib
{
    public class Stand
    {
        public string Name { get; }
        public List<string> ProductTypes { get; }

        public Stand(string name, string productType)
            : this(name, new List<string> { productType }) { }

        public Stand(string name, List<string> productTypes)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("A bódénak kell nevet adni.", nameof(name));
            }
            
            if (productTypes == null || productTypes.Count == 0 || productTypes.Any(string.IsNullOrWhiteSpace))
            {
                throw new ArgumentException("A bódénak legalább egy terméktípust meg kell adni.", nameof(productTypes));
            }
            
            Name = name;
            ProductTypes = new List<string>(productTypes);
        }

        private readonly List<Good> goods = new List<Good>();

        public int NumGoods => goods.Count;

        public void Add(Good good)
        {
            if (!ProductTypes.Contains(good.ProductType))
            {
                throw new ArgumentException("A bódé nem árul ilyen típusú terméket.", nameof(good));
            }

            if (goods.Any(g => g.Name == good.Name))
            {
                throw new ArgumentException("Ilyen nevű termék már hozzá lett adva.", nameof(good));
            }

            goods.Add(good);
        }

        public int DailyIncome { get; private set; }

        public bool Sell(string name, int quantity)
        {
            Good? good = goods.FirstOrDefault(g => g.Name == name);
            if (good == null)
            {
                throw new ArgumentException("A bódé nem árul ilyen nevű terméket.", nameof(name));
            }

            if (quantity <= 0)
            {
                return false;
            }

            DailyIncome += good.Value * quantity;
            return true;
        }
    }
}
