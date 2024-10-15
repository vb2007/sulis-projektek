#region 1. Feladat
Console.WriteLine("Adj meg egy szöveget:");
string szoveg1  = Console.ReadLine()!;

//1. a
Console.WriteLine($"A szöveg hossza: {szoveg1}");

//1. b
Console.WriteLine("A szöveg betűnként új sorban:");
foreach (char c in szoveg1)
{
    Console.WriteLine(c);
}

//1. c
Console.WriteLine("A szöveg betűnként fordított sorrendben új sorban: ");
for (int i = szoveg1.Length - 1; i >= 0; i--)
{
    Console.WriteLine(szoveg1[i]);
}

//1. d
Console.WriteLine($"A szöveg nagybetűkkel: {szoveg1.ToUpper()}");

//1. e
Console.WriteLine($"A szöveg kisbetűkkel: {szoveg1.ToLower()}");

//1. f
#endregion

#region 2. Feladat
Console.WriteLine("Adj meg egy szöveget: ");
string szoveg21 = Console.ReadLine()!;
Console.WriteLine("Adj meg még egy szöveget: ");
string szoveg22 = Console.ReadLine()!;

//2. a
Console.WriteLine($"A két szó összefűzve: {szoveg21 + szoveg22}");

//2. b
if (szoveg21.Length > szoveg22.Length)
{
    Console.WriteLine("Az 1. szó hosszabb.");
}
else if (szoveg21.Length < szoveg22.Length)
{
    Console.WriteLine("A 2. szó hosszabb.");
}
else if (szoveg21.Length == szoveg22.Length)
{
    Console.WriteLine("A két szó egyenlő hosszúságú");
}
else
{
    Console.WriteLine("Érvénytelen értékeket adtál meg.");
}

//2. c
Console.WriteLine($"A két szó összefűzve, \";\" karakterrel elválasztva: {szoveg21};{szoveg22}");

//2. d
string reversedString2 = string.Empty;

for (int i = szoveg22.Length - 1; i >= 0; i--)
{
    reversedString2 += szoveg22[i];
}
Console.WriteLine($"A két szó úgy összefűzve, hogy a másik meg van fordítva: {szoveg21 + reversedString2}");
#endregion

#region 3. Feladat
Console.WriteLine("Adj meg egy szöveget: ");
string szoveg3 = Console.ReadLine()!;

//3. a
string reversedString3 = string.Empty;

for (int i = szoveg3.Length - 1; i >= 0; i--)
{
    reversedString3 += szoveg3[i];
}
Console.WriteLine($"A szöveg megfordítva: {reversedString3}");

//3. b
Console.WriteLine($"A szöveg felesleges szóközök nélkül: {szoveg3.Replace("  ", " ")}");

//3. c
Console.WriteLine($"A szöveg a végén lévő szóközök nélkül: {szoveg3.TrimEnd()}");

//3. d
string szoveg3NoWhitespaces = szoveg3.Replace(" ", "");
string reversedString3NoWhitespaces = reversedString3.Replace(" ", "");

if (szoveg3NoWhitespaces == reversedString3NoWhitespaces)
{
    Console.WriteLine("A szó palindrom.");
}
#endregion

#region 4. Feladat
//4. a
Console.WriteLine("Add meg a vezetékneved: ");
string vezeteknev = Console.ReadLine()!;
Console.WriteLine("Add meg a keresztneved: ");
string keresztnev = Console.ReadLine()!;
Console.Write("Ha van, add meg a 2. keresztneved: ");
string masodikKeresztnev = Console.ReadLine()!;
#endregion