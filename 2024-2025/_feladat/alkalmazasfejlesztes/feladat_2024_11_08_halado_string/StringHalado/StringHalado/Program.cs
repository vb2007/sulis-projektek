using System.Data.SqlTypes;

string s = "árvíztűrő tükörfúrógép";
int pozicio;

#region IndexOf, IndexOfAny, LastIndexOf, LastIndexOfAny
Console.WriteLine("***************************\n");
pozicio = s.IndexOf('t');
Console.WriteLine($"A 't' karakter első előfordulási helye: {pozicio}.");

pozicio = s.IndexOf("zt");
Console.WriteLine($"A \"zt\" szöveg első előfordulási helye: {pozicio}.");

pozicio = s.IndexOf('Á');
Console.WriteLine($"Az 'Á' karakter első előfordulási helye: {pozicio}.");

pozicio = s.IndexOf('t');
pozicio = s.IndexOf('t', pozicio + 1);
Console.WriteLine($"A 't' karakter második előfordulási helye: {pozicio}.");

// A tömb bármelyik eleme hol fordul elő először
char[] ekezetesMaganhangzok = new char[] { 'á', 'é', 'ó', 'ö', 'ő', 'ú', 'ü', 'ű' };
pozicio = s.IndexOfAny(ekezetesMaganhangzok);
Console.WriteLine($"Az első ékezetes magánhangzó előfordulási helye: {pozicio}");

pozicio = s.IndexOfAny(new char[] { 'a', 'á', 'e', 'é', 'i', 'í', 'o', 'ó', 'ö', 'ő', 'u', 'ú', 'ü', 'ű' });
Console.WriteLine($"Az első magánhangzó előfordulási helye: {pozicio}");

// Utolsó előfordulás indexe
pozicio = s.LastIndexOf('t');
Console.WriteLine($"A 't' karakter utolsó előfordulási helye: {pozicio}.");

pozicio = s.LastIndexOfAny(ekezetesMaganhangzok);
Console.WriteLine($"Az utolsó ékezetes magánhangzó előfordulási helye: {pozicio}.");
#endregion

bool boolean;
#region Contains
Console.WriteLine("\n***************************\n");
boolean = s.Contains("it");
Console.WriteLine("Az \"it\" szöveg " + (boolean ? "" : "nem") + " szerepel a szóban.");

boolean = s.Contains('t');
Console.WriteLine("A 't' karakter " + (boolean ? "" : "nem") + " szerepel a szóban.");
#endregion

#region StartsWith, EndsWith
boolean = s.StartsWith('á');
Console.WriteLine("A szöveg " + (boolean ? "" : "nem") + " 'á' karakterrel kezdődik.");

boolean = s.StartsWith("ááá");
Console.WriteLine("A szöveg " + (boolean ? "" : "nem") + " \"ááá\" szöveggel kezdődik.");

boolean = s.EndsWith("ááá");
Console.WriteLine("A szöveg " + (boolean ? "" : "nem") + " \"ááá\" szöveggel végződik.");
#endregion

#region PadLeft(x), PadRight(v)
Console.WriteLine("\n***************************\n");
string t = "tigris";
string t2 = t.PadLeft(10);
Console.WriteLine(t2 + t2);

t2 = t.PadLeft(3);
Console.WriteLine(t2);

// *-al tölti fel az üresen maradt helyet
t2 = t.PadLeft(9, '*');
Console.WriteLine(t2);

// 3-3 csillagot rak a szöveg elé és mögé
t2 = t.PadLeft(t.Length + 3, '*').PadRight(t.Length + 6, '*');
Console.WriteLine(t2);
#endregion

#region Trim
// Whitespace és egyéb karakterek levágása a szöveg elejérő, végéről
Console.WriteLine("\n***************************\n");
string s2 = "\t\n\t\t\n      tigris\ttigris \n\t tigris     tigris\n\t  \t\n\n" + Environment.NewLine;

Console.WriteLine(s2);
Console.WriteLine(s2.TrimStart());
Console.WriteLine(s2);
Console.WriteLine(s2.TrimEnd());
Console.WriteLine(s2);
Console.WriteLine(s2.Trim());

string s3 = ".i|tigris|i.";
s3 = s3.Trim('.', 'i', '|');
Console.WriteLine(s3);
#endregion

#region Split
// Szöveg feldarabolása megadott karakter vagy szóköz mentén
string gy = "alma barack citrom";
string[] gyt = gy.Split();
//for (int i = 0; i < gyt.Length; i++)
//{
//    Console.WriteLine(gyt[i]);
//}

gy = ";dió;eper körte;szilva";
//Console.WriteLine(gy);
//gyt = gy.Split(';');
//gyt = gy.Split(new char[] { ' ', ';' });
//for (int i = 0; i < gyt.Length; i++)
//{
//    Console.WriteLine(gyt[i]);
//}
//gyt = gy.Split(new char[] { ' ', ';' }, 4);
//for (int i = 0; i < gyt.Length; i++)
//{
//    Console.WriteLine(gyt[i]);
//}

gy += ";;dinnye      ; narancs";
Console.WriteLine(gy);
gyt = gy.Split(new char[] { ' ', ';' });
for (int i = 0; i < gyt.Length; i++)
{
    Console.WriteLine(gyt[i]);
}
gyt = gy.Split(new char[] { ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);
for (int i = 0; i < gyt.Length; i++)
{
    Console.WriteLine(gyt[i]);
}
#endregion

#region String.join
// Gyűjtemény elemeinek összefűzése
string egybe = String.Join(", ", gyt);
Console.WriteLine(egybe);
Console.WriteLine(String.Join(", ", gyt));
Console.WriteLine(String.Join(", ", gyt, 4, 3));
#endregion