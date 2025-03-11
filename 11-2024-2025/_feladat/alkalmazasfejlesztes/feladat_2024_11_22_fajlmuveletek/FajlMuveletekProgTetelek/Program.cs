//#region 1. Feladat

////a) Olvasd be, hogy melyik állományról szeretnénk statisztikát készíteni, majd a megadott fájlból olvasd be az értékeket és tárold el egy listában!
//Console.Write("Add meg melyik fájlból szeretnél beolvasni (1-3): ");
//string targetFileNumber = Console.ReadLine()!;

//if (int.Parse(targetFileNumber) < 1 || int.Parse(targetFileNumber) > 4)
//{
//	throw new ArgumentException("Érvénytelen értéket adtál meg.");
//}

//string[] lines = File.ReadAllLines($"szamok{targetFileNumber}.txt");

////b) Jelenítsd meg a beolvasott számokat sorszámozva
//for (int i = 0; i < lines.Count(); i++)
//{
//	Console.WriteLine($"{i + 1}. szám: {lines[i]}");
//}

////c) Jelenítsd meg a beolvasott számokat egymástól tabulátorral elválasztva!
//Console.WriteLine("\n");
//for (int i = 0; i < lines.Count(); i++)
//{
//	Console.Write($"{lines[i]}\t");
//}

////d) Írd ki a beolvasott számokat párosával egy sorban, egymástól pontosvesszővel elválasztva a parosaval.txt nevű állományba úgy, hogy minden 2 szám után jelenjen meg vele egy sorban a 2 szám átlaga pontosan 2 tizedes jeggyel! Például: 1; -3; -1,00; 1; 2; 1,50


////e) Add meg a számok összegét!
//Console.WriteLine("\n");
//int osszeg = 0;
//for (int i = 0; i < lines.Count(); i++)
//{
//	osszeg += int.Parse(lines[i]);
//}

//Console.WriteLine($"A számok összege: {osszeg}");

////f) Add meg a számok átlagát!
//int atlag = osszeg / lines.Count();
//Console.WriteLine($"A számok átlaga: {atlag}");

////g) Add meg, mekkora a legnagyobb érték!
//int legnagyobb = int.Parse(lines[0]);
//for (int i = 1; i < lines.Count(); i++)
//{
//	if (legnagyobb < int.Parse(lines[i]))
//	{
//		legnagyobb = int.Parse(lines[i]);
//	}
//}

//Console.WriteLine($"A legnagyobb érték: {legnagyobb}");

////h) Add meg, mekkora a legkisebb érték!
//int legkisebb = int.Parse(lines[0]);
//for (int i = 1; i < lines.Count(); i++)
//{
//	if (legkisebb > int.Parse(lines[i]))
//	{
//		legkisebb = int.Parse(lines[i]);
//	}
//}

//Console.WriteLine($"A legkisebb érték: {legkisebb}");

////i) Add meg, hogy volt-e 0 a beolvasott számok között!
//bool vanNulla = false;
//for (int i = 0; i < lines.Count(); i++)
//{
//	if (int.Parse(lines[i]) == 0)
//	{
//		vanNulla = true;
//		break;
//	}
//}

//Console.WriteLine($"A számok között {(vanNulla ? "van" : "nincs")} nulla.");

////j) Add meg, hogy hányadik érték az első negatív szám! Amennyiben nincs ilyen, akkor írd ki, hogy nem található negatív érték a generált számok között!
//int negativPoz = -1;
//for (int i = 0; i < lines.Count(); i++)
//{
//	if (int.Parse(lines[i]) < 0)
//	{
//		negativPoz = i;
//		break;
//	}
//}

//if (negativPoz < 0)
//{
//	Console.WriteLine("Nincs negatív szám a sorozatban.");
//}
//else
//{
//	Console.WriteLine($"Az első negatív szám pozíciója: {negativPoz + 1}");
//}


////k) Add meg % formátumban, hogy a beolvasott értékeknek hány százaléka pozitív!
//int pozitivSzamokSzama = 0;

//for (int i = 0; i < lines.Count(); i++)
//{
//	if (int.Parse(lines[i]) > 0)
//	{
//		pozitivSzamokSzama++;
//	}
//}

//double pozitivArany = (double)pozitivSzamokSzama / lines.Count() * 100;

//Console.WriteLine($"A beolvasott értékek {pozitivArany:F2}%-a pozitív.");
//#endregion

#region 2. Feladat
//a) Add meg, hány beolvasott embernek van 2 keresztneve!
string[] lines2 = File.ReadAllLines("nevek.txt");

int keresztnevCount = 0;
for (int i = 0; i < lines2.Count(); i++)
{
    string[] line = lines2[i].Split(' ');
    if (line.Count() == 3)
    {
        keresztnevCount += 1;
    }
}

Console.WriteLine($"{keresztnevCount} embernek van 3 keresztneve.");

//b) Írd ki a neveket névsorban!
Array.Sort(lines2);

Console.WriteLine("A nevek ABC sorrendben:");
foreach (var nev in lines2)
{
    Console.WriteLine(nev);
}

//c) Generálj a listából 3 nevet véletlenszerűen! Figyelj arra, hogy ne lehessen két név ugyanaz! Írd ki a neveket a felelok.txt nevű állományba, minden név külön sorba kerüljön!
for (int i = 0; i < 3; i++)
{

}
#endregion