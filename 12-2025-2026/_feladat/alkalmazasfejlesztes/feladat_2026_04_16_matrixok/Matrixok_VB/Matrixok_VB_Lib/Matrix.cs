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
    
    public static int[,] CreateLowerTriangularMatrix()
    {
        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            for (int j = 0; j < _matrix.GetLength(1); j++)
            {
                if (i >= j)
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
    
    public static int[,] CreateSymmetricMatrix()
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
                    _matrix[i, j] = _matrix[j, i];
                }
            }
        }

        return _matrix;
    }
    
    //Programozási tételek
    
    public static int MatrixSum (int[,] matrix)
    {
        int sum = 0;
        
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sum += matrix[i, j];
            }
        }

        return sum;
    }
    
    public static int MatrixAverage (int[,] matrix)
    {
        int sum = MatrixSum(matrix);
        int count = matrix.GetLength(0) * matrix.GetLength(1);
        
        return sum / count;
    }
    
    public static int MatrixEvenNumbersCount (int[,] matrix)
    {
        int count = 0;
        
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] % 2 == 0)
                {
                    count++;
                }
            }
        }

        return count;
    }
    
    public static (int number, int i, int j) MatrixMaxNumber (int[,] matrix)
    {
        int max = matrix[0, 0];
        int maxRow = 0;
        int maxCol = 0;
        
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    maxRow = i + 1;
                    maxCol = j + 1;
                }
            }
        }

        return (max, maxRow, maxCol);
    }
    
    public static (int number, int i, int j) MatrixMinNumber (int[,] matrix)
    {
        int min = matrix[0, 0];
        int minRow = 0;
        int minCol = 0;
        
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    minRow = i + 1;
                    minCol = j + 1;
                }
            }
        }

        return (min, minRow, minCol);
    }
    
    public static bool DoesContainNumberDividedBy (int[,] matrix, int devider)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] % devider == 0)
                {
                    return true;
                }
            }
        }

        return false;
    }
    
    public static (int number, int i, int j) MatrixDivideByNumber (int[,] matrix, int devider)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] % devider == 0)
                {
                    return (matrix[i, j], i + 1, j + 1);
                }
            }
        }

        return (-1, -1, -1);
    }
}