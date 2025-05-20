using System.Collections;
using System.Globalization;

namespace PlantCollection_VB_Lib
{
    public class PlantFactory : IEnumerable<IPlant>
    {
        private readonly List<IPlant> plants = new();
        private static readonly Random random = new();

        private List<string> floverTypes = new List<string> { "tulipán", "rózsa", "hóvirág", "muskátli", "nárcisz" };
        private List<string> herbTypes = new List<string> { "kamilla", "borsmenta", "citromfű" };
        private List<string> mushroomTypes = new List<string> { "rókagomba", "döggomba", "csiperke" };

        public IPlant[,] Matrix { get; }

        public PlantFactory(int matrixSize)
        {
            Matrix = new IPlant[matrixSize, matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    Matrix[i, j] = Create();
                    plants.Add(Matrix[i, j]);
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

        public Dictionary<string, int> GetCountByName =>
            plants
                .GroupBy(x => x.Name)
                .ToDictionary(x => x.Key, x => x.Count());

        public Dictionary<string, int> GetCountByType =>
            plants
                .GroupBy(x => x.Type)
                .ToDictionary(x => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(x.Key), x => x.Count());

        //hogy a Program.cs-ben működjön a foreach
        public IEnumerator<IPlant> GetEnumerator() => plants.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
