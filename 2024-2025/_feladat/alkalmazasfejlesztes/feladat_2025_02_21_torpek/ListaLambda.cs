List<int> lista = new List<int>();

#region feltöltés
//Feltöltés véletlen elemekkel
for (int i = 0; i < 10; i++)
{
    lista.Add(Random.Shared.Next(-10,11));
}
#endregion

#region kiírás
//Lista elemeinek kiírása
foreach (var item in lista)
{
    Console.WriteLine(item);
}
Console.WriteLine();
Console.WriteLine(String.Join("; ", lista));
Console.WriteLine();
#endregion

#region összegzés
//Összegzés
int osszeg = 0;
//foreach (var item in lista)
//{
//    osszeg += item;
//}
osszeg = lista.Sum();
Console.WriteLine("Összeg: " + osszeg);
#endregion

#region átlag, minimum érték, maximum érték
double atlag = lista.Average();
Console.WriteLine("Átlag: " + atlag.ToString("0.00"));

int min = lista.Min();
Console.WriteLine("Minimum: " + min);

int max = lista.Max();
Console.WriteLine("Maximum: " + max);
#endregion

#region megszámlálás, összetett műveletek
int db = lista.Count;
Console.WriteLine("A lista elemszáma: " + db);

//int db_poz = lista.Count(x => x > 0);
//Console.WriteLine("A pozitív elemek száma: " + db_poz);

//int db_paros = lista.Count(barmi => barmi % 2 == 0);
//Console.WriteLine("A páros elemek száma: " + db_paros);

//int negyzetosszeg = lista.Sum(x => x * x);
//Console.WriteLine("Az elemek négyzetösszege: " + negyzetosszeg);

//double poz_atlag = lista.Where(x => x > 0).Average();
//Console.WriteLine("A pozitív számok átlaga: " + poz_atlag.ToString("0.00"));

//bool van_hatos = lista.Contains(6);
//Console.WriteLine(van_hatos);

//int db_pozz = lista.Where(x => x > 0).Count();
//Console.WriteLine(db_pozz);

//int hely = lista.IndexOf(6);
#endregion

