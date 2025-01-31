string[] lines = await File.ReadAllLinesAsync("adatok.txt");

int osztalyLetszam = int.Parse(lines[0]);
int tantargyakSzama = int.Parse(lines[1]);

List<string> diakok = new List<string>(lines[2].Split(';'));
List<string> tantargyak = new List<string>(lines[3].Split(';'));

Console.WriteLine("Félévi statisztika:");

//[1. Feladat] Jegyek mátrixba olvasása
int[,] jegyek = new int[osztalyLetszam, tantargyakSzama];
for (int i = 0; i < osztalyLetszam; i++)
{
    string[] jegyekSor = lines[4 + i].Split(';');
    for (int j = 0; j < tantargyakSzama; j++)
    {
        jegyek[i, j] = int.Parse(jegyekSor[j]);
    }
}

int maxNameLength = diakok.Select(nev => nev.Length).Max();

//[1. Feladat] Tantárgyak neveinek és az "Átlag" oszlop kiírása
Console.Write("".PadRight(maxNameLength + 2));
foreach (string tantargy in tantargyak)
{
    Console.Write(tantargy.PadRight(15));
}
Console.WriteLine("Átlag:".PadRight(15));

double osszOsztalyJegy = 0;
int osszJegySzam = 0;
int tantargyiBukottak = 0;
List<string> legjobbTanulok = new List<string>();

for (int i = 0; i < osztalyLetszam; i++)
{
    //[1. Feladat] Diákok neveinek kiírása
    Console.Write(diakok[i].PadRight(maxNameLength + 2));
    //[1. Feladat] Jegyek kiírása
    int osszeg = 0;
    int bukasok = 0;
    for (int j = 0; j < tantargyakSzama; j++)
    {
        Console.Write(jegyek[i, j].ToString().PadRight(15));
        osszeg += jegyek[i, j];
        osszOsztalyJegy += jegyek[i, j];
        osszJegySzam++;
        if (jegyek[i, j] == 1)
        {
            tantargyiBukottak++;
            bukasok++;
        }
    }

    //[2. Feladat] Tanulók átlagainak kiírása
    double atlag = (double)osszeg / tantargyakSzama;
    Console.WriteLine(Math.Round(atlag, 1).ToString().PadRight(15));

    //[6. Feladat] Legjobb tanulók összegyűjtése
    if (atlag >= 4.0)
    {
        legjobbTanulok.Add(diakok[i]);
    }
}

//[3. Feladat] Osztályátlag
double osztalyAtlag = osszOsztalyJegy / osszJegySzam;
Console.WriteLine($"\nOsztályátlag: {osztalyAtlag:0.00}");

//[3. Feladat] Melyik tantárgy átlaga volt a legjobb
double[] tantargyAtlagok = new double[tantargyakSzama];
for (int j = 0; j < tantargyakSzama; j++)
{
    double tantargyOsszeg = 0;

    for (int i = 0; i < osztalyLetszam; i++)
    {
        tantargyOsszeg += jegyek[i, j];
    }

    tantargyAtlagok[j] = tantargyOsszeg / osztalyLetszam;
}

double legjobbTantargyAtlag = tantargyAtlagok.Max();
int legjobbTantargyIndex = Array.IndexOf(tantargyAtlagok, legjobbTantargyAtlag);
string legjobbTantargy = tantargyak[legjobbTantargyIndex];

Console.WriteLine($"A tantárgyak közül a legjobb: {legjobbTantargy}");

//[4. Feladat] Tantárgyi bukások száma
Console.WriteLine($"\nA tantárgyi bukások száma: {tantargyiBukottak}");

//[5. Feladat] Volt olyan diák, aki több tantárgyból bukott?
bool tobbTantargybolBukott = diakok.Any(diak => jegyek[diakok.IndexOf(diak), 0] == 1 && jegyek[diakok.IndexOf(diak), 1] == 1);

Console.WriteLine($"{(tobbTantargybolBukott ? "Van" : "Nincs olyan")}, aki több tantárgyból bukott.");

//[6. Feladat] Azok, akiknek az átlaga legalább 4 volt
Console.Write("Legjobb tanulók: ");
foreach (string tanulo in legjobbTanulok)
{
    Console.Write($"{tanulo}, ");
}