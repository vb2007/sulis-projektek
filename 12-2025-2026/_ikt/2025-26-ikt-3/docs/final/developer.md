# ByteFriend - Fejlesztői Dokumentáció

## Projekt Áttekintés

A **ByteFriend** egy virtuális kisállat-gondozó szimulátor (Tamagotchi-szerű), .NET 10-ben C# nyelven írva. A játék valós idő alapú rendszert használ - az állatok állapota változik még offline módban is.

### Főbb Jellemzők

- 3 állattípus: **Macska**, **Aranyhal**, **Majom**
- JSON alapú mentés/betöltés rendszer
- Valós idő szimuláció (offline öregedés és állapotváltozás)
- 3 életszakasz: Gyerek (0-24h), Felnőtt (24-72h), Idős (72-120h)
- Random események: betegség, éhséghullám
- ASCII art grafika
- Maximum 10 állat kezelése egyidejűleg

## Projekt Struktúra

```
ByteFriend/
├── ByteFriend/                    # Console app (entry point)
│   └── Program.cs                 # Main()
└── ByteFriend_Lib/                # Class Library (logika)
    ├── Entities/                  # Entitások
    │   ├── IAnimal.cs             # Állat interfész
    │   ├── AnimalBase.cs          # Absztrakt alaposztály
    │   ├── LifeState.cs           # Enum: Child, Adult, Elder
    │   ├── SaveData.cs            # Mentési DTO
    │   └── Animals/               # Cat.cs, Goldfish.cs, Monkey.cs
    ├── Helpers/                   # Segédosztályok
    │   ├── AnimalFactory.cs       # Állat gyártás/konverzió
    │   ├── SaveManager.cs         # Mentés kezelés (JSON)
    │   ├── TimeManager.cs         # Időkezelés, öregedés
    │   ├── RandomEventManager.cs  # Véletlenszerű események
    │   └── CustomColors.cs        # ANSI színezés
    └── UI/                        # UI komponensek
        ├── Render.cs              # Renderelés
        └── Menu/                  # Menük (MainMenu, LoadMenu, stb.)
```

## Architektúra

### Osztályhierarchia

```
IAnimal (interface)
    ↓
AnimalBase (abstract)
    ↓
Cat | Goldfish | Monkey
```

### IAnimal Interface

Minden állat alapvető tulajdonságai:
- `Name`, `Age`, `IsHealthy`, `Hunger`, `Happiness`, `State`, `TypeName`, `AsciiArt`
- `GetInteractions()` - elérhető interakciók listája

### AnimalBase Abstract Class

Közös funkcionalitás:
- Protected metódusok: `ModifyHunger()`, `ModifyHappiness()` - 0-100 klampelés
- Abstract tagok: `TypeName`, `AsciiArt`, `GetInteractions()` - felüldefiniálandók

### Állatok és Interakcióik

- **Cat**: Simogatás, Szőr kefélése
- **Monkey**: Banánnal etetés, Barátkozás
- **Goldfish**: Akvárium takarítása, Akvárium földhöz vágása (instant halál)

## Fontosabb eseményeket kezelő osztályok

### 1. TimeManager

Időkezelés és öregedés logika.

**Konstansok:**
- `HungerPerHour = 5`, `HappinessLossPerHour = 3`
- Életszakaszok: Child (0-24h), Adult (24-72h), Elder (72-120h)
- `ElderMaxAge = 120` - természetes halál

**Metódusok:**
- `ApplyElapsedTime(animal, closeTime)` - offline idő alkalmazása betöltéskor
- `Tick(animal)` - játékciklus frissítés (éhség+2, boldogság-1, kor+1)
- `UpdateLifeState()` - életállapot frissítése kor alapján
- `IsNaturalDeath()` - idős kor halál (Age >= 120)
- `IsStarvationDeath()` - éhhalál (Hunger >= 100)

### 2. SaveManager

JSON alapú perzisztencia kezelés.

**Mentési könyvtár:** `./Saves/` (automatikus létrehozás)

**Metódusok:**
- `Save(IAnimal)` - állat mentése JSON-ba
- `Load(string name)` - betöltés név alapján
- `IsNameTaken(string)` - név foglaltság
- `GetAllSaves()` - mentések listája
- `Delete(string)`, `Rename(old, new)` - kezelés
- `GetSaveCount()` - max 10 ellenőrzés

### 3. RandomEventManager

Véletlenszerű események generálása.

**Események:**
- Betegség: 15% esély (`IsHealthy = false`)
- Éhséghullám: 20% esély (+10-25 éhség)

**Metódus:** `ProcessRandomEvent(IAnimal)` - esemény végrehajtás, visszatérés: üzenet vagy null

### 4. AnimalFactory

Állat létrehozása, kezelése.

- `CreateAnimal(typeName, name)` - új állat típus alapján
- `ToSaveData(IAnimal)` - állat → SaveData
- `FromSaveData(SaveData)` - SaveData → állat

## Játékfolyamat

### Új Játék

1. MainMenu → Új állat → AnimalPickerMenu
2. Típus választás (Cat/Goldfish/Monkey)
3. Név megadás + `IsNameTaken()` ellenőrzés
4. `AnimalFactory.CreateAnimal()` → Interactions.Show()

### Betöltés

1. LoadMenu → `GetAllSaves()` listázás
2. Választás → `Load(name)`
3. `ApplyElapsedTime()` - offline idő számítás
4. Interactions.Show()

### Játékciklus (Interactions.Show)

1. Képernyő újrarajzolás (név, kor, állapot, ASCII art, mérők)
2. Interakciós opciók megjelenítése
3. Felhasználói input
4. `TimeManager.Tick()` - idő léptetés
5. `RandomEventManager.ProcessRandomEvent()`
6. Halál ellenőrzések
7. `SaveManager.Save()` - automatikus mentés

### Halál

1. DeathScreen.Show() - statisztikák
2. `SaveManager.Delete()` - mentés törlés
3. Főmenü

## Renderelési Rendszer

**Render osztály (statikus):**
- `ClearScreen()` - képernyő törlés
- `WriteLineCenter(text)` - központozott kiírás
- `WriteAt(left, top, text)` - pozicionált kiírás
- `BuildStatBar(label, value, max, colors)` - színezett mérő
- `StripAnsiCodes()` - ANSI kódok eltávolítása

**CustomColors:** ANSI escape kódokkal színezés

## Fejlesztési Útmutató

### Új Állat Hozzáadása
1. Új osztály létrehozása `Animals/` mappában
2. Öröklés: `AnimalBase`
3. Implementálás: `TypeName`, `AsciiArt`, `GetInteractions()`
4. `AnimalFactory` frissítése
5. `AnimalPickerMenu` bővítése

### Interakció Formátum

```csharp
("Interakció neve", a => {
    ModifyHappiness(a, 10);
    ModifyHunger(a, -5);
})
```

## Összefoglalás

A ByteFriend egy moduláris, OOP elveket követő projekt (öröklődés, absztrakció, polimorfizmus). Új fejlesztőknek ajánlott út:
1. **Játékmenet megértése:** Program.cs → MainMenu → Interactions
2. **Entitás hierarchia:** IAnimal → AnimalBase → konkrét állatok
3. **Időkezelés tanulmányozása:** TimeManager működése
4. **Perzisztencia:** SaveManager és SaveData struktúra
