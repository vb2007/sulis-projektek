# Osztály diagram áttekintés

## Osztály hierarchia

```
┌─────────────────────────────────────┐
│         «enumeration»               │
│          LifeState                  │
├─────────────────────────────────────┤
│ Child                               │
│ Adult                               │
│ Elder                               │
└─────────────────────────────────────┘

┌─────────────────────────────────────┐
│         «interface»                 │
│           IAnimal                   │
├─────────────────────────────────────┤
│ + Name: string                      │
│ + Age: int                          │
│ + IsHealthy: bool                   │
│ + Hunger: int                       │
│ + Happiness: int                    │
│ + State: LifeState                  │
│ + TypeName: string                  │
│ + AsciiArt: string[]                │
├─────────────────────────────────────┤
│ + GetInteractions(): List<...>      │
└─────────────────────────────────────┘
                △
                │ implements
                │
┌───────────────┴─────────────────────┐
│         «abstract»                  │
│         AnimalBase                  │
├─────────────────────────────────────┤
│ + Name: string                      │
│ + Age: int                          │
│ + IsHealthy: bool                   │
│ + Hunger: int                       │
│ + Happiness: int                    │
│ + State: LifeState                  │
│ + TypeName: string {abstract}       │
│ + AsciiArt: string[] {abstract}     │
├─────────────────────────────────────┤
│ + GetInteractions() {abstract}      │
│ # ModifyHunger(IAnimal, int)        │
│ # ModifyHappiness(IAnimal, int)     │
└─────────────────────────────────────┘
                △
                │ extends
    ┌───────────┼───────────┐
    │           │           │
┌───┴───┐   ┌───┴────┐  ┌───┴───┐
│  Cat  │   │Goldfish│  │Monkey │
├───────┤   ├────────┤  ├───────┤
│...    │   │Aquarium│  │...    │
│       │   │Smashed │  │       │
└───────┘   └────────┘  └───────┘


┌─────────────────────────────────────┐
│           SaveData                  │
├─────────────────────────────────────┤
│ + Name: string {init}               │
│ + TypeName: string {init}           │
│ + Age: int {init}                   │
│ + IsHealthy: bool {init}            │
│ + Hunger: int {init}                │
│ + Happiness: int {init}             │
│ + State: LifeState {init}           │
│ + AquariumSmashed: bool             │
│ + CloseTime: DateTime {init}        │
├─────────────────────────────────────┤
│                                     │
└─────────────────────────────────────┘
```

## Kapcsolatok

### Öröklődés

- **AnimalBase** implementálja az **IAnimal** interface-t
- **Cat** örökli az **AnimalBase**-t
- **Goldfish** örökli az **AnimalBase**-t
- **Monkey** örökli az **AnimalBase**-t

### Függőségek

- Az **IAnimal** használja a **LifeState** enum-ot
- Az **AnimalBase** használja a **LifeState** enum-ot
- A **SaveData** használja a **LifeState** enum-ot
- Minden állat osztály függ az **IAnimal** interface-től az interakciókon keresztül

## UML jelmagyarázat

| Szimbólum | Jelentés |
|--------|---------|
| + | Public tag |
| - | Private tag |
| # | Protected tag |
| {abstract} | Abstract tag |
| {override} | Felülírt tag |
| {init} | Init-only property |
| <u>tag</u> | Static tag |
| △ | Öröklődés/Implementáció |

## Fájlok

- [IAnimal.md](./IAnimal.md) - Interface definíció
- [LifeState.md](./LifeState.md) - Enum definíció
- [AnimalBase.md](./AnimalBase.md) - Abstract alaposztály
- [Cat.md](./Cat.md) - Cat implementáció
- [Goldfish.md](./Goldfish.md) - Goldfish implementáció
- [Monkey.md](./Monkey.md) - Monkey implementáció
- [SaveData.md](./SaveData.md) - Mentési adatstruktúra
