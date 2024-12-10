//1. Feladat
string[] lines = File.ReadAllLines("nyomozas.txt");
int size = lines.Length;

string[] nevek = new string[size];
int[] szamok = new int[size];

for (int i = 0; i < size; i++)
{
    string[] reszletek = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

    string nev = string.Join(" ", reszletek.Take(reszletek.Length - 1));
    int szam = int.Parse(reszletek.Last());

    nevek[i] = nev;
    szamok[i] = szam;
}

//2. Feladat
Console.WriteLine("Az eltárolt adatok kötőjellel elválasztva: ");

for (int i = 0; i < size; i++)
{
    Console.WriteLine($"{nevek[i]} - {szamok[i]}");
}

//3. Feladat
Console.WriteLine($"Összesen {size} db nyomozáson vettek részt.");

//4. Feladat
int snackAtlag = 0;
for (int i = 0; i < size; i++)
{

}