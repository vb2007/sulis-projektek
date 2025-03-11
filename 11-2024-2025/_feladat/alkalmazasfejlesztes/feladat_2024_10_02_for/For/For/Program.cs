//1. Feladat
Console.Write("Add meg az N egész számot: ");
int n = int.Parse(Console.ReadLine()!);

Console.WriteLine("\nAz első N szám növekvő sorrendben: ");
for (int i = 1; i <= n; i++)
{
    Console.WriteLine(i);
}

//2. Feladat
Console.WriteLine("\nAz első N négyzetszám: ");
for (int i = 1; i <= n; i++)
{
    Console.WriteLine(i * i);
}

//3. Feladat
Console.WriteLine("\nAz első N szám csökkenő sorrendben: ");
for (int i = n; i >= 0; i--)
{
    Console.WriteLine(i);
}