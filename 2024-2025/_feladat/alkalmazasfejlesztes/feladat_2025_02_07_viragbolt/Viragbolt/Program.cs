//1. Feladat: beolvasás
const int SIZE = 30;
Viragok[] viragAdatok = new Viragok[SIZE];

int db = 0;
foreach (var item in File.ReadAllLines("viragok.txt"))
{
    string[] darabolt = item.Split(';');
    viragAdatok[db] = new(darabolt[0], int.Parse(darabolt[1]));
    db++;
}

//2. Feladat: kiírás
for (int i = 0; i < db; i++)
{
    Console.WriteLine($"{viragAdatok[i].nev} ({viragAdatok[i].ar}) Ft");
}

//3. Feladat: átlag ár
int osszAr = 0;
for (int i = 0; i < db; i++)
{
    osszAr += viragAdatok[i].ar;
}

double atlag = (double)osszAr / db;

Console.WriteLine($"Átlagosan {Math.Round(atlag, 2)} Ft-ba kerül egy szál virág.");

//4. Feladat: legrágább virág
int legdragababbIndex = 0;
int legdragababbAr = 0;
for (int i = 0; i < db; i++)
{
    if (viragAdatok[i].ar > legdragababbAr)
    {
        legdragababbAr = viragAdatok[i].ar;
        legdragababbIndex = i;
    }
}

Console.WriteLine($"A legdrágább virág a(z) \"{viragAdatok[legdragababbIndex].nev}\", ami {viragAdatok[legdragababbIndex].ar} Ft-ba kerül.");

//5. Feladat: hány olyan virág van, ami legalább 1000 Ft
int legalabbEzer = 0;
for (int i = 0; i < db; i++)
{
    if (viragAdatok[i].ar >= 1000)
    {
        legalabbEzer++;
    }
}

Console.WriteLine($"{legalabbEzer} db olyan virág van, ami legalább 1000Ft.");

//6. Feladat: olvasd be egy virág nevét, és írd ki mennyibe kerül, amennyiben kapható
Console.Write("Add meg egy virág nevét: ");
string keresettNev = Console.ReadLine()!;

int keresettAr = 0;
for (int i = 0; i < db; i++)
{
    if (viragAdatok[i].nev == keresettNev)
    {
        keresettAr = viragAdatok[i].ar;
    }
}

if (keresettAr == 0)
{
    Console.WriteLine($"Nincs nevű ({keresettNev}) virág az üzletben.");
}
else
{
    Console.WriteLine($"A keresett \"{keresettNev}\" nevű virág {keresettAr} Ft-ba kerül.");
}

public record Viragok(string nev, int ar);