#region 1. Feladat
using System.Globalization;

Console.WriteLine("1. Feladat");

int sorokSzama = 15;
int szekekSzama = 20;

string[] foglaltsagLines = File.ReadAllLines("foglaltsag.txt");
char[,] foglaltsagMatrix = new char[sorokSzama, szekekSzama];

for (int i = 0; i < sorokSzama; i++)
{
    for (int j = 0; j < szekekSzama; j++)
    {
        foglaltsagMatrix[i, j] = foglaltsagLines[i][j];
    }
}

string[] kategoriaLines = File.ReadAllLines("kategoria.txt");
char[,] kategoriaMatrix = new char[sorokSzama, szekekSzama];

for (int i = 0; i < sorokSzama; i++)
{
    for (int j = 0; j < szekekSzama; j++)
    {
        kategoriaMatrix[i, j] = kategoriaLines[i][j];
    }
}

Console.WriteLine("Fájlok beolvasva.");
#endregion

#region 2. Feladat
Console.WriteLine("2. Feladat");

Console.Write("Add meg egy sor számát: ");
int sorSzam = int.Parse(Console.ReadLine()!);

Console.Write("Add meg a soron belül egy szék számát: ");
int szekSzam = int.Parse(Console.ReadLine()!);

if (foglaltsagMatrix[sorSzam - 1, szekSzam - 1] == 'x')
{
    Console.WriteLine("A hely már foglalt.");
}
else
{
    Console.WriteLine("A hely szabad.");
}
#endregion

#region 3. Feladat
Console.WriteLine("3. Feladat");

int foglaltHelyek = 0;
for (int i = 0; i < sorokSzama; i++)
{
    for (int j = 0; j < szekekSzama; j++)
    {
        if (foglaltsagMatrix[i, j] == 'x')
        {
            foglaltHelyek++;
        }
    }
}

int osszHelyek = sorokSzama * szekekSzama;

double szazalekEladva = (double)foglaltHelyek / osszHelyek * 100;

int szazalekEladvaKerekitve = (int)Math.Round(szazalekEladva);

Console.WriteLine($"Az előadásra eddog {foglaltHelyek} jegyet adtak el, ez a nézőtér {szazalekEladvaKerekitve}%-a.");
#endregion

#region 4. Feladat
Console.WriteLine("4. Feladat");

int[] kategoriak = new int[5];
for (int i = 0; i < sorokSzama; i++)
{
    for (int j = 0; j < szekekSzama; j++)
    {
        if (foglaltsagMatrix[i, j] == 'x')
        {
            switch (kategoriaMatrix[i, j])
            {
                case '1':
                    kategoriak[0]++;
                    break;
                case '2':
                    kategoriak[1]++;
                    break;
                case '3':
                    kategoriak[2]++;
                    break;
                case '4':
                    kategoriak[3]++;
                    break;
                case '5':
                    kategoriak[4]++;
                    break;
                default:
                    throw new InvalidProgramException("Invalid switch case.");
            }
        }
    }
}

int maxIndex = 0;
for (int i = 1; i < kategoriak.Length; i++)
{
    if (kategoriak[i] > kategoriak[maxIndex])
    {
        maxIndex = i;
    }
}

Console.WriteLine($"A legtöbb jegyet a(z) {maxIndex + 1}. árkategóriában értékesítették.");
#endregion

#region 5. Feladat
Console.WriteLine("5. Feladat");

int osszBevetel = 0;
int[] arak = { 5000, 4000, 3000, 2000, 1500 };

for (int i = 0; i < sorokSzama; i++)
{
    for (int j = 0; j < szekekSzama; j++)
    {
        if (foglaltsagMatrix[i, j] == 'x')
        {
            switch (kategoriaMatrix[i, j])
            {
                case '1':
                    osszBevetel += arak[0];
                    break;
                case '2':
                    osszBevetel += arak[1];
                    break;
                case '3':
                    osszBevetel += arak[2];
                    break;
                case '4':
                    osszBevetel += arak[3];
                    break;
                case '5':
                    osszBevetel += arak[4];
                    break;
                default:
                    throw new InvalidProgramException("Invalid switch case.");
            }
        }
    }
}

Console.WriteLine($"A színház bevétele a pillanatnyilag eladott jegyek alapján {osszBevetel} Ft.");
#endregion

#region 6. Feladat
Console.WriteLine("6. Feladat");

int egyedulalloUresHelyek = 0;
for (int i = 0; i < sorokSzama; i++)
{
    for (int j = 0; j < szekekSzama; j++)
    {
        if (foglaltsagMatrix[i, j] == 'o')
        {
            bool egyedulallo = true;

            //bal szomszéd
            if (j > 0 && foglaltsagMatrix[i, j - 1] == 'o')
            {
                egyedulallo = false;
            }

            //jobb szomszéd
            if (j < szekekSzama - 1 && foglaltsagMatrix[i, j + 1] == 'o')
            {
                egyedulallo = false;
            }

            if (egyedulallo)
            {
                egyedulalloUresHelyek++;
            }
        }
    }
}

Console.WriteLine($"A nézőtéren {egyedulalloUresHelyek} egyedülálló üres hely van.");
#endregion

#region 7. Feladat
Console.WriteLine("7. Feladat");

using (StreamWriter sw = new StreamWriter("szabad.txt"))
{
    for (int i = 0; i < sorokSzama; i++)
    {
        for (int j = 0; j < szekekSzama; j++)
        {
            if (foglaltsagMatrix[i, j] == 'x')
            {
                sw.Write('x');
            }
            else
            {
                sw.Write(kategoriaMatrix[i, j]);
            }
        }
        sw.WriteLine();
    }
}

Console.WriteLine("Adatok kiírva a szabad.txt fájlba");
#endregion