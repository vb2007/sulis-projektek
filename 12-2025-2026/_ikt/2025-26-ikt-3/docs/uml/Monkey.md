# Monkey Osztály

```
┌─────────────────────────────────────────────────────────┐
│                        Monkey                           │
│                  extends AnimalBase                     │
├─────────────────────────────────────────────────────────┤
│ + TypeName: string = "Majom" {override}                 │
│ + AsciiArt: string[] {override}                         │
├─────────────────────────────────────────────────────────┤
│ + GetInteractions(): List<(string, Action<IAnimal>)>    │
│   {override}                                            │
└─────────────────────────────────────────────────────────┘
```

## Tulajdonságok

| Láthatóság | Név | Típus | Érték | Leírás |
|------------|------|------|-------|-------------|
| + | TypeName | string | "Majom" | Magyar szó a "Monkey"-ra (override) |
| + | AsciiArt | string[] | ["/~\\", "C oo", "_( ^)", "/   ~\\"] | Majom ASCII art ábrázolás (override) |

## Metódusok

| Láthatóság | Név | Visszatérési típus | Leírás |
|------------|------|-------------|-------------|
| + | GetInteractions() | List<(string name, Action<IAnimal> action)> | Visszaadja a majom-specifikus interakciókat (override) |

## Interakciók

| Név | Hatás |
|------|--------|
| Etetés (banán) (Feed banana) | -25 Éhség, +5 Boldogság |
| Barátkozás (Make friends) | +20 Boldogság, +5 Éhség |

## Jegyzetek

- Örökli az AnimalBase összes property-jét és metódusát
- Implementálja a majom-specifikus viselkedést és ASCII art-ot
- Az etetés csökkenti az éhséget, míg a barátkozás növeli
