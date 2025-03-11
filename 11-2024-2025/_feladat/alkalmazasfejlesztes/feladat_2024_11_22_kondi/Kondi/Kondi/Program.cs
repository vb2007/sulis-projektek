string filePath = "kondi.txt";

//1. feladat
string[] lines = File.ReadAllLines(filePath);
int count = lines.Length;

Console.WriteLine($"1. feladat: {count} sportoló adatait rögzítettük");

//2. feladat
double totalWeight = 0;
foreach (var line in lines)
{
    var data = line.Split(';');
    totalWeight += double.Parse(data[1]);
}

double averageWeight = totalWeight / count;
Console.WriteLine($"2. feladat: Az átlagos tömeg {averageWeight:F1} kg.");

//3. feladat
Console.Write($"Kérek egy magasság adatot (cm-ben)! ");
double inputHeight = double.Parse(Console.ReadLine()!);

int shorterCount = 0;
foreach (var line in lines)
{
    var data = line.Split(';');
    double height = double.Parse(data[2]);
    if (height < inputHeight)
    {
        shorterCount++;
    }
}

Console.WriteLine($"\t{inputHeight} cm-nél {shorterCount} sportoló alacsonyabb.");

//4. feladat
string lightestAthlete = string.Empty;
double minWeight = double.MaxValue;

foreach (var line in lines)
{
    var data = line.Split(';');
    double weight = double.Parse(data[1]);
    if (weight < minWeight)
    {
        minWeight = weight;
        lightestAthlete = line;
    }
}

var lightestData = lightestAthlete.Split(';');
Console.WriteLine($"A legkönnyebb ember:\n\tNeve: {lightestData[0]}\n\tTömege: {lightestData[1]} kg\n\tMagassága: {lightestData[2]} cm");

//5. feladat
using (StreamWriter writer = new StreamWriter("bmi.txt"))
{
    foreach (var line in lines)
    {
        var data = line.Split(';');
        string name = data[0];
        double weight = double.Parse(data[1]);
        double height = double.Parse(data[2]);
        double bmi = weight / Math.Pow(height / 100, 2);
        writer.WriteLine($"{name} {bmi:F2}");
    }
}