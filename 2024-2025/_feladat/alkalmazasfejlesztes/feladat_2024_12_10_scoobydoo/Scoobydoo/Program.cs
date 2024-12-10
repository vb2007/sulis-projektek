//1. Feladat
using System.Text;

string[] lines = File.ReadAllLines("nyomozas.txt", Encoding.UTF8);
int size = lines.Length;

string[] names = new string[size];
int[] numbers = new int[size];

for (int i = 0; i < size; i++)
{
    string[] reszletek = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

    string nev = string.Join(" ", reszletek.Take(reszletek.Length - 1));
    int szam = int.Parse(reszletek.Last());

    names[i] = nev;
    numbers[i] = szam;
}

//2. Feladat
Console.WriteLine("Az eltárolt adatok kötőjellel elválasztva: ");

for (int i = 0; i < size; i++)
{
    Console.WriteLine($"{names[i]} - {numbers[i]}");
}

//3. Feladat
Console.WriteLine($"Összesen {size} db nyomozáson vettek részt.");

//4. Feladat
float CalculateAverageSnacks()
{
    int snackSum = 0;
    for (int i = 0; i < size; i++)
    {
        snackSum += numbers[i];
    }

    float snackAvg = (float)snackSum / size;

    return snackAvg;
}

Console.WriteLine($"Átlagosan {Math.Round(CalculateAverageSnacks(), 2)} snacket gyűjtött Scobby-Doo egy nyomozás során.");

//5. Feladat
int CountLocationOccurences(string locationName)
{
    int occurences = 0;
    for (int i = 0; i < size; i++)
    {
        if (names[i] == locationName)
        {
            occurences++;
        }
    }

    return occurences;
}

Console.WriteLine($"Összesen {CountLocationOccurences("Hévízi-tó")} alkalommal nyomoztak a \"Hévízi-tó\"-nál.");

//6. Feladat
string CountMaxClueOccurenceAndReturnLocation()
{
    int maxClueOccurence = 0;
    string locationName = String.Empty;
    for (int i = 0; i < size; i++)
    {
        if (numbers[i] > maxClueOccurence)
        {
            maxClueOccurence = numbers[i];
            locationName = names[i];
        }
    }

    return locationName;
}

Console.WriteLine($"A \"{CountMaxClueOccurenceAndReturnLocation()}\" helyen találták a legtöbb nyomot.");

//7. Feladat
bool DidScoobyGetExactlyThatMuchClues(int clues)
{
    for (int i = 0; i < size; i++)
    {
        if (numbers[i] == clues)
        {
            return true;
        }
    }

    return false;
}

Console.WriteLine();
Console.Write("Adj meg egy számot: ");
int cluesInput = int.Parse(Console.ReadLine()!);

if (DidScoobyGetExactlyThatMuchClues(cluesInput))
{
    Console.WriteLine("Volt olyan nyomozás, amikor Scooby pont ennyi nyomot gyűjtött.");
}
else
{
    Console.WriteLine("Nem volt olyan nyomozás, amikor Scooby pont ennyi nyomot gyűjtött.");
}

//8. Feladat
Console.WriteLine();
Console.Write("Adj meg egy helyszínt: ");
string locationInput = Console.ReadLine()!;

int ReturnSnackCountBasedOnLocationName(string locationName)
{
    for (int i = 0; i < size; i++)
    {
        if (names[i] == locationName)
        {
            return numbers[i];
        }
    }

    return -1;
}

if (ReturnSnackCountBasedOnLocationName(locationInput) == -1)
{
    Console.WriteLine("Ezen a napon nem nyomoztak.");
}
else
{
    Console.WriteLine($"A(z) {locationInput} helyszínen Scooby összesen {ReturnSnackCountBasedOnLocationName(locationInput)} db snacket szerzett.");
}

//9. Feladat
int[] SortEvenSnacks()
{
    int[] evenSnacks = new int[size];
    int evenSnackCount = 0;

    for (int i = 0; i < size; i++)
    {
        if (numbers[i] % 2 == 0)
        {
            evenSnacks[evenSnackCount++] = numbers[i];
        }
    }

    return evenSnacks;
}

int[] evenSnaks = SortEvenSnacks();

Console.WriteLine("Páros snackek: ");
for (int i = 0; i < evenSnaks.Length; i++)
{
    Console.WriteLine(evenSnaks[i]);
}

//10. Feladat
string[] locationsWithAtLeast50Snacks = new string[size];

void WriteLocationsWithAtLeast50SnacksToFile()
{
    int locationsWithAtLeast50SnacksIndex = 0;
    for (int i = 0; i < size; i++)
    {
        if (numbers[i] >= 50)
        {
            locationsWithAtLeast50Snacks[locationsWithAtLeast50SnacksIndex++] = names[i];
        }
    }

    File.WriteAllLines("locations_with_at_least_50_snacks.txt", locationsWithAtLeast50Snacks, Encoding.UTF8);
}

WriteLocationsWithAtLeast50SnacksToFile();

//11. Feladat
int[] divisibleBy3 = new int[size];
int[] notDivisibleBy3 = new int[size];

void SortSnacksByDivisibility()
{
    int divisibleBy3Index = 0;
    int notDivisibleBy3Index = 0;

    for (int i = 0; i < size; i++)
    {
        if (numbers[i] % 3 == 0)
        {
            divisibleBy3[divisibleBy3Index++] = numbers[i];
        }
        else
        {
            notDivisibleBy3[notDivisibleBy3Index++] = numbers[i];
        }
    }
}

SortSnacksByDivisibility();

Console.WriteLine($"3-mal osztható snackek: {divisibleBy3}");
Console.WriteLine($"3-mal nem osztható snackek: {notDivisibleBy3}");