# Cat Osztály

```
┌─────────────────────────────────────────────────────────┐
│                         Cat                             │
│                  extends AnimalBase                     │
├─────────────────────────────────────────────────────────┤
│ + TypeName: string = "Macska" {override}                │
│ + AsciiArt: string[] {override}                         │
├─────────────────────────────────────────────────────────┤
│ + GetInteractions(): List<(string, Action<IAnimal>)>    │
│   {override}                                            │
└─────────────────────────────────────────────────────────┘
```

## Tulajdonságok

| Láthatóság | Név | Típus | Érték | Leírás |
|------------|------|------|-------|-------------|
| + | TypeName | string | "Macska" | Magyar szó a "Cat"-re (override) |
| + | AsciiArt | string[] | [" /\\_/\\", " ( o.o )", " > ^ <"] | Macska ASCII art ábrázolás (override) |

## Metódusok

| Láthatóság | Név | Visszatérési típus | Leírás |
|------------|------|-------------|-------------|
| + | GetInteractions() | List<(string name, Action<IAnimal> action)> | Visszaadja a macska-specifikus interakciókat (override) |

## Interakciók

| Név | Hatás |
|------|--------|
| Simogatás (Pet) | +20 Boldogság, +3 Éhség |
| Szőr kefélése (Brush fur) | +10 Boldogság, IsHealthy = true |

## Jegyzetek

- Örökli az AnimalBase összes property-jét és metódusát
- Implementálja a macska-specifikus viselkedést és ASCII art-ot
