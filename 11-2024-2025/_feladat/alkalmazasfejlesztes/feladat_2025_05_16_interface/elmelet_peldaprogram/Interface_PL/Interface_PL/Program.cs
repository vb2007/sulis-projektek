using Interface_PL;

//string a = "alma";
//string t = "tigris";

//Console.WriteLine(a.CompareTo(t));
//Console.WriteLine(t.CompareTo(a));
//Console.WriteLine(t.CompareTo(t));

List<Telek> telkek = new();
List<string> hiba = new();

for (int i = 0; i < 10; i++)
{
    int szelesseg = Random.Shared.Next(-3, 10);
    int hosszusag = Random.Shared.Next(-3, 10);
	try
	{
		telkek.Add(new Telek(szelesseg, hosszusag));
	}
	catch (RosszMeretException ex)
	{
		hiba.Add($"{ex.Message}");
	}
	catch 
	{
		hiba.Add("Váratlan hiba történt.");
	}
}

telkek.Sort();
Console.WriteLine("Telkek:");
foreach (var item in telkek)
{
    Console.WriteLine(item);
}
Console.WriteLine("Hiba lista:");
foreach (var item in hiba)
{
    Console.WriteLine(item);
}

ITerulet valami = new Telek(10, 20);
List<ITerulet> teruletek = new List<ITerulet>();
teruletek.Add(valami);
Console.WriteLine(teruletek[0]);
