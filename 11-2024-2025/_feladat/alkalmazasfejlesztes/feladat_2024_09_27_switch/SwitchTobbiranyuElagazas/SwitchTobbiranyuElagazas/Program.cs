//1. Feladat
Console.Write("Add meg az érdemjegyet: ");
int erdemjegy = int.Parse(Console.ReadLine()!);

switch (erdemjegy)
{
    case 1:
        Console.WriteLine("Az érdemjegy: elégtelen");
        break;
    case 2:
        Console.WriteLine("Az érdemjegy: elégséges");
        break;
    case 3:
        Console.WriteLine("Az érdemjegy: közepes");
        break;
    case 4:
        Console.WriteLine("Az érdemjegy: jó");
        break;
    case 5:
        Console.WriteLine("Az érdemjegy: jeles");
        break;
    default:
        Console.WriteLine("Érvénytelen jegyet adtál meg.");
        break;
}

//2. feladat
Console.Write("Add meg egy hónap nevét szövegesen (kisbetűkkel): ");
string honap = Console.ReadLine()!;

switch (honap)
{
    case "január":
    case "február":
    case "március":
        Console.WriteLine("Ez hónap az év első negyedéhez tartozik.");
        break;
    case "április":
    case "május":
    case "június":
        Console.WriteLine("Ez hónap az év második negyedéhez tartozik.");
        break;
    case "július":
    case "augusztus":
    case "szeptember":
        Console.WriteLine("Ez hónap az év harmadik negyedéhez tartozik.");
        break;
    case "október":
    case "november:":
    case "december":
        Console.WriteLine("Ez hónap az év negyedik negyedéhez tartozik.");
        break;
    default:
        Console.WriteLine("Érvénytelen hónapot adtál meg.");
        break;
}

//3. feladat
Console.Write("Add meg egy hónap sorszámát: ");
int honapSorszam = int.Parse(Console.ReadLine()!);

switch (honapSorszam)
{
    case 1:
    case 2:
    case 3:
        Console.WriteLine("Ez hónap egy tavaszi évszakban van.");
        break;
    case 4:
    case 5:
    case 6:
        Console.WriteLine("Ez hónap egy nyári évszakban van.");
        break;
    case 7:
    case 8:
    case 9:
        Console.WriteLine("Ez hónap egy őszi évszakban van.");
        break;
    case 10:
    case 11:
    case 12:
        Console.WriteLine("Ez hónap egy téli évszakban van.");
        break;
    default:
        Console.WriteLine("Érvénytelen hónapot adtál meg.");
        break;
}

//4. feladat
Console.Write("Add meg átlagosan hány órát alszol naponta: ");
int atlagAlvasiOrak = int.Parse(Console.ReadLine()!);

switch (atlagAlvasiOrak)
{
    case <= 6:
        Console.WriteLine("Keveset alszol.");
        break;
    case <= 9:
        Console.WriteLine("Átlagos (megfelelő) órát alszol.");
        break;
    case <= 12:
        Console.WriteLine("Solat alszol");
        break;
    case <= 24:
        Console.WriteLine("Nagyon sokat alszol.");
        break;
    default:
        Console.WriteLine("Érvénytelen értéket adtál meg (vagy 24 óránál többet alszol).");
        break;
}

//5. feladat
Console.Write("Add meg a szeptemberi nap sorszámát: ");
int szeptemberiNapSorszama = int.Parse(Console.ReadLine()!);

switch (szeptemberiNapSorszama)
{
    case 1:
    case 8:
    case 15:
    case 22:
    case 29:
        Console.WriteLine("A 2024-es évben ez a nap szeptemberben egy Vasárnap.");
        break;
    case 2:
    case 9:
    case 16:
    case 23:
    case 30:
        Console.WriteLine("A 2024-es évben ez a nap szeptemberben egy Hétfő.");
        break;
    case 3:
    case 10:
    case 17:
    case 24:
        Console.WriteLine("A 2024-es évben ez a nap szeptemberben egy Kedd.");
        break;
    case 4:
    case 11:
    case 18:
    case 25:
        Console.WriteLine("A 2024-es évben ez a nap szeptemberben egy Szerda.");
        break;
    case 5:
    case 12:
    case 19:
    case 26:
        Console.WriteLine("A 2024-es évben ez a nap szeptemberben egy Csütörtök.");
        break;
    case 6:
    case 13:
    case 20:
    case 27:
        Console.WriteLine("A 2024-es évben ez a nap szeptemberben egy Péntek.");
        break;
    case 7:
    case 14:
    case 21:
    case 28:
        Console.WriteLine("A 2024-es évben ez a nap szeptemberben egy Szombat.");
        break;
    default:
        Console.WriteLine("Érvénytelen napot adtál meg.");
        break;
}