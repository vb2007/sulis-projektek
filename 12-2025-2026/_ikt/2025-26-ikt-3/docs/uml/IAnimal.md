# IAnimal Interfész

```
┌─────────────────────────────────────────────────────────┐
│                      «interface»                        │
│                        IAnimal                          │
├─────────────────────────────────────────────────────────┤
│ + Name: string                                          │
│ + Age: int                                              │
│ + IsHealthy: bool                                       │
│ + Hunger: int                                           │
│ + Happiness: int                                        │
│ + State: LifeState                                      │
│ + TypeName: string                                      │
│ + AsciiArt: string[]                                    │
├─────────────────────────────────────────────────────────┤
│ + GetInteractions(): List<(string, Action<IAnimal>)>    │
└─────────────────────────────────────────────────────────┘
```

## Tulajdonságok

| Láthatóság | Név | Típus | Leírás |
|------------|------|------|-------------|
| + | Name | string | Az állat neve |
| + | Age | int | Az állat életkora |
| + | IsHealthy | bool | Az állat egészségi állapota |
| + | Hunger | int | Éhségszint (0-100) |
| + | Happiness | int | Boldogságszint (0-100) |
| + | State | LifeState | Jelenlegi életállapot |
| + | TypeName | string | Az állat típusneve |
| + | AsciiArt | string[] | ASCII art reprezentáció |

## Metódusok

| Láthatóság | Név | Visszatérési típus | Leírás |
|------------|------|-------------|-------------|
| + | GetInteractions() | List<(string name, Action<IAnimal> action)> | Visszaadja az elérhető interakciókat az állattal |
