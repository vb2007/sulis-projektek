namespace Homerseklet;

class Program
{
    static void Main(string[] args)
    {
        IEnumerable<string> lines = File.ReadAllLines("homerseklet.txt").Skip(1);
        int[,] matrix = new int[lines.Count(), 5]; //oszlopszám hardcoded mert lusta vagyok kiszámolni

        int lineCount = 0;
        foreach (var line in lines)
        {
            string[] columns = line.Split(' ');
            
            int columnCount = 0;
            foreach (var column in columns)
            {
                matrix[lineCount, columnCount] = int.Parse(column);
                columnCount++;
            }
            lineCount++;
        }

        //https://stackoverflow.com/questions/9404683/how-to-get-the-length-of-row-column-of-multidimensional-array-in-c
        Console.WriteLine("1. feladat:");
        
        //Táblázat headere
        Console.Write("\t");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.Write($"\t{i + 1}. mérés");
        }
        Console.WriteLine();
        
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.Write($"{i + 1}. nap:");
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"\t{matrix[i, j]}");
            }
            Console.WriteLine();
        }
    }
}