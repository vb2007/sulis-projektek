//1. Feladat: beolvasás
const int SIZE = 150;
Alapitvany[] alapitvanyAdatok = new Alapitvany[SIZE];

int db = 0;
foreach (var item in File.ReadAllLines("tamogatas.txt"))
{
    string[] darabolt = item.Split(';');
    alapitvanyAdatok[db] = new(darabolt[0], int.Parse(darabolt[1]));
    db++;
}

//2. Feladat: kiírás
void AdatokKiirasa()
{
    for (int i = 0; i < db; i++)
    {
        Console.WriteLine($"{alapitvanyAdatok[i].Nev} - {alapitvanyAdatok[i].Osszeg} Ft");
    }
}

AdatokKiirasa();

//3. Feladat: ki utalt a legtöbbet és mennyit?
(int, string) LegtobbetUtalo()
{
    int legnagyobbUtaltOsszeg = 0;
    string legtobbetUtaloNeve = String.Empty;

    for (int i = 0; i < db; i++)
    {
        if (alapitvanyAdatok[i].Osszeg > legnagyobbUtaltOsszeg)
        {
            legnagyobbUtaltOsszeg = alapitvanyAdatok[i].Osszeg;
            legtobbetUtaloNeve = alapitvanyAdatok[i].Nev;
        }
    }

    return (legnagyobbUtaltOsszeg, legtobbetUtaloNeve);
}

var legtobbetUtaloAdat = LegtobbetUtalo();
Console.WriteLine($"A legtöbbet \"{legtobbetUtaloAdat.Item2}\" utalt, melynek összege: {legtobbetUtaloAdat.Item1} Ft.");

//4. Feladat: mennyi volt az átlagosan befizetett összeg (2 tizedes jegyre kerektve)?
double AtlagBefizetettOsszeg()
{
    int osszeg = 0;
    for (int i = 0; i < db; i++)
    {
        osszeg += alapitvanyAdatok[i].Osszeg;
    }

    return Math.Round((double)osszeg / db, 2);
}

Console.WriteLine($"Az átlagosan befizetett összeg: {AtlagBefizetettOsszeg()} Ft.");

//5. Feladat: adja meg, hányan utaltak 10 000 Ft-nál kevesebbet
int KevesebbetUtalokSzama(int osszeg)
{
    int kevesebbetUtalokSzama = 0;
    for (int i = 0; i < db; i++)
    {
        if (alapitvanyAdatok[i].Osszeg < osszeg)
        {
            kevesebbetUtalokSzama++;
        }
    }

    return kevesebbetUtalokSzama;
}

Console.WriteLine($"10 000 Ft-nál kevesebbet utaltak: {KevesebbetUtalokSzama(10000)} fő.");

//6. Feladat: olvasson be egy összeget, és nézze meg, hogy fizetett-e be valaki ennyit
Console.Write("Kérem adjon meg egy összeget: ");
int bekertOsszeg = int.Parse(Console.ReadLine()!);

string PontosanBefizetett(int osszeg)
{
    for (int i = 0; i < db; i++)
    {
        if (alapitvanyAdatok[i].Osszeg == osszeg)
        {
            return alapitvanyAdatok[i].Nev;
        }
    }
    return String.Empty;
}

string eredmeny = PontosanBefizetett(bekertOsszeg);
if (eredmeny == String.Empty)
{
    Console.WriteLine($"Nem olyan, aki pontosan {bekertOsszeg} Ft-ot utalt.");
}
else
{
    Console.WriteLine($"{eredmeny} volt az, aki pontosan {bekertOsszeg} Ft-ot fizetett be.");
}

//7. Feladat: írja ki a fotamogatok.txt fájlba azok nevét, akik legalább 40 000 Ft-ot utaltak
void FotamogatokKiirasa(int osszeg)
{
    using StreamWriter sw = new("fotamogatok.txt");
    for (int i = 0; i < db; i++)
    {
        if (alapitvanyAdatok[i].Osszeg >= osszeg)
        {
            sw.WriteLine(alapitvanyAdatok[i].Nev);
        }
    }
}

FotamogatokKiirasa(40000);

public record Alapitvany(string Nev, int Osszeg);