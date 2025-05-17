# Interfészek .NET C#-ban: Bevezetés kezdőknek

Ebben a bemutatóban megismerkedünk az interfészek fogalmával és használatával .NET C#-ban. Az interfészek az objektumorientált programozás egyik alapvető eszközei, amelyek segítenek rugalmasabb, karbantarthatóbb és tesztelhetőbb kódot írni.

## 1. Mi az az interfész?

Képzeld el az interfészt egy szerződésként vagy egy szabályrendszerként. Amikor egy osztály "aláírja" ezt a szerződést (azaz implementálja az interfészt), akkor vállalja, hogy betartja az abban lefektetett szabályokat. Ezek a szabályok általában azt határozzák meg, hogy az osztálynak milyen metódusokkal és tulajdonságokkal kell rendelkeznie.

### Főbb jellemzők:

- Absztrakciót biztosít: Meghatározza, mit kell tudnia egy osztálynak, de nem azt, hogy hogyan valósítja meg. Az interfész csak a "mit" kérdésre válaszol.
- Nem példányosítható: Közvetlenül nem hozhatsz létre példányt egy interfészből (`new ITerulet()` nem lehetséges).
- Tagjai alapértelmezetten publikusak: Az interfészben definiált metódusoknak és tulajdonságoknak nincs szükségük explicit public kulcsszóra. Maga az interfész láthatósága (pl. - `internal` vagy `public`) természetesen beállítható.

## 2. Miért használjunk interfészeket?

- **Egységes működés:** Különböző osztályok implementálhatják ugyanazt az interfészt, így garantálva, hogy mindegyik rendelkezik a szerződésben meghatározott funkcionalitással.
- **Polimorfizmus:** Lehetővé teszi, hogy különböző típusú objektumokat egységesen kezeljünk az interfész típusán keresztül. (Lásd később a `List<ITerulet>` példát!)
- **Lazább csatolás:** Csökkenti az osztályok közötti közvetlen függőségeket, ami könnyebben módosítható és bővíthető kódot eredményez.
- **Tesztelhetőség:** Könnyebb "ál" (mock) objektumokat létrehozni teszteléshez, amelyek ugyanazt az interfészt valósítják meg.

## 3. Interfész létrehozása C#-ban

### Nézzük meg a példaprogramunk `ITerulet.cs` fájlját:

```cs
namespace Interface_PL
{
    internal interface ITerulet
    {
        double Terulet { get; }
    }
}

//...

namespace Interface_PL // A példaprogram alapján
{
    internal interface ITerulet // Csak a projekten belül elérhető
    {
        // Elvárjuk, hogy legyen egy 'Terulet' nevű, 'double' típusú,
        // lekérdezhető (get) tulajdonsága.
        double Terulet { get; }
    }
}
```

### Szintaxis és konvenciók:

1. ***interface*** kulcsszó: Ezzel jelezzük, hogy egy interfészt definiálunk.

2. Elnevezés: Konvenció szerint az interfészek nevét nagy `I` betűvel kezdjük (pl. `ITerulet`, `IComparable`). Ez segít gyorsan azonosítani, hogy egy típusról vagy interfészről van-e szó.

3. Láthatóság:

- Az interfész maga lehet public (bárhonnan elérhető) vagy internal (csak az adott projektből/assembly-ből elérhető). A példában internal.
- Az interfészen belüli tagok (metódusok, property-k) láthatóságát nem kell (és általában nem is lehet) megadni, azok implicit módon publikusak az interfészt implementáló osztály számára.

4. Tagok definiálása:

- Tulajdonságok: Csak az aláírást adjuk meg. Megadhatjuk, hogy legyen get (lekérdezhető) és/vagy set (beállítható) hozzáférője.
  - A példánkban az `ITerulet` interfész egy Terulet nevű, double típusú, csak olvasható (csak get) tulajdonságot ír elő: `double Terulet { get; }`.
  - Az interfész nem foglalkozik azzal, hogy a Terulet tulajdonság egy konkrét adatmezőből származik-e, vagy egy számított érték. Ezt az implementáló osztály dönti el. Az interfész csak azt követeli meg, hogy legyen egy ilyen lekérdezhető tulajdonság.

- Metódusok: Csak a metódus-aláírást adjuk meg (visszatérési típus, név, paraméterek), a törzsét (implementációját) nem.

## 4. Interfész implementálása egy osztályban

Ha egy osztály meg akar felelni egy interfész által támasztott "szerződésnek", akkor implementálnia kell azt. Ezt a kettőspont (`:`) jelöléssel tesszük az osztály neve után.

Nézzük a `Telek.cs` osztályunkat, amely implementálja az ITerulet interfészt:

```cs
namespace Interface_PL
{
    internal class Telek : IComparable<Telek>, ITerulet
    {
        // ...
        public double Szelesseg { /* ... */ }
        public double Hosszusag { /* ... */ }

        public double Terulet => Szelesseg * Hosszusag; // ITerulet implementációja
        // ...
    }
}

//...

namespace Interface_PL // A példaprogram alapján
{
    internal class Telek : IComparable<Telek>, ITerulet // Itt implementáljuk az ITerulet interfészt (és az IComparable-t is)
    {
        // ... egyéb osztálytagok (ID, Szelesseg, Hosszusag, konstruktor stb.) ...

        // Az ITerulet interfész által megkövetelt Terulet tulajdonság implementációja
        // Ez egy számított tulajdonság, ami a Szelesseg és Hosszusag szorzatát adja vissza.
        public double Terulet => Szelesseg * Hosszusag;

        // ... (CompareTo, ToString stb. implementációja)
        // A példában a Szelesseg és Hosszusag property-k saját logikával rendelkeznek,
        // ami RosszMeretException-t dobhat.
        static int IdSzamlalo = 0;
        public int ID { get; }

        private double szelesseg;
        public double Szelesseg
        {
            get { return szelesseg; }
            set
            {
                if (value > 0) { szelesseg = value; }
                else { throw new RosszMeretException($"szélesség ({value})"); }
            }
        }

        private double hosszusag;
        public double Hosszusag
        {
            get { return hosszusag; }
            set
            {
                if (value > 0) { hosszusag = value; }
                else { throw new RosszMeretException($"hosszúság ({value})"); }
            }
        }

        public int CompareTo(Telek? other)
        {
            if (other == null) return 1;
            return Terulet.CompareTo(other.Terulet);
        }

        public Telek(double szelesseg, double hosszusag)
        {
            IdSzamlalo++;
            ID = IdSzamlalo;
            Szelesseg = szelesseg; // Itt dobódhat a RosszMeretException
            Hosszusag = hosszusag; // Itt is dobódhat a RosszMeretException
        }

        public override string ToString()
        {
            return $"{ID}: {Szelesseg}*{Hosszusag}={Terulet}";
        }
    }
}
```

### Fontos tudnivalók az implementációról:

- Minden tag implementálása kötelező: Az osztálynak minden, az interfészben definiált tagot (tulajdonságot, metódust) implementálnia kell. Ha valamit kihagysz, a kód nem fog fordulni.
- IDE segítsége: A legtöbb fejlesztőkörnyezet (pl. Visual Studio) segít az interfészek implementálásában. Jobb klikk az interfész nevén az osztálydefinícióban, és az "Implement Interface" (vagy hasonló) opció általában legenerálja a szükséges vázakat (ahogy az átiratban is említve van, egy NotImplementedException-nel).
- public láthatóság: Az interfész tagjainak implementációja az osztályban public kell, hogy legyen (mivel az interfész tagjai implicit módon publikusak az azt implementáló osztály felé).
- Több interfész implementálása: Egy osztály több interfészt is implementálhat. Ezeket vesszővel elválasztva soroljuk fel:

```cs
class PeldaOsztaly : IElsoInterfesz, IMasikInterfesz
{
    // ... IElsoInterfesz tagjainak implementációja ...
    // ... IMasikInterfesz tagjainak implementációja ...
}
```

A Telek osztály a példaprogramban az `IComparable<Telek>` interfészt is implementálja az ITerulet mellett. Egy osztálynak csak egy ősosztálya lehet, de akárhány interfészt megvalósíthat.

## 5. Példa: Az IComparable<T> interfész és a rendezés

A `.NET` számos beépített interfészt tartalmaz. Az egyik nagyon hasznos az `IComparable<T>`. Ha egy osztály implementálja ezt az interfészt, akkor az osztály példányai összehasonlíthatóvá válnak egymással. Ez lehetővé teszi például listák egyszerű rendezését a `List<T>.Sort()` metódussal.

Az `IComparable<T>` egyetlen metódust ír elő: `CompareTo(T other)`.

```cs
// Telek.cs (részlet az IComparable<Telek> implementációjáról)
public int CompareTo(Telek? other) // A '?' jelzi, hogy 'other' lehet null
{
    if (other == null) return 1; // Konvenció: a null-nál "nagyobb"-nak tekintjük magunkat.
                                 // Ha 'this' lenne null (ami itt nem fordulhat elő, mert példánymetódus),
                                 // akkor más lenne a helyzet.
    // Terület alapján hasonlítunk.
    // A double típusnak van saját CompareTo metódusa.
    return Terulet.CompareTo(other.Terulet);
}
```

A `CompareTo` metódus működése:

- Ha az aktuális példány `(this)` kisebb, mint az other paraméter, `-1`-et ad vissza.
- Ha az aktuális példány `(this)` egyenlő az other paraméterrel, `0`-t ad vissza.
- Ha az aktuális példány `(this)` nagyobb, mint az other paraméter, `1`-et ad vissza.

A `Telek` osztályban a telkeket a `Teruletük` alapján hasonlítjuk össze.

A `Program.cs`-ben láthatod, hogyan használjuk ezt:

```cs
// Program.cs (részlet)
List<Telek> telkek = new();
// ... telkek feltöltése (esetleges hibákkal) ...
telkek.Sort(); // Itt hívódik meg a Telek.CompareTo metódusa minden elempáron a rendezéshez
Console.WriteLine("Telkek:");
foreach (var item in telkek)
{
    Console.WriteLine(item); // Kiírja a rendezett telkeket
}
```

A `Sort()` metódus automatikusan a CompareTo implementációt használja a telkek rendezéséhez (a példában terület szerint növekvő sorrendbe).

## 6. Interfészek a gyakorlatban: Polimorfizmus

Az interfészek egyik legnagyobb ereje a polimorfizmus (többalakúság) lehetővé tétele. Ez azt jelenti, hogy létrehozhatsz egy interfész típusú változót vagy gyűjteményt, és abban tárolhatsz bármilyen olyan osztálypéldányt, amely implementálja az adott interfészt.

Nézzük a `Program.cs` utolsó sorait:

```cs
// Program.cs (részlet)
ITerulet valami = new Telek(10, 20); // 'valami' ITerulet típusú, de Telek objektumot tartalmaz
List<ITerulet> teruletek = new List<ITerulet>();
teruletek.Add(valami);
// Bármilyen más osztály példányát is hozzáadhatnánk, ami implementálja az ITerulet-et:
// teruletek.Add(new Kor(...)); // Feltéve, hogy van Kor osztály, ami ITerulet-et implementál
Console.WriteLine(teruletek[0]); // Működik, mert a Telek.ToString() hívódik meg (az Object.ToString() felülírása miatt)
Console.WriteLine(teruletek[0].Terulet); // Működik, mert az ITerulet garantálja a Terulet tulajdonságot
```

Itt a `teruletek` lista `ITerulet` típusú elemeket tárol. Belerakhatunk `Telek` objektumot, vagy bármilyen más objektumot, ami implementálja az `ITerulet` interfészt. A lista minden eleméről tudjuk, hogy biztosan rendelkezik egy `Terulet` tulajdonsággal, mert ezt az `ITerulet` szerződés garantálja. Csak az `ITerulet` interfészben definiált tagokat érhetjük el közvetlenül a `teruletek[0]` változón keresztül (pl. `teruletek[0].ID` nem lenne elérhető típuskonverzió nélkül, mert az ID nem része az `ITerulet`-nek).

Ez rendkívül hasznos, amikor különböző, de valamilyen szempontból hasonló funkcionalitású objektumokat szeretnénk egységesen kezelni.

## 7. Kapcsolódó téma: Saját kivételkezelés

Bár nem közvetlenül az interfészekhez kapcsolódik, a példaprogram bemutatja, hogyan hozhatunk létre saját kivételosztályokat. Ez jó gyakorlat, ha specifikus hibaállapotokat szeretnénk jelezni.

A `RosszMeretException.cs`-ben definiálunk egy saját kivételt:

```cs
namespace Interface_PL
{
    internal class RosszMeretException : Exception
    {
        public RosszMeretException(string mezo = null)
            : base($"A megadott {mezo} nem pozitív")
        {
        }
    }
}

//...

namespace Interface_PL // A példaprogram alapján
{
    internal class RosszMeretException : Exception // Öröklődés az alap Exception osztályból
    {
        // Konstruktor, ami egy opcionális 'mezo' paramétert vár
        // és továbbítja az ősosztály (Exception) konstruktorának a hibaüzenetet.
        public RosszMeretException(string mezo = null) // 'mezo = null' alapértelmezett értéket ad
            : base($"A megadott {mezo} nem pozitív")
        {
            // Nincs szükség itt további logikára
        }
    }
}
```

Ezt a kivételt a `Telek` osztály `Szelesseg` és `Hosszusag` tulajdonságainak `set` ágában (és így a konstruktorban is) dobjuk meg, ha érvénytelen (nem pozitív) értéket próbálnak beállítani.

A `Program.cs`-ben pedig egy `try-catch` blokkban kezeljük ezt a specifikus kivételt:

```cs
// Program.cs (részlet a telek létrehozásáról)
for (int i = 0; i < 10; i++)
{
    int szelesseg = Random.Shared.Next(-3, 10);
    int hosszusag = Random.Shared.Next(-3, 10);
    try
    {
        telkek.Add(new Telek(szelesseg, hosszusag)); // Itt dobódhat RosszMeretException
    }
    catch (RosszMeretException ex) // Először a specifikus kivételt kapjuk el
    {
        hiba.Add($"{ex.Message}"); // A kivétel üzenetét adjuk a hibalistához
    }
    catch // Ha más, váratlan hiba történik
    {
        hiba.Add("Váratlan hiba történt.");
    }
}
```

Először mindig a legspecifikusabb kivételt próbáljuk elkapni (`RosszMeretException`), majd utána lehet általánosabbakat (pl. `Exception` vagy csak `catch`).

## 8. Összefoglalás

Az interfészek:

- **Szerződések**, amelyek meghatározzák, milyen tagokkal (tulajdonságokkal, metódusokkal) kell rendelkeznie egy osztálynak.
- Lehetővé teszik **absztraktabb**, **általánosabb kód** írását azáltal, hogy a "mit" kérdésre fókuszálnak, nem a "hogyan"-ra.
- Támogatják a **polimorfizmust**, ami rugalmasságot ad: különböző osztályok példányai kezelhetők egységesen az interfész típusán keresztül.
- Segítenek a **lazább csatolás** elérésében az osztályok között, ami karbantarthatóbbá teszi a kódot.
- Nélkülözhetetlenek nagyobb, komplexebb rendszerek fejlesztésénél a komponensek közötti tiszta határok definiálásához.

Kezdetben talán kicsit elvontnak tűnhet a koncepció, de minél többet használod őket, annál világosabbá válnak az előnyeik. A példaprogram (`ITerulet`, `IComparable<T>`) és a kapcsolódó `Telek` osztály jó kiindulási pont a gyakorláshoz!