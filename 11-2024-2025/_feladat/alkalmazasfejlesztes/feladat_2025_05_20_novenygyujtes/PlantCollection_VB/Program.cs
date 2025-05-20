using PlantCollection_VB_Lib;

namespace PlantCollection_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = 5;
            PlantFactory plants = new PlantFactory(matrixSize);

            //7. Feladat
            Console.WriteLine("7. feladat: Növények gyűjteménye:");
            for (int i = 0; i < plants.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < plants.Matrix.GetLength(1); j++)
                {
                    Console.Write(plants.Matrix[i, j].Display + " ");
                }
                Console.WriteLine();
            }

            //8. Feladat
            Console.WriteLine($"\n8. feladat: {matrixSize}x{matrixSize} terülten található a növények összértéke.");

            //9. Feladat
            Console.WriteLine($"\n9. feladat: Növények név szerint csoportosítva:");
            IDictionary<string, int> plantCountsByName = plants.GetCountByName;
            foreach (var plant in plantCountsByName)
            {
                Console.WriteLine($"{plant.Key}: {plant.Value}");
            }

            //10. Feladat
            Console.WriteLine($"\n10. feladat: Növények típus szerint csoportosítva:");
            IDictionary<string, int> plantCountsByType = plants.GetCountByType;
            foreach (var plant in plantCountsByType)
            {
                Console.WriteLine($"{plant.Key}: {plant.Value}");
            }
        }
    }
}
