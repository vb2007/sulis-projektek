namespace PlantCollection_VB_Lib
{
    public class PlantFactory
    {
        private readonly List<IPlant> plants = new();
        private static readonly Random random = new();

        private List<string> floverTypes = new List<string> { "tulipán", "rózsa", "hóvirág", "muskátli", "nárcisz" };
        private List<string> herbTypes = new List<string> { "kamilla", "borsmenta", "citromfű" };
        private List<string> mushroomTypes = new List<string> { "rókagomba", "döggomba", "csiperke" };

        public PlantFactory(int matrixSize)
        {
            IPlant[,] matrix = new IPlant[matrixSize, matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = Create();
                }
            }
        }

        public IPlant Create()
        {
            int plantType = random.Next(3); //3 types: 0, 1, 2

            switch (plantType)
            {
                case 0:
                    return new Flover();
                case 1:
                    return new Herb()
                case 2:
                    return new Mushroom();
                default:
                    throw new ArgumentOutOfRangeException(nameof(plantType), "Érvénytelen növénytípus.");
            }
        }
    }
}
