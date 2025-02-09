﻿#region 1. Feladat
// 1. Feladat: Adatok beolvasása és tárolása
string[] lines = File.ReadAllLines("melyseg.txt");

int rowCount = int.Parse(lines[0]);
int colCount = int.Parse(lines[1]);

int[,] depthData = new int[rowCount, colCount];

for (int i = 0; i < rowCount; i++)
{
    string[] rowValues = lines[i + 2].Split(' ');
    for (int j = 0; j < colCount; j++)
    {
        depthData[i, j] = int.Parse(rowValues[j]);
    }
}
#endregion

#region 2. Feladat
Console.WriteLine("2. Feladat");

Console.Write("Sorazonosító (1-től kezdődően): ");
int row = int.Parse(Console.ReadLine()!) - 1;

Console.Write("Oszlopazonosító (1-től kezdődően): ");
int col = int.Parse(Console.ReadLine()!) - 1;

int depth = depthData[row, col];
Console.WriteLine($"A mérés sorának azonosítója={row + 1}");
Console.WriteLine($"A mérés oszlopának azonosítója={col + 1}");
Console.WriteLine($"A mért mélység az adott helyen {depth} dm");
#endregion

#region 3. Feladat
Console.WriteLine("3. Feladat");

int count = 0;
int sum = 0;
for (int i = 0; i < rowCount; i++)
{
    for (int j = 0; j < colCount; j++)
    {
        if (depthData[i, j] != 0)
        {
            count++;
            sum += depthData[i, j];
        }
    }
}

double averageDepth = (double)sum / count;

Console.WriteLine($"A tó felszíne: {count} m2, átlagos mélysége: {Math.Round((averageDepth / 10), 2)} m");
#endregion

#region 4. Feladat
Console.WriteLine("4. Feladat");

int maxDepth = 0;
List<(int row, int col)> maxDepthCoordinates = new List<(int row, int col)>();

for (int i = 0; i < rowCount; i++)
{
    for (int j = 0; j < colCount; j++)
    {
        if (depthData[i, j] > maxDepth)
        {
            maxDepth = depthData[i, j];
            maxDepthCoordinates.Clear();
            maxDepthCoordinates.Add((i + 1, j + 1));
        }
        else if (depthData[i, j] == maxDepth)
        {
            maxDepthCoordinates.Add((i + 1, j + 1));
        }
    }
}

Console.WriteLine($"A tó legnagyobb mélysége: {maxDepth} dm");
Console.WriteLine("A legmélyebb pont(ok) koordinátái:");
foreach (var coord in maxDepthCoordinates)
{
    Console.WriteLine($"({coord.row}; {coord.col})");
}
#endregion

#region 5. Feladat
Console.WriteLine("5. Feladat");

int shorelineLength = 0;

for (int i = 0; i < rowCount; i++)
{
    for (int j = 0; j < colCount; j++)
    {
        //teteje
        if (i == 0 || depthData[i - 1, j] == 0)
        {
            shorelineLength++;
        }
        //alja
        if (i == rowCount - 1 || depthData[i + 1, j] == 0)
        {
            shorelineLength++;
        }
        //bal oldal
        if (j == 0 || depthData[i, j - 1] == 0)
        {
            shorelineLength++;
        }
        //jobb oldal
        if (j == colCount - 1 || depthData[i, j + 1] == 0)
        {
            shorelineLength++;
        }
    }
}

Console.WriteLine($"A tó partvonala {shorelineLength} m hosszú");
#endregion

#region 6. Feladat
Console.WriteLine("6. Feladat");

Console.Write("A vizsgált szelvény oszlopának azonosítója=");
int colId = int.Parse(Console.ReadLine()!) - 1;

using (StreamWriter writer = new StreamWriter("diagram.txt"))
{
    for (int i = 0; i < rowCount; i++)
    {
        int depthInMeters = (int)Math.Round(depthData[i, colId] / 10.0);
        writer.Write($"{i + 1:00} ");
        for (int j = 0; j < depthInMeters; j++)
        {
            writer.Write("*");
        }
        writer.WriteLine();
    }
}
#endregion