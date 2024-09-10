Console.Write("Kérem adjon meg egy egész számot: ");

//egész típusú változó deklarálása
int x;
x = int.Parse(Console.ReadLine()); //újtípus.Parse(string típusú változó)
                                   // Convert.ToInt32(változó)

Console.Write("Kérem adjon meg egy másik egész számot: ");
int y = Convert.ToInt32(Console.ReadLine());

//Matematikai (aritmetikai) műveletek
int z = x + y; //Összeadás
Console.WriteLine($"Összeadás:\t{x}+{y}={z}");
z = x - y; //Kivonás 
Console.WriteLine($"Kivonás:\t{x}-{y}={x - y}");
z = x * y; //Szorzás
Console.WriteLine($"Szorzás:\t{x}*{y}={z}");
z = x / y; //Egész osztás
Console.WriteLine($"Osztás:\t{x}/{y}={z}");

//Osztási szabály
// Ha int/int --> int Pl.: 11/4=2
// Ha int/double --> double
// Ha double/int --> double
// Ha double/double --> double

z = x % y; //Az x-et y-nal osztva mennyi a maradék
Console.WriteLine($"Maradék:\t{x} érték {y} értékkel osztva {z} maradékot ad.");

Console.WriteLine($"x értéke: {x}");
x++; //Érték növelés 1-gyel, először a változó értéke átadódik a kifejezésnek, és csak utána növelődik meg az értéke
Console.WriteLine($"x értéke: {x}");
x--; // Érték csökkentés 1-gyel, először a változó értéke átadódik a kifejezésnek, és csak utána csökken az értéke
Console.WriteLine($"x értéke: {x}");
++x; //Először éték növelés, aztán adódik át a kifejezésnek
Console.WriteLine($"x értéke: {x}");
--x; //Először érték csökkenés, aztán adódik át a kifejezésnek
Console.WriteLine($"x értéke: {x}");

Console.WriteLine();
z = 6;
Console.WriteLine($"z értéke: {z}");
Console.WriteLine($"x értéke: {x}");
z = x++;
Console.WriteLine($"z értéke: {z}");
Console.WriteLine($"x értéke: {x}");
z = ++x;
Console.WriteLine($"z értéke: {z}");
Console.WriteLine($"x értéke: {x}");

