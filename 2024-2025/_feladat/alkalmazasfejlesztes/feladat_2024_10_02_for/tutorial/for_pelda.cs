//1-től 10-ig kiírjuk a számokat egyesével
for (int i = 1; i <= 10; i++)
{
    Console.WriteLine(i);
}

//10-től 1-ig kiírjuk a számokat egyesével
for (int i = 10; i >= 1; i--)
{
    Console.WriteLine(i);
}

//10-ig kiírjuk a nem negatív páros számokat
//Első megoldás
for (int i = 0; i <= 10; i += 2)
{ //i+=2 jelentése: az i eddigi értékénél 2-vel nagyobb érték legyen i új értéke
    Console.WriteLine(i);
}
Console.WriteLine();
////Második megoldás
for (int i = 0; i <= 10; i = i + 2)
{ // i = i+ 2 jelentése: veszem az i értékét, megnövelem kettővel, és ez lesz az i új értéke
    Console.WriteLine(i);
}
Console.WriteLine();
////Harmadik megoldás
for (int i = 0; i <= 10; i++)
{
    if (i % 2 == 0) //i 2-vel osztva 0-t ad maradékul?
    {
        Console.WriteLine(i);
    }
}

//Első 10 négyzetszám
for (int i = 1; i < 11; i++)
{
    Console.WriteLine(i * i);
}

//1-től 100-ig kiírjuk egy adott számmal osztható értékeket
Console.Write("Kérem adja meg a számot: ");
int szam = int.Parse(Console.ReadLine()!);
for (int i = 1; i < 101; i++)
{
    if (i % szam == 0)
    {
        Console.WriteLine(i);
    }
}

//Szomszédos számok szorzata
for (int i = 1; i < 11; i++)
{
    Console.WriteLine($"{i-1}*{i}={(i-1)*i}");
}
