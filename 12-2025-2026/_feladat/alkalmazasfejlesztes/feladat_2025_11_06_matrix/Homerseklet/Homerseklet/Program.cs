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
        Console.Write("".PadRight(8));
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            Console.Write($"\t{i + 1}. mérés".PadRight(8));
        }
        Console.WriteLine();
        
        //Táblázat értékei
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.Write($"{i + 1}. nap:".PadRight(8));
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"\t{matrix[i, j]}".PadRight(16));
            }
            Console.WriteLine();
        }

        int sum = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sum += matrix[i, j];
            }
        }

        double avg = Math.Round((double)sum / (matrix.GetLength(0) * matrix.GetLength(1)), 2);
        Console.WriteLine($"\n2. feladat: Az átlagos hőméréklet: {avg} fok");

        Console.WriteLine("\n3. feladat: Az átlaghőmérséklet naponként:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int rowSum = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                rowSum += matrix[i, j];
            }
            
            double rowAvg = Math.Round((double)rowSum / matrix.GetLength(1), 2);
            Console.WriteLine($"\t{i + 1}. nap: {rowAvg} fok");
        }

        int belowCount = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < 10)
                {
                    belowCount++;
                }
            }
        }
        
        Console.WriteLine($"\n4. feladat: {belowCount} alkalommal volt 10 fok alatt a hőmérséklet");
    }
}