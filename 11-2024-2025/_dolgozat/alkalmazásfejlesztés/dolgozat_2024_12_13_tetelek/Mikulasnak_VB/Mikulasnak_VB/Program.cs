//1. Feladat
using System.Text;

const string fileName = "hajnal.txt";
string[] lines = File.ReadAllLines(fileName);
int listSize = int.Parse(lines[0]) + 1;

//2. Feladat
Console.WriteLine("2. Feladat");
int[] csokik = new int[listSize];
int[] virgacsok = new int[listSize];

void SortReadDataIntoLists()
{
    for (int i = 1; i < listSize; i++)
    {
        var data = lines[i].Split(';');

        csokik[i] = int.Parse(data[0]);
        virgacsok[i] = int.Parse(data[1]);
    }
}

SortReadDataIntoLists();

void PrintSortedData()
{
    for (int i = 1; i < listSize; i++)
    {
        Console.WriteLine($"{i}. ház: {csokik[i]} csokoládé, {virgacsok[i]} virgács");
    }
}

PrintSortedData();

//3. Feladat
int CountSumOfList(int[] list)
{
    int sum = 0;
    for (int i = 1; i < listSize; i++)
    {
        sum += list[i];
    }

    return sum;
}

int csokikSum = CountSumOfList(csokik);
int virgacsokSum = CountSumOfList(virgacsok);
int allSum = csokikSum + virgacsokSum;

Console.WriteLine("3. Feladat");
Console.WriteLine($"Összesen {allSum} csokit és virgácsot vigyen az utcába.");

//4. Feladat
bool IsThereAHouse()
{
    for (int i = 1; i < listSize; i++)
    {
        if (virgacsok[i] > csokik[i])
        {
            return true;
        }
    }

    return false;
}

Console.WriteLine("4. Feladat");
Console.WriteLine($"{(IsThereAHouse() ? "Van" : "Nincs")} olyan ház, ahova több virgács kell, mint csoki.");

//5. Feladat
int CountMaxIndex(int[] list)
{
    int maxIndex = 1;
    for (int i = 1; i < listSize; i++)
    {
        if (list[i] > list[maxIndex])
        {
            maxIndex = i;
        }
    }
    return maxIndex;
}

Console.WriteLine("5. Feladat");
Console.WriteLine($"A(z) {CountMaxIndex(virgacsok)}. házban lakik a legtöbb rosszcsont.");

//6. Feladat
float avgPresents = (float)allSum / (float)listSize;

int LessThanAvgPresents(int[] list1, int[] list2, float avg)
{
    int lessThanAvgPresents = 0;
    for (int i = 1; i < listSize; i++)
    {
        if ((list1[i] + list2[i]) < avg)
        {
            lessThanAvgPresents++;
        }
    }

    return lessThanAvgPresents;
}

Console.WriteLine("6. Feladat");
Console.WriteLine($"Összesen {LessThanAvgPresents(csokik, virgacsok, avgPresents)} házba kell az átlagnál kevesebb ajándékot vinnie.");


//7. Feladat
Console.WriteLine("7. Feladat");
Console.Write("Adj meg egy értéket: ");

int inputValue = int.Parse(Console.ReadLine()!);

void PrintLessThanGivenChocolates(int[] list, int lessThanValue)
{
    Console.WriteLine();
    for (int i = 1; i < listSize; i++)
    {
        if (list[i] > lessThanValue)
        {
            Console.Write($"{i},");
        }
    }
}

PrintLessThanGivenChocolates(csokik, inputValue);

//8. Feladat
void PrintSummedWeigth(int[] list1, int[] list2, int weigth1, int weigth2)
{
    string[] houseWeigths = new string[listSize];

    for (int i = 1; i < listSize; i++)
    {
        houseWeigths[i - 1] = ((list1[i] * weigth1) + (list2[i] * weigth2)).ToString();
    }

    File.WriteAllLines("tomeg.txt", houseWeigths, Encoding.UTF8);
}

PrintSummedWeigth(csokik, virgacsok, 10, 20);