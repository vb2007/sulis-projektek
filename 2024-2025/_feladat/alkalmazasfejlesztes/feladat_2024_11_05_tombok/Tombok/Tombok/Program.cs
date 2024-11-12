#region 1. Feladat
const int MERET = 30;
Random r = new Random();

int[] tomb = new int[MERET];

for (int i = 0; i < MERET; i++)
{
    tomb[i] = r.Next(2, 6);
    Console.WriteLine($"{i + 1}. diák érdemjegye: {tomb[i]}");
}
#endregion

#region 2. Feladat
const int MERET2 = 5;

int[] tomb2 = new int[MERET2];

tomb2[0] = 1000;
tomb2[1] = 1500;
tomb2[2] = 2000;
tomb2[3] = 2500;
tomb2[4] = 3500;

for (int i = 0; i < MERET2; i++)
{
    Console.WriteLine($"Az {i + 1}. könyv eredeti ára: {tomb2[i]} Ft.");
    Console.WriteLine($"Az {i + 1}. könyv új ára 15%-os akció után: {tomb2[i] - (tomb2[i] * 0.15)} Ft.");
}
#endregion

#region 3. Feladat
const int MERET3 = 50;

int[] tomb3 = new int[MERET3];

for (int i = 0; i < MERET3; i++)
{
    tomb3[i] = r.Next(1, 7);
    if (tomb3[i] == 6)
    {
        Console.WriteLine("Újra dobhat.");
        tomb3[i] = r.Next(1, 6);
    }
}
#endregion

#region 4. Feladat
const int MERET4 = 5;

string[] tomb4 = new string[MERET4];

tomb4[0] = "Lakatos Dzsúlió";
tomb4[1] = "Armano Gusztáv";
tomb4[2] = "Lakatos Raffael";
tomb4[3] = "Hidegkuti Armando";
tomb4[4] = "Busák Krisztofer";

int randomNumber = r.Next(0, MERET4 - 1);
Console.WriteLine($"A mai napon {tomb4[randomNumber]} órai munkája lesz osztályozva.");
#endregion

#region 5. Feladat
const int MERET5 = 5;

string[] tomb5 = new string[MERET5];

tomb5[0] = "Dolgozunk a probléma megoldásán, türelmüket kérjük.";
tomb5[1] = "Ez a funkció csak a következő verzióban lesz elérhető.";
tomb5[2] = "Kipróbáltuk, nekünk működik. Kérjük, olvassa el figyelmesebben a dokumentációt!";
tomb5[3] = "Ez a funkció technikai okok miatt nem megvalósítható.";
tomb5[4] = "Kérjük, pontosítsa a hibabejelentését, a hibajelenségről küldjön egy képernyő képet is!";

int randomNumber5 = r.Next(0, MERET5 - 1);
Console.WriteLine($"A kifogás: {tomb5[randomNumber5]}");
#endregion

#region 6. Feladat
Console.Write("Adj meg egy számot: ");
int szam6 = int.Parse(Console.ReadLine()!);

int a = 0, b = 1, c;

Console.WriteLine($"Az első {szam6} Fibonacci szám: ");
for (int i = 0; i < szam6; i++)
{
    Console.Write(a + " ");
    c = a + b;
    a = b;
    b = c;
}
#endregion

#region 7. Feladat
//a
const int MERET7a = 10;

int[] tomb7a = new int[MERET7a];

for (int i = 0; i < MERET7a; i++)
{
    tomb7a[i] = r.Next(0, 2);
    Console.WriteLine(tomb7a[i]);
}
#endregion

#region 8. Feladat
const int MERET8 = 6;

int[] tomb8 = new int[MERET8];

for (int i = 0; i < MERET8; i++)
{
    tomb8[i] = r.Next(20, 90);
}

double[] tomb82 = new double[MERET8];

for (int i = 0; i < MERET8; i++)
{
    tomb82[i] = tomb8[i] - (tomb8[i] * 0.1);
    if (tomb82[i] > 65)
    {
        Console.WriteLine($"{i + 1}. sebesség: {tomb82[i]} : Büntetés");
    }
    else
    {
        Console.WriteLine($"{i + 1}. sebesség: {tomb82[i]}");
    }
}
#endregion

#region 9. Feladat
const int MERET9 = 100;

bool[] tomb9 = new bool[MERET9];

for (int i = 1; i <= MERET9; i++)
{
    for (int j = i - 1; j < MERET9; j += 1)
    {
        tomb9[j] = !tomb9[j];
    }
}

Console.WriteLine($"Ezek az ajtók vannak kinyitva: ");
for (int i = 0; i < MERET9; i++)
{
    if (!tomb9[i])
    {
        Console.WriteLine($"Az {i + 1}. nigger megszökött a gyapotmezőről");
    }
}
#endregion

#region 10. Feladat
Console.WriteLine("A 6 számjegyű e-PIN kód:");
for (int i = 1; i <= 6; i++)
{
    Console.WriteLine($"{i}. számjegy: {r.Next(0, 10)}");
}
#endregion