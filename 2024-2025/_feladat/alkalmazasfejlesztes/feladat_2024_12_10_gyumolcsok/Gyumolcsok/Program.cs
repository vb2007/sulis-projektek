//1. Feladat
string[] lines = File.ReadAllLines("gyumolcsok.txt");
int size = lines.Count();

//2. Feladat
string[] fruitNames = new string[lines.Length];
int[] fruitWeigths = new int[lines.Length];
for (int i = 0; i < size; i++)
{
    string[] data = lines[i].Split(';');
    fruitNames[i] = data[0];
    fruitWeigths[i] = int.Parse(data[1]);

    Console.WriteLine($"{fruitNames[i]}: {fruitWeigths[i]}kg");
}

//3. Feladat
int CountAllWeigth()
{
    int allWeigth = 0;
    for (int i = 0; i < size; i++)
    {
        allWeigth += fruitWeigths[i];
    }

    return allWeigth;
}

int allWeigth = CountAllWeigth();

Console.WriteLine($"Összesen ennyi kg gyümölcs termett: {allWeigth}");

//4. Feladat
Console.WriteLine($"Átlagosan {allWeigth / size}kg gyümölcs termett a kertben.");

//5. Feladat
int CountExactWeight(int weight)
{
    int exactlyKg = 0;
    for (int i = 0; i < size; i++)
    {
        if (fruitWeigths[i] == weight)
        {
            exactlyKg ++;
        }
    }
    return exactlyKg;
}

Console.WriteLine($"Összesen {CountExactWeight(10)} db gyümölcsből termett pontosan 10kg.");

//6. Feladat
(int, string) MostFruitGrown()
{
    int maxWeigth = 0;
    string maxName = String.Empty;
    for (int i = 0; i < size; i++)
    {
        if (fruitWeigths[i] > maxWeigth)
        {
            maxWeigth = fruitWeigths[i];
            maxName = fruitNames[i];
        }
    }

    return (maxWeigth, maxName);
}

var data1 = MostFruitGrown();

Console.WriteLine($"A(z) \"{data1.Item2}\" gyümölcsből nőtt a legtöbb ({data1.Item1} kg).");

//7. Feladat
string[] MinimumGrownAmountNames(int minimumWeigth)
{
    string[] minimumNames = new string[size];
    int minimumNamesIndex = 0;
    for (int i = 0; i < size; i++)
    {
        if (fruitWeigths[i] == minimumWeigth)
        {
            minimumNames[minimumNamesIndex++] = fruitNames[i];
        }
    }

    return minimumNames;
}

Console.WriteLine("Gyümölcsök nevei, melyekből legalább 30 kg termett idén: ");

string[] minimumFruitNames = MinimumGrownAmountNames(30);
for (int i = 0; i < minimumFruitNames.Count(); i++)
{
    Console.WriteLine(minimumFruitNames[i]);
}

//8. Feladat
string WasThereAnyFruitWithLessThanSpecifiedWeigth(int maximumWeight)
{
    for (int i = 0; i < size; i++)
    {
        if (fruitWeigths[i] < maximumWeight)
        {
            return fruitNames[i];
        }
    }

    return "";
}

string fruitNameWithSpecifiedWeigth = WasThereAnyFruitWithLessThanSpecifiedWeigth(10);

if (fruitNameWithSpecifiedWeigth == "")
{
    Console.WriteLine("Nem volt olyan gyümölcs, amiből kevesebb, mint 10kg termett idén.");
}
else
{
    Console.WriteLine($"Az első gyümölcs, amiből 10kg-nál kevesebb termett idén: {fruitNameWithSpecifiedWeigth}");
}