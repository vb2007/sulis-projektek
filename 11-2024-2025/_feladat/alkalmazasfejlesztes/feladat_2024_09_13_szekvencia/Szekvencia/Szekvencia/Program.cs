//1. Feladat
Console.ForegroundColor = ConsoleColor.Blue;
Console.BackgroundColor = ConsoleColor.Red;
Console.WriteLine("Kedvenc dalszöveg 1. sora.");

Console.ForegroundColor = ConsoleColor.Yellow;
Console.BackgroundColor = ConsoleColor.Green;
Console.WriteLine("Kedvenc dalszöveg 2. sora.");

Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.BackgroundColor = ConsoleColor.Cyan;
Console.WriteLine("Kedvenc dalszöveg 3. sora.");

Console.ForegroundColor = ConsoleColor.Magenta;
Console.BackgroundColor = ConsoleColor.DarkYellow;
Console.WriteLine("Kedvenc dalszöveg 4. sora.");

Console.ResetColor();

//2. Feladat
Console.Write("Adj meg egy egész számot: ");
int egeszSzam1 = int.Parse(Console.ReadLine()!);
Console.Write("Adj meg még egy egész számot: ");
int egeszSzam2 = int.Parse(Console.ReadLine()!);

Console.WriteLine($"A kettő szám összege: {egeszSzam1 + egeszSzam2}");
Console.WriteLine($"A kettő szám különbsége: {egeszSzam1 - egeszSzam2}");
Console.WriteLine($"A kettő szám szorzata: {egeszSzam1 * egeszSzam2}");
Console.WriteLine($"A kettő szám hányadosa: {egeszSzam1 / egeszSzam2}");
Console.WriteLine($"A kettő szám osztás utáni maradéka: {egeszSzam1 % egeszSzam2}");

//3. Feladat
Console.Write("Adj meg egy születési évet: ");
int szuletesiEv = int.Parse(Console.ReadLine()!);
Console.WriteLine($"A delikvens {DateTime.Now.Year - szuletesiEv} éves.");

//4. Feladat
Console.WriteLine("Az érettségin max. 120 pontot lehet elérni.");
Console.Write("Add meg hány pontot értél el: ");
int maxPontszam = 100;
int elertPontszam = int.Parse(Console.ReadLine()!);

double szazalek = (double)maxPontszam / elertPontszam * 100;

Console.WriteLine($"{szazalek} százalékot értél el.");

//5. Feladat
Console.Write("Add meg a háromszög 1. oldalát: ");
int haromszogOldal1 = int.Parse(Console.ReadLine()!);
Console.Write("Add meg a háromszög 2. oldalát: ");
int haromszogOldal2 = int.Parse(Console.ReadLine()!);
Console.Write("Add meg a háromszög 3. oldalát: ");
int haromszogOldal3 = int.Parse(Console.ReadLine()!);

Console.WriteLine($"A háromszög kerülete: {haromszogOldal1 + haromszogOldal2 + haromszogOldal3}");

//6. Feladat
Console.Write("Add meg a súlyod kg-ban: ");
int felhasznaloSulya = int.Parse(Console.ReadLine()!);
Console.Write("Add meg a magasságod cm-ben: ");
int felhasznaloMagassaga = int.Parse(Console.ReadLine()!);

Console.WriteLine($"A testtömegindexed: {felhasznaloSulya + Math.Pow(felhasznaloMagassaga, 2)}");

//7. Feladat
Console.Write("Add meg, mennyi €-t szeretnél vásárolni: ");
Console.Write("Add meg az € aktuális árfolyamát: ");

Console.WriteLine($"Az aktuális árfolyamon ennyi Ft-ot kell fizetned: ");