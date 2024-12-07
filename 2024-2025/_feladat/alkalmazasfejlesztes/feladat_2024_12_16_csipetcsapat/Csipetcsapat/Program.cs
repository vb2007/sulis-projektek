//2. Feladat

string[] lines = File.ReadAllLines("gyujtemeny.txt");
int numberOfLines = int.Parse(lines[0]);
int[] numbers = new int[numberOfLines];

for (int i = 0; i < numberOfLines; i++)
{
    numbers[i] = int.Parse(lines[i + 1]);
}

//3. Feladat
void CheckIfAnyNutsWereCollected()
{
    bool nutsWereNotCollected = false;
    for (int i = 0; i < numberOfLines; i++)
    {
        if (numbers[i] < 1)
        {
            nutsWereNotCollected = true;
            break;
        }
    }

    if (nutsWereNotCollected)
    {
        Console.WriteLine("Volt olyan nap, amikor egy diót sem gyűjtöttek.");
    }
    else
    {
        Console.WriteLine("Nem volt olyan nap, amikor egy diót sem gyűjtöttek.");
    }
}

CheckIfAnyNutsWereCollected();

//4. Feladat
int CountMinimumNutsCollected(int minimumNumber)
{
    int minimumNutsCollectedDays = 0;
    for (int i = 0; i < numberOfLines; i++)
    {
        if (numbers[i] >= minimumNumber)
        {
            minimumNutsCollectedDays++;
        }
    }

    return minimumNutsCollectedDays;
}

Console.WriteLine($"{CountMinimumNutsCollected(45)} olyan nap volt, amikor legalább 45 diót / mogyorót szedtek.");

//5. Feladat
Console.WriteLine();
Console.Write("Adj meg egy számot: ");
int readNumber = int.Parse(Console.ReadLine()!);

int ReturnDayWhenNutsWereExactlyCollected(int exactNumber)
{
    for (int i = 0; i < numberOfLines; i++)
    {
        if (numbers[i] == exactNumber)
        {
            return i + 1;
        }
    }

    return -1;
}

int nutsWereExactlyCollected = ReturnDayWhenNutsWereExactlyCollected(readNumber);

if (nutsWereExactlyCollected != -1)
{
    Console.WriteLine($"Pontosan a(z) {nutsWereExactlyCollected}. napon gyűjtöttek {readNumber} darab diót / mogyorót.");
}
else
{
    Console.WriteLine($"Nem volt olyan nap, amikor pontosan {readNumber} diót / mogyorót gyűjtöttek.");
}

//6. Feladat
int CountDaysWhenNumberOfNutsWereOdd()
{
    int oddNutsCollectedDays = 0;
    for (int i = 0; i < numberOfLines; i++)
    {
        if (numbers[i] % 2 != 0)
        {
            oddNutsCollectedDays++;
        }
    }
    return oddNutsCollectedDays;
}

Console.WriteLine($"{CountDaysWhenNumberOfNutsWereOdd()} alkalommal fordult elő, hogy nem tudták egyenlően szétosztani az elemózsiát.");

//7. Feladat
int FindTheFirstDayWhenNutsWereDivideable(int divideableBy)
{
    for (int i = 0; i < numberOfLines; i++)
    {
        if (numbers[i] % divideableBy == 0)
        {
            return i + 1;
        }
    }

    return -1;
}

int nutsWereDivideable = FindTheFirstDayWhenNutsWereDivideable(5);

if (nutsWereDivideable != -1)
{
    Console.WriteLine($"Az első olyan nap, amikor 5-tel osztható volt a diók / mogyorók száma: {nutsWereDivideable}.");
}
else
{
    Console.WriteLine("Nem volt olyan nap, amikor 5-tel osztható lett volna a diók / mogyorók száma.");
}

//8. Feladat
int[] turbo = new int[numberOfLines];

for (int i = 0; i < numberOfLines; i++)
{
    turbo[i] = numbers[i] * 3;
}

using (StreamWriter writer = new StreamWriter("turbo.txt"))
{
    for (int i = 0; i < numberOfLines; i++)
    {
        writer.WriteLine($"{i + 1}. nap: {turbo[i]} darab");
    }
}