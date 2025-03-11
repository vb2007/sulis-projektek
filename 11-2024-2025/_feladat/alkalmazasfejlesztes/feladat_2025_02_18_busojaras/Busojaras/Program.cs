List<string> jelentkezok = new();
List<string> nevsorbanJelentkezok = new();

foreach(var item in File.ReadAllLines("jelentkezok.txt"))
{
    jelentkezok.Add(item);
    nevsorbanJelentkezok.Add(item);
}

nevsorbanJelentkezok.Sort();
Console.WriteLine($"Jelentkezők: {string.Join(", ", nevsorbanJelentkezok)}");

List<string> mehet = jelentkezok.GetRange(0, 40);
mehet.Sort();

List<string> helyhiany = jelentkezok.GetRange(40, jelentkezok.Count - 40);
Console.WriteLine($"Mehetnek: {string.Join(", ", mehet)}");
Console.WriteLine($"Helyhiány miatt nem mehetnek: {string.Join(", ", helyhiany)}");

List<string> bukottak = new();
foreach(var item in File.ReadAllLines("bukottak"))
{
    bukottak.Add(item);
}

List<string> toroltNevek = jelentkezok.Intersect(bukottak).ToList();

foreach(var item in toroltNevek)
{
    mehet.Remove(item);
    helyhiany.Remove(item);
    jelentkezok.Remove(item);
}

toroltNevek.Sort();

StreamWriter sw = new StreamWriter("torol.txt");
sw.WriteLine(string.Join("\n", toroltNevek));
sw.Close();

List<string> utolag = helyhiany.GetRange(0, 40 - mehet.Count);
mehet.AddRange(utolag);

Console.WriteLine($"Utólag kerültek be: {string.Join(", ", utolag)}");

mehet.Sort();
StreamWriter sw2 = new StreamWriter("resztvevok.txt");
sw2.WriteLine(string.Join("\n", mehet));
sw2.Close();

Console.WriteLine("Adjon meg egy nevet: ");
string nev = Console.ReadLine()!;
if(jelentkezok.Contains(nev))
{
    Console.WriteLine("Nem jelentkezett.");
}
else if(mehet.Contains(nev))
{
    Console.WriteLine("Részt vett.");
}
else if(helyhiany.Except(utolag).Contains(nev))
{
    Console.WriteLine("Helyhiány miatt nem vehet részt.");
}
else
{
    Console.WriteLine("Bukás miatt nem vehet részt.");
}