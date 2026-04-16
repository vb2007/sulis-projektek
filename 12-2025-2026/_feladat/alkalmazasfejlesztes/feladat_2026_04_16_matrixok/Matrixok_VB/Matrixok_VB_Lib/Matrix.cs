namespace Matrixok_VB_Lib;

public class Matrix
{
    private static int[,] _matrix = new int[10, 10];

    public static void WriteMatrix(string name, int[,] matrix)
    {
        Console.WriteLine($"Mátrix: {name}");
        
        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            for (int j = 0; j < _matrix.GetLength(1); j++)
            {
                Console.Write(_matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        Console.WriteLine("-----------------------------");
    }
    
    public static int[,] CreateNullMatrix()
    {
        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            for (int j = 0; j < _matrix.GetLength(1); j++)
            {
                _matrix[i, j] = 0;
            }
        }

        return _matrix;
    }

    public static int[,] CreateUnitMatrix()
    {
        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            for (int j = 0; j < _matrix.GetLength(1); j++)
            {
                if (i == j)
                {
                    _matrix[i, j] = 1;
                }
                else
                {
                    _matrix[i, j] = 0;
                }
            }
        }

        return _matrix;
    }
    
    public static int[,] CreateDiagonalMatrix()
    {
        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            for (int j = 0; j < _matrix.GetLength(1); j++)
            {
                if (i == j)
                {
                    _matrix[i, j] = Random.Shared.Next(0, 100);
                }
                else
                {
                    _matrix[i, j] = 0;
                }
            }
        }

        return _matrix;
    }
    
    public static int[,] CreateUpperTriangularMatrix()
    {
        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            for (int j = 0; j < _matrix.GetLength(1); j++)
            {
                if (i <= j)
                {
                    _matrix[i, j] = Random.Shared.Next(0, 100);
                }
                else
                {
                    _matrix[i, j] = 0;
                }
            }
        }

        return _matrix;
    }
}