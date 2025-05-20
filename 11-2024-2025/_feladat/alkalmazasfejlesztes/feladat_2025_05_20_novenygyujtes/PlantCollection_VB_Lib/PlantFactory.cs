namespace PlantCollection_VB_Lib
{
    public class PlantFactory
    {
        private readonly List<IPlant> plants = new();
        private static readonly Random random = new();

        public PlantFactory(int matrixSize)
        {
            char[,] matrix = new char[matrixSize, matrixSize];
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
                    plants.Add(new Flover());
                    break;
                case 1:
                    plants.Add(new Herb());
                    break;
                case 2:
                    plants.Add(new Mushroom());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(plantType), "Érvénytelen növénytípus.");
            }
        }
    }
}
