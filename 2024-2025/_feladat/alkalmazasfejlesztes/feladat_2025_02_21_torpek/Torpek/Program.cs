//1. Feladat
string filePath = "torpek.txt";
List<Torpe> torpek = new List<Torpe>();

string[] lines = File.ReadAllLines(filePath);
for (int i = 1; i < lines.Length; i++)
{
    string[] parts = lines[i].Split(';');
    Torpe torpe = new Torpe(parts[0], parts[1], parts[2][0], int.Parse(parts[3]), int.Parse(parts[4]));
    torpek.Add(torpe);
}

//foreach (var torpe in torpek)
//{
//    Console.WriteLine($"{torpe.Nev}, {torpe.Klan}, {torpe.Nem}, {torpe.Weight} kg, {torpe.Magassag} cm");
//}

//2. Feladat
Console.WriteLine($"2. Feladat: Az állományban található törpék száma: {torpek.Count} db");

//3. Feladat
Console.WriteLine($"3. Feladat: A törpék átlagos súlya: {Math.Round(torpek.Average(x => x.Weight), 1)} kg");

//4. Feladat
Torpe legmagasabbTorpe = torpek.MaxBy(x => x.Height);
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
bool isClanFound = torpek.Exists(x => x.Clan.ToLower() == loweredClanInput);
Console.WriteLine($"\t{(isClanFound ? "Van" : "Nincs")} {clanInput} nevű klánba tartozó törpe.");

//6. Feladat
Console.WriteLine("6. Feladat: A törpék testtömeg indexe (BMI):");
foreach (var torpe in torpek)
{
    double heightInMeters = torpe.Height / 100.0;
    double bmi = torpe.Weight / (heightInMeters * heightInMeters);
    Console.WriteLine($"\t{torpe.Name} BMI-je: {Math.Round(bmi, 2)}");
}

//7. Feladat
Console.WriteLine($"Nőnemű törpék: {torpek.FindAll(x => x.Gender == 'N')}");

public record Torpe(string Name, string Clan, char Gender, int Weight, int Height);