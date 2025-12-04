# Végső Projekt Dokumentáció

## 1. Áttekintés

### Általános információk

- **Projekt neve**: Koboldüldözők
- **Projekt leírása**
  - A projekt egy társadalmi szimulációt valósít meg konzol alapú alkalmazásként.
  - Célja, hogy a valós életben is megjelenő problémákat (bevándorlás, demográfiai robbanás, bűnözés) vizuálisan és interaktívan közelebb hozza a felhasználókhoz.
  - A szimuláció realisztikusan mutatja be ezeket a társadalmi jelenségeket.

### Megvalósított funkciók

- Randomizált szimuláció minden indítás után különböző kezdőfeltételekkel
- **12x15**-ös rácsrendszer alapú vizualizáció
- Entitások közötti interakciók:
  - Koboldok házról-házra járása és szaporodása
  - Érmék gyűjtése és osztódás
  - Angyalok automatikus aktiválódása és üldöznek
  - Pathfinding (BFS) algoritmus a mozgáshoz
- Interaktív főmenü rendszer:
  - Sebesség beállítás (1-10 skála)
  - Manuális / automatikus mód
  - Részletes súgó menü
- Real-time statisztikák és aktivitási napló
- Színes vizuális megjelenítés ANSI escape code-okkal
- Teljes szimuláció végigjátszása automatikusan

## Szabályrendszer, modell

### Rácsrendszer működése

- A program egy **12x15**-ös rácsrendszerben szimulálja az eseményeket.
- A rácsrendszer és a random generált entitások a főmenü után, a szimuláció indításakor jelennek meg.
- A szimuláció frame-alapú, alapértelmezetten 1 másodperces frissítéssel (1-10 sebességfokozat választható).

### Entitások viselkedése

A szimulációban az alábbi objektumok jelennek meg:

- **Házak (H - szürke)**
  - 2 darab ház jelenik meg, egymástól minimum 4 négyzet távolságra.
  - Minden ház pontosan 2 négyzetet foglal el vízszintesen.
  - Statikus objektumok, nem mozognak.
- **Pásztorok (F - fehér)**
  - 4 darab pásztorként jelenik meg, 2-2 minden háznál.
  - Közvetlenül a házak melletti szabad négyzeteken spawolnak.
  - Passzív "dekorációs" entitások, nem vesznek részt aktívan a szimulációban.
- **Barna koboldok (K - barna)**
  - 4-8 darab kobold jelenik meg csoportosan.
  - A házaktól minimum 3 négyzet távolságra spawolnak.
  - George Droyd által inspirált algoritmus alapján cselekednek:
    - 4 vagy kevesebb koboldnál érmét keresnek
    - Nagyobb létszámnál rögtön házat keresnek
    - Együtt mozognak csoportként
    - Pathfinding algoritmussal navigálnak
  - Érmék gyűjtése után szaporodnak (2 érme = 2-4 új kobold).
  - Szomszédos házakat bitorolják sorban.
- **Zöld angyalok (A - zöld)**
  - Pontosan 2 darab angyal a mátrix bal felső sarkában.
  - Kezdetben inaktívak, csak megfigyelnek.
  - Amint koboldok házhoz érnek, megindulnak.
  - Pathfinding algoritmussal (BFS) üldözik a legközelebbi koboldot.
  - Szomszédos koboldokat megsemmisítik.
  - Frame-enként 1 koboldot tudnak eltávolítani.
- **Érmék ($ - arany)**
  - 4-6 darab érme spawol véletlenszerűen a térképen.
  - Koboldok felvehetik őket mozgás közben.
  - Felvétel után eltűnnek a rácsról.
  - 2 érme gyűjtése után a koboldok szaporodnak.

## Architektúra és technológia

### Projekt struktúra

- A projekt **.NET 9**-ben készült C# nyelven.
- Két fő komponensből áll:
  - **Kobolduldozok** - Console App (belépési pont)
  - **KobolduldozokLib** - Class Library (logika és UI)

### Implementált osztályok

A projekt végleges mappastruktúrája:

```
Kobolduldozok/
├─ Kobolduldozok/
│  ├─ Program.cs
├─ KobolduldozokLib/
│  ├─ SimulationSettings.cs
│  ├─ Entities/
│  │  ├─ IEntity.cs
│  │  ├─ Characters/
│  │  │  ├─ Angel.cs
│  │  │  ├─ Farmer.cs
│  │  │  ├─ Kobold.cs
│  │  ├─ Objects/
│  │  │  ├─ House.cs
│  │  │  ├─ Coin.cs
│  ├─ UI/
│  │  ├─ Renderer.cs
│  │  ├─ Menu/
│  │  │  ├─ MainMenu.cs
│  │  │  ├─ HelpMenu.cs
│  │  ├─ Simulation/
│  │  │  ├─ Matrix.cs
│  │  │  ├─ Statistics.cs
│  │  │  ├─ ActivityLog.cs
│  ├─ Helpers/
│  │  ├─ Position.cs
│  │  ├─ CustomColors.cs
```

## Összefoglalás

### Sikeres implementációk

- [x] Teljes OOP architektúra
- [x] Működő pathfinding BFS algoritmus
- [x] Színes, olvasható konzol megjelenítés
- [x] Frame-alapú szimuláció
- [x] Interaktív menürendszer
- [x] Real-time statisztikák és napló
- [x] Teljes véletlenszerű inicializálás
- [x] Hibamentes végigjátszás determinisztikus véggel
