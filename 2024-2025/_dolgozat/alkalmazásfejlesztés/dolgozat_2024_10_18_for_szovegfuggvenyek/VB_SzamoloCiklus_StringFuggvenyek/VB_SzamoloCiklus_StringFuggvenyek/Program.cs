#region 1. Feladat
Console.Write("Add meg egy intervallum alsó határát: ");
int alsoIntervallum = int.Parse(Console.ReadLine()!);
Console.Write("Add meg egy intervallum felső határát: ");
int felsoIntervallum = int.Parse(Console.ReadLine()!);

Console.WriteLine("\nAz intervallumba tartozó minden 2. szám csökkenő sorrendben: ");
for (int i = felsoIntervallum - 1; i >= alsoIntervallum; i -= 2)
{
    Console.Write(i + " ");
}

Console.WriteLine("\n\nAz intervallumba tartozó 3-mal osztható számok: ");
for (int i = alsoIntervallum; i < felsoIntervallum; i++)
{
    if (i % 3 == 0)
    {
        Console.WriteLine(i);
    }
}

Console.WriteLine("\n10 darab véletlen valós szám az intervallumból: ");
Random random = new Random();
for (int i = 10; i > 0; i--)
{
    Console.WriteLine(random.NextDouble() * (felsoIntervallum - alsoIntervallum) + alsoIntervallum);
}
#endregion

#region 2. Feladat
Console.Write("\nAdjon meg 3 keresztnevet szóközzel elválasztva: ");
string keresztnevek = Console.ReadLine()!;

int elsoSzokozIndex = keresztnevek.IndexOf(" ");
string elsoKeresztnev = keresztnevek[0..elsoSzokozIndex];

int masodikSzokozIndex = keresztnevek.IndexOf(" ", elsoSzokozIndex + 1);
int masodikNevIndex = elsoSzokozIndex + 1;
string masodikKeresztnev = keresztnevek[masodikNevIndex..masodikSzokozIndex];

int harmadikNevIndex = masodikSzokozIndex + 1;
int keresztnevekHossza = keresztnevek.Length;
string harmadikKeresztnev = keresztnevek[harmadikNevIndex..keresztnevekHossza];

string jelszo = string.Empty;

jelszo = harmadikKeresztnev[(harmadikKeresztnev.Length - 2)..harmadikKeresztnev.Length].ToUpper();
jelszo = jelszo + random.Next(0, 10).ToString() + random.Next(0, 10).ToString();
jelszo = jelszo + masodikKeresztnev[..2];

int randomNumber = random.Next(0, 3);
switch (randomNumber)
{
    case 0:
        jelszo = jelszo + "#";
        break;
    case 1:
        jelszo = jelszo + "!";
        break;
    case 2:
        jelszo = jelszo + "%";
        break;
}

jelszo = jelszo + elsoKeresztnev[(elsoKeresztnev.Length - 2)..elsoKeresztnev.Length];

Console.WriteLine($"Az elkészült jelszó: {jelszo}");
#endregion

#region 3. Feladat
Console.Write("\nKérem a regisztrációs kódot: ");
string regisztraciosKod = Console.ReadLine()!;

bool tartalmazNagybeut = false;
bool tartalmasKisbetut = false;
bool tartalmazSzamot = false;
foreach (char i in regisztraciosKod)
{
    if (Char.IsUpper(i))
    {
        tartalmazNagybeut = true;
    }
    if (Char.IsLower(i))
    {
        tartalmasKisbetut = true;
    }
    if (Char.IsNumber(i))
    {
        tartalmazSzamot = true;
    }
}

if (regisztraciosKod.Length < 8)
{
    Console.WriteLine("A kód nem megfelelő hosszúságú.");
}
else if (tartalmazNagybeut == false)
{
    Console.WriteLine("A kód nem tartalmaz nagybetűket.");
}
else if (tartalmasKisbetut == false)
{
    Console.WriteLine("A kód nem tartalmaz kisbetűt.");
}
else if (tartalmazSzamot == false)
{
    Console.WriteLine("A kód nem tartalmaz számot.");
}
else
{
    Console.WriteLine("A beolvasott kód a megadott szabályoknak megfelel.");
}
#endregion