//1. Feladat

Console.Write("Add meg a gúla alapjának az oldalát: ");
string aInputString = Console.ReadLine()!;

Console.Write("Add meg a gúla magasságát: ");
string mInputString = Console.ReadLine()!;

if (aInputString == "" || mInputString == "")
{
    Console.WriteLine("Az alap vagy a magasság értéke nincs megadva.");
}
else
{
    int aInput = int.Parse(aInputString);
    int mInput = int.Parse(mInputString);

    double v = Math.Pow(aInput, 2) * mInput / 3;
    double a = Math.Pow(aInput, 2) + aInput * Math.Sqrt(4 * Math.Pow(mInput, 2) + Math.Pow(aInput, 2));

    Console.WriteLine($"A gúla téfogata: V = {v}");
    Console.WriteLine($"A gúla felszíne: A = {a}");

    if (v > a)
    {
        Console.WriteLine("A gúla térfogata nagyobb, mint a felszíne.");
    }
    else
    {
        Console.WriteLine("A gúla felszíne nagyobb, mint a térfogata.");
    }
}

//2. Feladat
Console.Write("Add meg hanyadik sorba szeretnél jegyet venni: ");
int sorSzama = int.Parse(Console.ReadLine()!);

Console.Write("Add meg mennyi jegyet venni: ");
int jegyekMennyisege = int.Parse(Console.ReadLine()!);

Console.BackgroundColor = ConsoleColor.White;
if (sorSzama == 1)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"{jegyekMennyisege * 10000} Ft-ot kell fizetned a jegyekért.");
    Console.WriteLine($"Törzsvásárlói kártyával {(jegyekMennyisege * 10000) - ((jegyekMennyisege * 10000) * 0.1)} Ft-ot kell fizetned a jegyekért.");
}
else if (sorSzama == 2)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"{jegyekMennyisege * 8000} Ft-ot kell fizetned a jegyekért.");
    Console.WriteLine($"Törzsvásárlói kártyával {(jegyekMennyisege * 8000) - ((jegyekMennyisege * 8000) * 0.1)} Ft-ot kell fizetned a jegyekért.");
}
else if (sorSzama == 3)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"{jegyekMennyisege * 6400} Ft-ot kell fizetned a jegyekért.");
    Console.WriteLine($"Törzsvásárlói kártyával {(jegyekMennyisege * 6400) - ((jegyekMennyisege * 6400) * 0.1)} Ft-ot kell fizetned a jegyekért.");
}
else if (sorSzama == 4)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"{jegyekMennyisege * 5000} Ft-ot kell fizetned a jegyekért.");
    Console.WriteLine($"Törzsvásárlói kártyával {(jegyekMennyisege * 5000) - ((jegyekMennyisege * 5000) * 0.1)} Ft-ot kell fizetned a jegyekért.");
}
else
{
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("Érvénytelen sorszámot adtál meg.");
}
Console.ResetColor();

//3. Feladat
Random rnd = new Random();

int egeszSzam = rnd.Next(-30, 21);
double valosSzam = rnd.NextDouble() * (21 - (-30)) + (-30);

//a)
if (egeszSzam < 0)
{
    Console.WriteLine("Az egész szám negatív");
}
else if (egeszSzam > 0)
{
    Console.WriteLine("Az egész szám pozitív");
}
else
{
    Console.WriteLine("Az egész szám 0.");
}

//b)
if (egeszSzam % 2 == 0)
{
    Console.WriteLine("Az egész szám páros.");
}
else
{
    Console.WriteLine("Az egész szám páratlan.");
}

//c)
if (egeszSzam > valosSzam)
{
    Console.WriteLine("Az egész szám nagyobb, mint a valós szám.");
}
else if (egeszSzam < valosSzam)
{
    Console.WriteLine("A valós szám nagyobb, mint az egész szám.");
}
else //if (egeszSzam == valosSzam)
{
    Console.WriteLine("Az egész és a valós szám egyenlő.");
}

//d)
Console.WriteLine($"A valós szám egészre lefelé kerekített értéke: {Math.Floor(valosSzam)}");

//e)
Console.WriteLine($"A valós szám egészre felfelé értéke: {Math.Ceiling(valosSzam)}");

//f)
Console.WriteLine($"A valós matematikai kerekített értéke: {Math.Round(valosSzam)}");