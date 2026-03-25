# Goldfish Osztály

```
┌─────────────────────────────────────────────────────────┐
│                      Goldfish                           │
│                  extends AnimalBase                     │
├─────────────────────────────────────────────────────────┤
│ + AquariumSmashed: bool                                 │
│ + TypeName: string = "Aranyhal" {override}              │
│ + AsciiArt: string[] {override}                         │
├─────────────────────────────────────────────────────────┤
│ + GetInteractions(): List<(string, Action<IAnimal>)>    │
│   {override}                                            │
└─────────────────────────────────────────────────────────┘
```

## Tulajdonságok

| Láthatóság | Név | Típus | Érték | Leírás |
|------------|------|------|-------|-------------|
| + | AquariumSmashed | bool | - | Jelzi, hogy az akvárium össze lett-e törve |
| + | TypeName | string | "Aranyhal" | Magyar szó a "Goldfish"-re (override) |
| + | AsciiArt | string[] | [";,//;,    ,;/", "o:::::::;;///", ">::::::::;;\\\\\\", "''\\\\\\\\\\\\'" ';\"] | Aranyhal ASCII art ábrázolás (override) |

## Metódusok

| Láthatóság | Név | Visszatérési típus | Leírás |
|------------|------|-------------|-------------|
| + | GetInteractions() | List<(string name, Action<IAnimal> action)> | Visszaadja az aranyhal-specifikus interakciókat (override) |

## Interakciók

| Név | Hatás |
|------|--------|
| Akvárium takarítása (Clean aquarium) | +15 Boldogság, +3 Éhség |
| Akvárium földhöz vágása (Smash aquarium) | AquariumSmashed = true |

## Jegyzetek

- Örökli az AnimalBase összes property-jét és metódusát
- További property-je az `AquariumSmashed`, amely aranyhal-specifikus
- Implementálja az aranyhal-specifikus viselkedést és ASCII art-ot
