# AnimalBase Abstract Osztály

```
┌─────────────────────────────────────────────────────────┐
│                   «abstract»                            │
│                    AnimalBase                           │
│                  implements IAnimal                     │
├─────────────────────────────────────────────────────────┤
│ + Name: string = string.Empty                           │
│ + Age: int                                              │
│ + IsHealthy: bool = true                                │
│ + Hunger: int                                           │
│ + Happiness: int = 50                                   │
│ + State: LifeState = LifeState.Child                    │
│ + TypeName: string {abstract}                           │
│ + AsciiArt: string[] {abstract}                         │
├─────────────────────────────────────────────────────────┤
│ + GetInteractions(): List<(string, Action<IAnimal>)>    │
│   {abstract}                                            │
│ # ModifyHunger(animal: IAnimal, amount: int): void      │
│ # ModifyHappiness(animal: IAnimal, amount: int): void   │
└─────────────────────────────────────────────────────────┘
```

## Tulajdonságok

| Láthatóság | Név | Típus | Alapértelmezett érték | Leírás |
|------------|------|------|---------------|-------------|
| + | Name | string | string.Empty | Az állat neve |
| + | Age | int | - | Az állat életkora |
| + | IsHealthy | bool | true | Az állat egészségi állapota |
| + | Hunger | int | - | Éhségszint (0-100) |
| + | Happiness | int | 50 | Boldogságszint (0-100) |
| + | State | LifeState | LifeState.Child | Jelenlegi életállapot |
| + | TypeName | string | - | Az állat típusneve (abstract) |
| + | AsciiArt | string[] | - | ASCII art reprezentáció (abstract) |

## Metódusok

| Láthatóság | Név | Paraméterek | Visszatérési típus | Leírás |
|------------|------|------------|-------------|-------------|
| + | GetInteractions() | - | List<(string name, Action<IAnimal> action)> | Visszaadja az elérhető interakciókat (abstract) |
| # | ModifyHunger() | animal: IAnimal, amount: int | void | Módosítja az éhségszintet korlátozással (0-100) |
| # | ModifyHappiness() | animal: IAnimal, amount: int | void | Módosítja a boldogságszintet korlátozással (0-100) |

## Jegyzetek

- Ez egy absztrakt alaposztály, amely implementálja az IAnimal interface-t
- Közös funkcionalitást biztosít minden állattípusnak
- Protected segédfüggvények az állat statisztikák módosítására határérték-ellenőrzéssel
