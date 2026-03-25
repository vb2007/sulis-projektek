# SaveData Osztály

```
┌─────────────────────────────────────────────────────────┐
│                       SaveData                          │
├─────────────────────────────────────────────────────────┤
│ + Name: string = string.Empty {init}                    │
│ + TypeName: string = string.Empty {init}                │
│ + Age: int {init}                                       │
│ + IsHealthy: bool = true {init}                         │
│ + Hunger: int {init}                                    │
│ + Happiness: int = 50 {init}                            │
│ + State: LifeState = LifeState.Child {init}             │
│ + AquariumSmashed: bool                                 │
│ + CloseTime: DateTime = DateTime.UtcNow {init}          │
├─────────────────────────────────────────────────────────┤
│                                                         │
└─────────────────────────────────────────────────────────┘
```

## Tulajdonságok

| Láthatóság | Név | Típus | Alapértelmezett érték | Hozzáférés | Leírás |
|------------|------|------|---------------|--------|-------------|
| + | Name | string | string.Empty | init | A mentett állat neve |
| + | TypeName | string | string.Empty | init | A mentett állat típusneve |
| + | Age | int | - | init | A mentett állat életkora |
| + | IsHealthy | bool | true | init | A mentett állat egészségi állapota |
| + | Hunger | int | - | init | Éhségszint (0-100) |
| + | Happiness | int | 50 | init | Boldogságszint (0-100) |
| + | State | LifeState | LifeState.Child | init | A mentett állat életállapota |
| + | AquariumSmashed | bool | - | get/set | Aranyhal-specifikus property |
| + | CloseTime | DateTime | DateTime.UtcNow | init | A játék bezárásának időpontja |

## Metódusok

Ez az osztály nem tartalmaz metódusokat.

## Jegyzetek

- Ez egy adatátviteli objektum (DTO), amelyet szerializációra/deszerializációra használunk
- A legtöbb property `init` accessor-t használ, így az objektum létrehozása után megváltoztathatatlanok
- Az `AquariumSmashed` az egyetlen property szabványos getter/setter-rel
- Az állat állapotának lemezre mentésére szolgál
