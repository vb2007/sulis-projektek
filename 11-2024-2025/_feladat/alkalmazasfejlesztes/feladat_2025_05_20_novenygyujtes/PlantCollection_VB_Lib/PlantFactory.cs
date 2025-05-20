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
            int plantType = random.Next(3); //3 types: 0: flover, 1: herb, 2: mushroom

            switch (plantType)
            {
                case 0:
                    return new Flover(floverTypes[random.Next(floverTypes.Count)]);
                case 1:
                    return new Herb(herbTypes[random.Next(herbTypes.Count)]);
                case 2:
                    return new Mushroom(mushroomTypes[random.Next(mushroomTypes.Count)]);
                default:
                    throw new ArgumentOutOfRangeException(nameof(plantType), "Érvénytelen növénytípus.");
            }
        }
    }
}
