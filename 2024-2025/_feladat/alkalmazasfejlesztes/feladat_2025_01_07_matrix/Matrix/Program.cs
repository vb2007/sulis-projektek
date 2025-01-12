#region 1. Feladat
Random rnd = new Random();
int sorokSzama = int.Parse(Console.ReadLine()!);
int oszlopokSzama = int.Parse(Console.ReadLine()!);

int[,] randomMatrix = new int[sorokSzama, oszlopokSzama];

for (int i = 0; i < sorokSzama; i++)
{
    for (int j = 0; j < oszlopokSzama; j++)
    {
        randomMatrix[i, j] = rnd.Next(0, 101);
    }
}

for (int i = 0; i < sorokSzama; i++)
{
    for (int j = 0; j < oszlopokSzama; j++)
    {
        Console.WriteLine($"{i+1}. sor {j+1}. eleme: {randomMatrix[i, j]}");
    }
}
#endregion

#region 2. Feladat
string[,] matrix2 = new string[3, 3];

matrix2[0, 0] = "Mario";
matrix2[0, 1] = "Dzsulio";
matrix2[0, 2] = "Gáspár";
matrix2[1, 0] = "Jamal";
matrix2[1, 1] = "Armando";
matrix2[1, 2] = "Ricardo";
matrix2[2, 0] = "Lakaot";
matrix2[2, 1] = "Zsoltika";
matrix2[2, 2] = "Győző";

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.WriteLine($"{i + 1}. sor {j + 1}. eleme: {matrix2[i, j]}");
    }
}
#endregion

#region 3. Feladat
int sorokSzama3 = 6;
int[][] j_tomb = new int[sorokSzama3][];

for (int i = 0; i < 6; i++)
{
    int sorHosszusag = rnd.Next(3, 10);
    j_tomb[i] = new int[sorHosszusag];

    for (int j = 0; j < sorHosszusag; j++)
    {
        j_tomb[i][j] = rnd.Next(0, 10);
    }
}

for (int i = 0; i < sorokSzama3; i++)
{
    Console.WriteLine();
    for (int j = 0; j < j_tomb[i].Length; j++)
    {
        Console.Write($"{j_tomb[i][j], 3}");
    }
}
#endregion

#region 4. Feladat
//ugyan az, mint az 1. feladat, csak hardcoded értékekkel
int sorokSzama4 = 5;
int oszlopokSzama4 = 5;

int[,] randomMatrix4 = new int[sorokSzama4, oszlopokSzama4];

for (int i = 0; i < sorokSzama4; i++)
{
    for (int j = 0; j < oszlopokSzama4; j++)
    {
        randomMatrix4[i, j] = rnd.Next(0, 101);
    }
}

for (int i = 0; i < sorokSzama4; i++)
{
    for (int j = 0; j < oszlopokSzama4; j++)
    {
        Console.WriteLine($"{i + 1}. sor {j + 1}. eleme: {randomMatrix4[i, j]}");
    }
}
#endregion

#region 5. Feladat
//"egységmátrix" kiírás
int sorokSzama5 = int.Parse(Console.ReadLine()!);
int oszlopokSzama5 = int.Parse(Console.ReadLine()!);

int[,] egysegMatrix = new int[sorokSzama5, oszlopokSzama5];

for (int i = 0; i < sorokSzama5; i++)
{
    for (int j = 0; j < oszlopokSzama5; j++)
    {
        if (i == j)
        {
            egysegMatrix[i, j] = 1;
        }
        else
        {
            egysegMatrix[i, j] = 0;
        }
    }
}

for (int i = 0; i < sorokSzama5; i++)
{
    Console.WriteLine();
    for (int j = 0; j < oszlopokSzama5; j++)
    {
        Console.Write($"{egysegMatrix[i, j],3}");
    }
}
#endregion

#region 6. Feladat
Console.WriteLine();
Console.Write("Add meg a sorok számát: ");
int sorokSzama6 = int.Parse(Console.ReadLine()!);
Console.Write("Add meg az oszlopok számát: ");
int oszlopokSzama6 = int.Parse(Console.ReadLine()!);

int[,] matrix6 = new int[sorokSzama6, oszlopokSzama6];

int matrix6index = 0;
for (int i = 0; i < sorokSzama6; i++)
{
    for (int j = 0; j < oszlopokSzama6; j++)
    {
        matrix6[i, j] = matrix6index++;
    }
}

for (int i = 0; i < sorokSzama6; i++)
{
    for (int j = 0; j < oszlopokSzama6; j++)
    {
        Console.Write($"{matrix6[i, j],3} ");
    }
    Console.WriteLine();
}
#endregion

#region 7. Feladat
#endregion