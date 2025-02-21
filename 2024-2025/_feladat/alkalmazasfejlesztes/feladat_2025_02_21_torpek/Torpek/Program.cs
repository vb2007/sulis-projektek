//1. Feladat
List<Gnome> gnomes = new List<Gnome>();

string filePath = "torpek.txt";
string[] lines = File.ReadAllLines(filePath);
for (int i = 1; i < lines.Length; i++)
{
    string[] parts = lines[i].Split(';');
    Gnome gnome = new Gnome(parts[0], parts[1], parts[2][0], int.Parse(parts[3]), int.Parse(parts[4]));
    gnomes.Add(gnome);
}

//foreach (var torpe in torpek)
//{
//    Console.WriteLine($"{torpe.Name}, {torpe.Clan}, {torpe.Gender}, {torpe.Weight} kg, {torpe.Height} cm");
//}

//2. Feladat
Console.WriteLine($"2. Feladat: Az állományban található törpék száma: {gnomes.Count} db");

//3. Feladat
Console.WriteLine($"3. Feladat: A törpék átlagos súlya: {Math.Round(gnomes.Average(x => x.Weight), 1)} kg");

//4. Feladat
Gnome legmagasabbTorpe = gnomes.MaxBy(x => x.Height);
Console.WriteLine($"4. Feladat: A legmagasabb törpe adatai:");
Console.WriteLine($"\tNeve: {legmagasabbTorpe.Name}");
Console.WriteLine($"\tKlán: {legmagasabbTorpe.Clan}");
Console.WriteLine($"\tNem: {legmagasabbTorpe.Gender}");
Console.WriteLine($"\tSúly: {legmagasabbTorpe.Weight} kg");
Console.WriteLine($"\tMagasság: {legmagasabbTorpe.Height} cm");

//5. Feladat
Console.Write("5. feladat: A klán neve: ");
string clanInput = Console.ReadLine()!;
string loweredClanInput = clanInput.ToLower();
bool isClanFound = gnomes.Exists(x => x.Clan.ToLower() == loweredClanInput);
Console.WriteLine($"\t{(isClanFound ? "Van" : "Nincs")} {clanInput} nevű klánba tartozó törpe.");

//6. Feladat
double smallestBMIValue = Math.Round(gnomes.Min(torpe =>
{
    double heightInMeters = torpe.Height / 100.0;
    return torpe.Weight / (heightInMeters * heightInMeters);
}), 1);

Console.WriteLine($"6. feladat: A legkisebb TTI érték: {smallestBMIValue}");

//7. Feladat
List<Gnome> femaleGnomes = gnomes.FindAll(x => x.Gender == 'N');
Console.WriteLine($"7. feladat: Nőnemű törpék: {string.Join(", ", femaleGnomes.Select(t => $"{t.Name} ({t.Clan})"))}");

//8. Feladat
Console.WriteLine($"8. feladat: Résztvevők: ");
foreach (Gnome gnome in gnomes.OrderBy(g => g.Clan).ThenBy(g => g.Name))
{
    Console.WriteLine($"{gnome.Name} ({gnome.Clan})");
}

//9. Feladat
IEnumerable<string> uniqueClans = gnomes.Select(g => g.Clan).Distinct().OrderBy(clan => clan);
Console.WriteLine($"9. feladat: Résztvevő klánok: {string.Join(", ", uniqueClans)}");

//10. Feladat
var top3GnomesByBMI = gnomes
    .Select(g => new { Gnome = g, BMI = g.Weight / Math.Pow(g.Height / 100.0, 2) })
    .OrderByDescending(g => g.BMI)
    .Take(3);

Console.WriteLine("10. feladat: A 3 legnagyobb TTI-vel rendelkező törpe:");
foreach (var g in top3GnomesByBMI)
{
    Console.WriteLine($"{g.Gnome.Name} ({g.Gnome.Clan})");
}

public record Gnome(string Name, string Clan, char Gender, int Weight, int Height);