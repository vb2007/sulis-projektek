//Olvass be egy nap sorszámot és írd ki milyen nap van
Console.Write("Add meg egy nap sorszámát: ");
int napSorszam = int.Parse(Console.ReadLine()!);

switch (napSorszam)
{
    case 1:
        Console.WriteLine("Hétfő van.");
        break;
    case 2:
        Console.WriteLine("Kedd van.");
        break;
    case 3:
        Console.WriteLine("Szerda van.");
        break;
    case 4:
        Console.WriteLine("Csütörtök van.");
        break;
    case 5:
        Console.WriteLine("Péntek van.");
        break;
    case 6:
        Console.WriteLine("Szombat van.");
        break;
    case 7:
        Console.WriteLine("Vasárnap van.");
        break;
    default:
        Console.WriteLine("Érvénytelen sorszámot adtál meg!");
        break;
}

//Olvasd be egy napnak a nevét és írd ki, hogy hétköznapra esik-e, vagy hétvégére
Console.Write("Add meg egy nap nevét (csak kisbetűvel): ");
string napNev = Console.ReadLine()!;

switch (napNev)
{
    case "hétfő":
    case "kedd":
    case "szerda":
    case "csütörtök":
    case "péntek":
        Console.WriteLine("Ez egy hétköznapi nap.");
        break;
    case "szombat":
    case "vasárnap":
        Console.WriteLine("Ez egy hétvégi nap.");
        break;
    default:
        Console.WriteLine("Érvénytelen napot adtál meg.");
        break;
}

//Generálj egy random hőméréskletet, majd írd ki milyen az idő
Random random = new Random();
double homerseklet = random.NextDouble() * 60 - 20; //-20 és 40 közötti szám

Console.WriteLine($"A hőmérséklet: {homerseklet}");

switch (homerseklet)
{
    case < -10.0:
        Console.WriteLine("Nagyon hideg van.");
        break;
    case < -5.0:
        Console.WriteLine("Hideg van.");
        break;
    case > 30.0:
        Console.WriteLine("Nagyon meleg van.");
        break;
    case > 25.0:
        Console.WriteLine("Meleg van.");
        break;
    default:
        Console.WriteLine("Átlagos az hőmérséklet.");
        break;
}

//Switch Expression:
//Olvass be egy nap sorszámot és tárold el egy változóban milyen nap van
Console.Write("Add meg egy nap sorszámát: ");
int napSorszam2 = int.Parse(Console.ReadLine()!);

var napNev2 = napSorszam2 switch
{
    1 => "Hétfő",
    2 => "Kedd",
    3 => "Szerda",
    4 => "Csütörtök",
    5 => "Péntek",
    6 => "Szombat",
    7 => "Vasárnap",
    _ => "Ilyen nap nincs"
};

Console.WriteLine($"A nap neve: {napNev2}");

//x és y értékének meghatározása kordinátarendszerben
Random random2 = new Random();
int x = random2.Next(-1, 2);
int y = random2.Next(-1, 2);

Console.WriteLine($"Az x értéke: {x}");
Console.WriteLine($"Az y értéke: {y}");

var siknegyed = (x, y) switch
{
    { x: 0, y: 0 } => "origó", //x és y is 0
    { x: 0, y: _ } => "x tengely", //= az y nem 0-n van
    { x: _, y: 0 } => "y tengely", //= az x nem 0-n van
    { } when x > 0 && y > 0 => "1. síknegyed", //x és y nagyobb, mint 0
    { } when x < 0 && y > 0 => "2. síknegyed",
    { } when x < 0 && y < 0 => "3. síknegyed",
    { x: var xx, y: var yy } when xx > 0 && yy < 0 => "4. síknegyed",
    _ => "Ez az eset nem lehetséges."
};

Console.WriteLine($"A számok síknegyede: {siknegyed}");