int size = 10;

// Nullmátrix
Console.WriteLine("Nullmátrix:");
int[,] nullMatrix = new int[size, size];
FillNullMatrix(nullMatrix);
PrintMatrix(nullMatrix);

// Egységmátrix
Console.WriteLine("\nEgységmátrix:");
int[,] identityMatrix = new int[size, size];
FillIdentityMatrix(identityMatrix);
PrintMatrix(identityMatrix);

// Diagonálismátrix
Console.WriteLine("\nDiagonálismátrix:");
int[,] diagonalMatrix = new int[size, size];
FillDiagonalMatrix(diagonalMatrix);
PrintMatrix(diagonalMatrix);

// Felső háromszögmátrix
Console.WriteLine("\nFelső háromszögmátrix:");
int[,] upperTriangularMatrix = new int[size, size];
FillUpperTriangularMatrix(upperTriangularMatrix);
PrintMatrix(upperTriangularMatrix);

// Alsó háromszögmátrix
Console.WriteLine("\nAlsó háromszögmátrix:");
int[,] lowerTriangularMatrix = new int[size, size];
FillLowerTriangularMatrix(lowerTriangularMatrix);
PrintMatrix(lowerTriangularMatrix);

// Szimetrikusmátrix
Console.WriteLine("\nSzimetrikusmátrix:");
int[,] symetricMatrix = new int[size, size];
FillSymmetricMatrix(symetricMatrix);
PrintMatrix(symetricMatrix);

static void FillNullMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = 0;
        }
    }
}

static void FillIdentityMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (i == j)
            {
                matrix[i, j] = 1;
            }
            else
            {
                matrix[i, j] = 0;
            }
        }
    }
}


static void FillDiagonalMatrix(int[,] matrix)
{
    Random random = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (i == j)
            {
                matrix[i, j] = random.Next(1, 11);
            }
            else
            {
                matrix[i, j] = 0;
            }
        }
    }
}

static void FillUpperTriangularMatrix(int[,] matrix)
{
    Random random = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (i <= j)
            {
                matrix[i, j] = random.Next(1, 11);
            }
            else
            {
                matrix[i, j] = 0;
            }
        }
    }
}

static void FillLowerTriangularMatrix(int[,] matrix)
{
    Random random = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (i >= j)
            {
                matrix[i, j] = random.Next(1, 11);
            }
            else
            {
                matrix[i, j] = 0;
            }
        }
    }
}

static void FillSymmetricMatrix(int[,] matrix)
{
    Random random = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (i <= j)
            {
                int value = random.Next(1, 100);
                matrix[i, j] = value;
                matrix[j, i] = value;
            }
        }
    }
}


static void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(" " + matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
}