//1. Feladat
string[] lines = File.ReadAllLines("tortak.txt");
int LIST_SIZE = lines.Count();

//2. Feladat
string[] cakeNames = new string[lines.Length];
int[] cakePrices = new int[lines.Length];
void DisplayNamesAndPrices()
{
    for (int i = 0; i < LIST_SIZE; i++)
    {
        string[] data = lines[i].Split(';');
        cakeNames[i] = data[0];
        cakePrices[i] = int.Parse(data[1]);

        Console.WriteLine($"{cakeNames[i]} ({cakePrices[i]} Ft)");
    }
}

Console.WriteLine("A torták nevei és árai: ");
DisplayNamesAndPrices();

//3. Feladat
double AverageCakePrice()
{
    double avg = 0;
    for (int i = 0; i < LIST_SIZE; i++)
    {
        avg += cakePrices[i];
    }
    avg /= LIST_SIZE;

    return avg;
}

//ugyan nem kért kerekítést, de így szebb
Console.WriteLine($"A torták átlag ára: {Math.Round(AverageCakePrice(), 2)} Ft");

//4. Feladat
(int, string) MaxCakeData()
{
    int maxPrice = 0;
    string maxName = String.Empty;
    for (int i = 0; i < LIST_SIZE; i++)
    {
        if (cakePrices[i] > maxPrice)
        {
            maxPrice = cakePrices[i];
            maxName = cakeNames[i];
        }
    }

    return (maxPrice, maxName);
}

var maxData = MaxCakeData();
Console.WriteLine($"A legdrágább torta neve: {maxData.Item2} és ára: {maxData.Item1} Ft");

//5. Feladat
string[] MoreExpensiveThan(int price)
{
    string[] moreExpeniveThan = new string[LIST_SIZE];
    int moreExpensiveThanIndex = 0;
    for (int i = 0; i < LIST_SIZE; i++)
    {
        if (cakePrices[i] <= price)
        {
            moreExpeniveThan[moreExpensiveThanIndex++] = cakeNames[i];
        }
    }

    return moreExpeniveThan;
}

Console.WriteLine("Torták, melyek nem drágábbak 4500 Ft-nál:");
string[] moreExpensiveThan = MoreExpensiveThan(4500);
for (int i = 0; i < LIST_SIZE; i++)
{
    if (moreExpensiveThan[i] != null)
    {
        Console.WriteLine(moreExpensiveThan[i]);
    }
}

//6. Feladat
Console.WriteLine();
Console.Write("Add meg a keresendő torta nevét: ");
string readCakeName = Console.ReadLine()!;

void CheckCakePrice(string readCakeName)
{
    for (int i = 0; i < LIST_SIZE; i++)
    {
        if (cakeNames[i].Equals(readCakeName, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"A(z) {readCakeName} ára: {cakePrices[i]} Ft");
            return;
        }
    }
    Console.WriteLine($"A(z) {readCakeName} torta nem található.");
}

CheckCakePrice(readCakeName);