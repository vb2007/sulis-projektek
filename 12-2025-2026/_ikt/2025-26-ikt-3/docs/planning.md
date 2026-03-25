# 2025-26-ikt-3 - Tervezés

Projekt / játék neve: ByteFriend

## Koncepció

A retro Tamagotci játék eredeti konepciójához hasonlóan, a mi játékunkban is egy tetszőlegesen választott virtuális barátot gondozhatsz.

Lehetséges - valós időhöz releváns - funkciók:

- Etetés
- Gyógyítás
- Fejlődés (3 szakasz):
  - Gyerek
  - Felnőtt
  - Idős

Idős állapot elérése után egy rövid időszakaszt még él az entitás, majd természetes módon - felhasználói behatás nélkül - elveszti életét.

## Technikai oldal

- Egy solution-ön belül szokás szerint 2 projektünk lesz:
  - Console App
  - Class Library
- .NET 10-et fogunk használni

### Class & Interface lista

```
ClassLib
  ->IAllat.cs
    ->Majom.cs
    ->Aranyhal.cs
    ->Macska.cs
```

### Funkciók

- Állapot mentése és betöltése JSON fájlok használatával
- Relativitás a valós rendszeridőhöz
  - Mentések között valóban telik az idő
- Ablakméret alapján reszponzívan renderelés
- Díszítés ASCII art-ok segítségével
- Framekem alapuló renderelés

## Játékmenet

A felhasználó a főmenüben kiválaszthat egy állatot 3 lehetséges opció közül:

- Majom
  - Etetés (banánnal)
  - Barátkozás
- Aranyhal
  - Akvárium takarítása
  - Akvárium földhöz baszása (instant endeli a gamet)
- Macska
  - Simogatás
  - Szőrének kefélése

### Univerzális random események

- Az alábbiak minden állattípusra érvényesek.
- Az állatok megjelenése az alábbi események előfordulásakor dinamikusan változik.
- Az események kezelésének a folyamata az alábbi:
  - **Esemény -> Felhasználói interakció**
- A lehetséges események az alábbiak:
  - Betegség -> gyógyítás
  - Éhezés -> etetés
