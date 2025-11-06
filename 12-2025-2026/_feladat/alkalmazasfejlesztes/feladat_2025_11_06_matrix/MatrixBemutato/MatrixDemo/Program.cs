namespace MatrixDemo;

class Program
{
    static void Main(string[] args)
    {
        int[,] matrix = new int[5, 5];

        //Szimpla random számokkal feltöltés
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                matrix[i, j] = Random.Shared.Next(10, 50);
            }
        }

        //Sorösszeg számolás
        int[] sorokOsszege = new int[5];
        for (int i = 0; i < 5; i++)
        {
            int osszeg = 0;
            for (int j = 0; j < 5; j++)
            {
                osszeg += matrix[i, j];
            }
            sorokOsszege[i] = osszeg;
        }

        //Átlósan csak nullákkal feltöltés
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i == j)
                {
                    matrix[i, j] = 0;
                }
                else
                {
                    matrix[i, j] = Random.Shared.Next(10, 20);
                }
            }
        }
        
        //Felső háromszög
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i < j)
                {
                    matrix[i, j] = 0;
                }
                else
                {
                    matrix[i, j] = Random.Shared.Next(10, 20);
                }
            }
        }
        
        //Alsó háromszög
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i > j)
                {
                    matrix[i, j] = 0;
                }
                else
                {
                    matrix[i, j] = Random.Shared.Next(10, 20);
                }
            }
        }
        
        //Alsó háromszög összege
        int osszeg = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i >= j)
                {
                    osszeg += matrix[i, j];
                }
            }
        }
        //Generikus matrixkiírás
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write($"{matrix[i, j]} | ");
            }

            Console.WriteLine($"Összeg: {sorokOsszege[i]}");
            Console.WriteLine();
        }
        Console.WriteLine($"Alsó háromszög összege: {osszeg}");
    }
}