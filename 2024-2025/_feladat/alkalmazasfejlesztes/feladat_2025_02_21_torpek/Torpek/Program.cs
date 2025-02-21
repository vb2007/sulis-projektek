#region Kötelező feladatok
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
Gnome tallestGnome = gnomes.MaxBy(x => x.Height);
Console.WriteLine($"4. Feladat: A legmagasabb törpe adatai:");
Console.WriteLine($"\tNeve: {tallestGnome.Name}");
Console.WriteLine($"\tKlán: {tallestGnome.Clan}");
Console.WriteLine($"\tNem: {(tallestGnome.Gender == 'F' ? "Férfi" : "Nő")}");
Console.WriteLine($"\tSúly: {tallestGnome.Weight} kg");
Console.WriteLine($"\tMagasság: {tallestGnome.Height} cm");

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
#endregion

#region Gyakorló feladatok
//11. Feladat
int femaleGnomeCount = gnomes.Count(g => g.Gender == 'N');
Console.WriteLine($"11. feladat: Nőnemű törpék száma: {femaleGnomeCount}");

//12. Feladat
int kovaClanCount = gnomes.Count(g => g.Clan == "Kova");
Console.WriteLine($"12. feladat: Kova klánba tartozó törpék száma: {kovaClanCount}");

//13. Feladat
int femaleKovaClanCount = gnomes.Count(g => g.Clan == "Kova" && g.Gender == 'N');
Console.WriteLine($"13. feladat: Acél klánba tartozó nőnemű törpék száma: {femaleKovaClanCount}");

//14. Feladat
double averageBMI = gnomes.Average(g => g.Weight / Math.Pow(g.Height / 100.0, 2));
Console.WriteLine($"14. feladat: Törpék átlagos TTI-je: {Math.Round(averageBMI, 1)}");

//15. Feladat
double averageMaleBMI = gnomes.Where(g => g.Gender == 'F').Average(g => g.Weight / Math.Pow(g.Height / 100.0, 2));
Console.WriteLine($"15. feladat: Férfi törpék átlagos TTI-je: {Math.Round(averageMaleBMI, 1)}");

//16. Feladat
Gnome smallestBMIGnome = gnomes.OrderBy(g => g.Weight / Math.Pow(g.Height / 100.0, 2)).First();
Console.WriteLine($"16. feladat: Legkisebb TTI-vel rendelkező törpe: {smallestBMIGnome.Name} ({smallestBMIGnome.Clan})");

//17. Feladat
int lightestMaleWeight = gnomes.Where(g => g.Gender == 'F').Min(g => g.Weight);
Console.WriteLine($"17. feladat: Legkisebb súlyú férfi törpe: {lightestMaleWeight} kg");

//18. Feladat
Gnome tallestFemaleGnome = gnomes.Where(g => g.Gender == 'N').OrderByDescending(g => g.Height).First();
Console.WriteLine($"18. feladat: Legmagasabb nőnemű törpe adatai:");
Console.WriteLine($"\tNeve: {tallestFemaleGnome.Name}");
Console.WriteLine($"\tKlán: {tallestFemaleGnome.Clan}");
Console.WriteLine($"\tNem: {(tallestFemaleGnome.Gender == 'F' ? "Férfi" : "Nő")}");
Console.WriteLine($"\tSúly: {tallestFemaleGnome.Weight} kg");
Console.WriteLine($"\tMagasság: {tallestFemaleGnome.Height} cm");

//19. Feladat
bool hasHighBMI = gnomes.Any(g => g.Weight / Math.Pow(g.Height / 100.0, 2) > 40);
Console.WriteLine($"19. feladat: Van-e olyan törpe, akinek 40-nél nagyobb a TTI-je: {(hasHighBMI ? "Igen" : "Nem")}");

//20. Feladat
bool hasFemaleFromKova = gnomes.Any(g => g.Clan == "Kova" && g.Gender == 'N');
Console.WriteLine($"20. feladat: Jött-e női törpe a Kova klánból: {(hasFemaleFromKova ? "Igen" : "Nem")}");

//21. Feladat
int maleGnomeCount = gnomes.Count(g => g.Gender == 'F');
int genderDifference = maleGnomeCount - femaleGnomeCount;
Console.WriteLine($"21. feladat: Férfi és női törpék számának különbsége: {genderDifference}");

//22. Feladat
var gnomesByClanAndHeight = gnomes.GroupBy(g => g.Clan)
    .Select(g => new { Clan = g.Key, Gnomes = g.OrderByDescending(gn => gn.Height).ToList() })
    .ToList();
Console.WriteLine("22. feladat: Törpék klánonként magasság szerint csökkenő sorrendben:");
foreach (var group in gnomesByClanAndHeight)
{
    Console.WriteLine($"{group.Clan} klán:");
    foreach (var gnome in group.Gnomes)
    {
        Console.WriteLine($"\t{gnome.Name} ({gnome.Height} cm)");
    }
}

//23. Feladat
var sortedGnomes = gnomes.OrderBy(g => g.Gender == 'F').ThenBy(g => g.Name).ToList();
Console.WriteLine("23. feladat: Résztvevők nem és név szerint rendezve:");
foreach (var gnome in sortedGnomes)
{
    Console.WriteLine($"{gnome.Name} ({gnome.Clan}) ({gnome.Gender})");
}

//24. Feladat
int uniqueWeightsCount = gnomes.Select(g => g.Weight).Distinct().Count();
Console.WriteLine($"24. feladat: Különböző testsúlyú törpék száma: {uniqueWeightsCount}");

//25. Feladat
List<Gnome> lowest5MaleGnomes = gnomes.Where(g => g.Gender == 'F').OrderBy(g => g.Height).Take(5).ToList();
Console.WriteLine("25. feladat: 5 legalacsonyabb férfi törpe:");
foreach (Gnome gnome in lowest5MaleGnomes)
{
    Console.WriteLine($"{gnome.Name} ({gnome.Clan}) - {gnome.Height} cm");
}
#endregion

public record Gnome(string Name, string Clan, char Gender, int Weight, int Height);