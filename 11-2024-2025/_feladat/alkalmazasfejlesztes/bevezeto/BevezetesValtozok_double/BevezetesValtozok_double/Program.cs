//double a = 1.6;
//Console.WriteLine(a);

//Console.Write("Kérek egy új valós számot: ");
//double b = double.Parse(Console.ReadLine());
//Console.WriteLine(b);

//a = 5;
//b = 3;
//Console.WriteLine(a / b);

//double c = 0.1;
//double c3 = c + c + c;
//Console.WriteLine(c3); //Számábrázolási hiba

int x = 5;
int y = 3;
double d = x / y;  // x / y --> egész osztás
Console.WriteLine(d);
d = x / (double)y; //típuskényszerítés (cast-olás)
Console.WriteLine(d);

Console.WriteLine(d.ToString()); //ToString() szöveggé alakít: változó.ToString()
Console.WriteLine(d.ToString("0.00")); //Pontosan 2 tizedesjeggyel szeretném megjeleníteni
double w = 12;
Console.WriteLine(w);
Console.WriteLine(w.ToString("0.00"));
Console.WriteLine(d.ToString("0.##")); //Maximum 2 tizedesjeggyel szeretném megjeleníteni
Console.WriteLine(w.ToString("0.##"));

