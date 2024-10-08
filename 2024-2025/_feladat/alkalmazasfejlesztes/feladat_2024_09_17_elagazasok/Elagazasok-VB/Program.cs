﻿//1. Feladat
Console.Write("Add meg a téglalap egyik oldalát: ");
int a1 = int.Parse(Console.ReadLine()!);
Console.Write("Add meg a téglalap másik oldalát: ");
int b1 = int.Parse(Console.ReadLine()!);

if (a1 >= 0 || b1 >= 0)
{
    Console.WriteLine($"A téglalap kerülete: {2 * (a1 + b1)}");
    Console.WriteLine($"A téglalap területe: {a1 * b1}");
}
else
{
    Console.WriteLine("Érvénytelen adatok. Nem lehet kiszámolni téglalap területét & kerületét.");
}

//2. Feladat
Console.Write("Adj meg egy valós számot: ");
double a2 = int.Parse(Console.ReadLine()!);

Console.Write("Adj meg még egy valós számot: ");
double b2 = int.Parse(Console.ReadLine()!);

Console.WriteLine($"A két szám összege: {a2 + b2}");
Console.WriteLine($"A két szám különbsége: {a2 - b2}");
Console.WriteLine($"A két szám szorzata: {a2 * b2}");
if (b2 != 0)
{
    Console.WriteLine($"A két szám hányadosa: {a2 / b2}");
}
else
{
    Console.WriteLine("Nem lehet nullával osztani!");
}

//3. Feladat
Console.Write("Add meg a neved: ");
string nev = Console.ReadLine()!;

Console.Write("Add meg a születési éved: ");
int szuletesiEv = int.Parse(Console.ReadLine()!);

if (szuletesiEv < 2000)
{
    Console.WriteLine($"Jó napot {nev}!");
}
else
{
    Console.WriteLine($"Szia {nev}!");
}

//4. Feladat
Console.Write("Add meg az 1. ajándék árát: ");
int ajandek1 = int.Parse(Console.ReadLine()!);
Console.Write("Add meg az 2. ajándék árát: ");
int ajandek2 = int.Parse(Console.ReadLine()!);
Console.Write("Add meg az 3. ajándék árát: ");
int ajandek3 = int.Parse(Console.ReadLine()!);

int vegosszeg = ajandek1 + ajandek2 + ajandek3;

if (vegosszeg <= 20000)
{
    Console.WriteLine("Az ajándékaid összesített ára nem lépi túl a limitet.");
    Console.WriteLine($"{20000 - vegosszeg} Ft-ot költhetsz még ajándékokra, ha a kereten belül szeretnél maradni.");
}
else
{
    Console.WriteLine($"Túllépted az ájándékvásárlási limitet {vegosszeg - 20000} Ft-al!");
}

//5. Feladat
Random rnd = new Random();
int randomNumber = rnd.Next(0, 2);

if (randomNumber == 0)
{
    Console.WriteLine("Fejet dobtál az érmével!");
}
else
{
    Console.WriteLine("Írást dobtál az érmével!");
}

//6. Feladat
Console.Write("Adj meg egy egész számot: ");
int a6 = int.Parse(Console.ReadLine()!);

if (a6 % 2 == 0)
{
    Console.WriteLine("A szám páros.");
}
else
{
    Console.WriteLine("A szám páratlan.");
}

//7. Feladat
Console.Write("Szeretnél ötöst kapni programozásból? (igen/nem) ");
string answer = Console.ReadLine()!;

if (answer == "igen")
{
    Console.WriteLine("Akkor gyakorolj!");
}
else if (answer == "nem")
{
    Console.WriteLine("Helytelen a hozzáállásod!");
}
else
{
    Console.WriteLine("Érvénytelen bemenet.");
}

//8. Feladat
Console.Write("Adj meg egy számot: ");
int a8 = int.Parse(Console.ReadLine()!);

if (a8 == 0)
{
    Console.WriteLine("A számnak nincs előjele.");
}
else if (a8 > 0)
{
    Console.WriteLine("A szám előjele: +");
}
else
{
    Console.WriteLine("A szám előjele: -");
}


//9. Feladat
Console.Write("Add meg egy hónap sorszámát: ");
int month = int.Parse(Console.ReadLine()!);

if (month == 1 || month == 2 || month == 3)
{
    Console.WriteLine("Ez egy tavaszi hónap!");
}
else if (month == 4 || month == 5 || month == 6)
{
    Console.WriteLine("Ez egy nyári hónap!");
}
else if (month == 7 || month == 8 || month == 9)
{
    Console.WriteLine("Ez egy őszi hónap!");
}
else if (month == 10 || month == 11 || month == 12)
{
    Console.WriteLine("Ez egy téli hónap!");
}
else
{
    Console.WriteLine("Érvénytelen hónapot adtál meg!");
}

//10. Feladat
Console.Write("Adj meg egy évszámot: ");
int year = int.Parse(Console.ReadLine()!);

if ((year % 4 == 0 && year % 100 != 0) || (year % 4 == 0 && year % 4 == 400))
{
    Console.WriteLine("Ez egy szökőév!");
}
else
{
    Console.WriteLine("Ez nem egy szökőév!");

}

//11. Feladat
Console.Write("Add meg az 1. számot: ");
int a11 = int.Parse(Console.ReadLine()!);
Console.Write("Add meg a 2. számot: ");
int b11 = int.Parse(Console.ReadLine()!);
Console.Write("Add meg a 3. számot: ");
int c11 = int.Parse(Console.ReadLine()!);

int max = Math.Max(a11, Math.Max(b11, c11));

Console.WriteLine($"A legnagyobb szám: {max}");

//12. Feladat
Console.Write("Add meg a termék eredeti árát: ");
double eredetiAr = int.Parse(Console.ReadLine()!);

Console.Write("Add meg a kedvezmény százalékát: ");
double kedvezmenySzazaleka = int.Parse(Console.ReadLine()!);

Console.WriteLine($"Az akciós ár: {(kedvezmenySzazaleka / eredetiAr) * 100}");

if (kedvezmenySzazaleka > 50)
{
    Console.WriteLine("Megéri megvenni az árut!");
}

//13. Feladat
Console.Write("Add meg a víz hőmérsékletét: ");
int homerseklet =  int.Parse(Console.ReadLine()!);

if (homerseklet < 0)
{
    Console.WriteLine("A víz halmazállapota jég.");
}
else if (homerseklet > 0 && homerseklet < 100)
{
    Console.WriteLine("A víz halmazállapota folyékony.");
}
else
{
    Console.WriteLine("A víz halmazállapota gőz.");
}

//14. Feladat
Console.Write("Add meg az 1. számot: ");
int a14 = int.Parse(Console.ReadLine()!);
Console.Write("Add meg a 2. számot: ");
int b14 = int.Parse(Console.ReadLine()!);
Console.Write("Add meg a 3. számot: ");
int c14 = int.Parse(Console.ReadLine()!);

int[] numbers = { a14, b14, c14 };
Array.Sort(numbers);

Console.WriteLine("A számok növekvő sorrendben: ");
foreach (int number in numbers)
{
    Console.WriteLine(number);
}

//15. Feladat
Console.Write("Add meg az egyik gén típusát (A, B, AB, 0): ");
string gene1 = Console.ReadLine()!;
Console.Write("Add meg a másik gén típusát (A, B, AB, 0): ");
string gene2 = Console.ReadLine()!;

if ((gene1 == "A" && gene2 == "A") || (gene1 == "A" && gene2 == "0") || (gene1 == "0" && gene2 == "A"))
{
    Console.WriteLine("A vércsoportod: A");
}
else if ((gene1 == "B" && gene2 == "B") || (gene1 == "B" && gene2 == "0") || (gene1 == "0" && gene2 == "B"))
{
    Console.WriteLine("A vércsoportod: B");
}
else if ((gene1 == "A" && gene2 == "B") || (gene1 == "B" && gene2 == "A"))
{
    Console.WriteLine("A vércsoportod: AB");
}
else if (gene1 == "0" && gene2 == "0")
{
    Console.WriteLine("A vércsoportod: 0");
}
else
{
    Console.WriteLine("Érvénytelen értéket/értékeket adtál meg.");
}