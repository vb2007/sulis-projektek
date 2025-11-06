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

        int colLength = matrix.GetLength(0);
        int rowLength = matrix.GetLength(1);

        //https://stackoverflow.com/questions/9404683/how-to-get-the-length-of-row-column-of-multidimensional-array-in-c
        Console.WriteLine("1. feladat:");

        //Táblázat headere
        Console.Write("".PadRight(8));
        for (int i = 0; i < rowLength; i++)
        {
            Console.Write($"\t{i + 1}. mérés".PadRight(8));
        }
        Console.WriteLine();

        //Táblázat értékei
        for (int i = 0; i < colLength; i++)
        {
            Console.Write($"{i + 1}. nap:".PadRight(8));
            for (int j = 0; j < rowLength; j++)
            {
                Console.Write($"\t{matrix[i, j]}".PadRight(16));
            }
            Console.WriteLine();
        }

        int sum = 0;
        for (int i = 0; i < colLength; i++)
        {
            for (int j = 0; j < rowLength; j++)
            {
                sum += matrix[i, j];
            }
        }

        double avg = Math.Round((double)sum / (colLength * rowLength), 2);
        Console.WriteLine($"\n2. feladat: Az átlagos hőméréklet: {avg} fok");

        Console.WriteLine("\n3. feladat: Az átlaghőmérséklet naponként:");
        for (int i = 0; i < colLength; i++)
        {
            int rowSum = 0;
            for (int j = 0; j < rowLength; j++)
            {
                rowSum += matrix[i, j];
            }

            double rowAvg = Math.Round((double)rowSum / rowLength, 2);
            Console.WriteLine($"\t{i + 1}. nap: {rowAvg} fok");
        }

        int belowCout = 0;
        for (int i = 0; i < colLength; i++)
        {
            for (int j = 0; j < rowLength; j++)
            {
                if (matrix[i, j] < 10)
                {
                    belowCout++;
                }
            }
        }

        Console.WriteLine($"\n4. feladat: {belowCout} alkalommal volt 10 fok alatt a hőmérséklet");

        int belowCountDays = 0;
        for (int i = 0; i < colLength; i++)
        {
            for (int j = 0; j < rowLength; j++)
            {
                if (matrix[i, j] < 10)
                {
                    belowCountDays++;
                    break;
                }
            }
        }

        Console.WriteLine($"\n5. feladat: {belowCountDays} nap volt 10 fok alatt a hőmérséklet.");

        int maxDay = 0;
        int maxRecord = 0;
        int maxValue = 0;
        for (int i = 0; i < colLength; i++)
        {
            for (int j = 0; j < rowLength; j++)
            {
                if (matrix[i, j] > maxValue)
                {
                    maxValue = matrix[i, j];
                    maxDay = i + 1;
                    maxRecord = j + 1;
                }
            }
        }

        Console.WriteLine($"\n6. feladat: {maxDay}. nap {maxRecord}. méréskor volt a legmagasabb a hőmérséklet: {maxValue} fok");

        Console.Write($"\n7. Feladat: Keresett hőmérséklet érték: ");
        int seekedValue = int.Parse(Console.ReadLine()!);

        int seekedDay = 0;
        int seekedRecord = 0;
        for (int i = 0; i < colLength; i++)
        {
            for (int j = 0; j < rowLength; j++)
            {
                if (matrix[i, j] == seekedValue)
                {
                    seekedDay = i + 1;
                    seekedRecord = j + 1;
                    break;
                }
            }

            //https://stackoverflow.com/questions/2339142/how-to-break-out-of-multiple-loops-at-once-in-c
            //Ha már talált egy értéket (feltéve hogy a feladat az első értékre kíváncsi)
            if (seekedRecord != 0 && seekedDay != 0)
            {
                break;
            }
        }

        if (seekedDay != 0 && seekedRecord != 0)
        {
            Console.WriteLine($"\tVolt ilyen mérés: {seekedDay}. nap {seekedRecord}. mérése");
        }
        else
        {
            Console.WriteLine($"\tNem volt ilyen mérés");
        }
    }
}
