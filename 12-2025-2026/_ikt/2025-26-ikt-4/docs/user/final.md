# Felhasználói dokumentáció – Zuti Clicker

## Mi ez a játék?

A Zuti Clicker egy böngészőalapú inkrementális játék (más néven idle game vagy clicker game). A célod tokeneket szerezni – kattintással, vagy megvásárolt egységekkel, amelyek automatikusan termelnek neked. Minél több egységed van, annál gyorsabban gyűlik a token. Az egységek ára és hozama exponenciálisan növekszik, így a fejlődés sosem ér véget.

---

## A játék megnyitása

A játék a böngészőben fut, nincs telepítés. Nyisd meg a megadott URL-en (alapértelmezetten `http://localhost:5173`). Az oldal azonnal betöltődik és a játék elindul – bejelentkezés nélkül is játszható.

---

## Vendégfigyelmeztetés

Az oldal első megnyitásakor, ha nem vagy bejelentkezve, egy felugró ablak jelenik meg:

> **„A haladásod nem kerül mentésre"**

Ez azt jelenti, hogy ha bezárod vagy frissíted az oldalt, a játékod elvész. Két lehetőséged van:

- **„Bejelentkezés / Regisztráció"** – Megnyílik a bejelentkezési ablak, ahol fiókot hozhatsz létre vagy bejelentkezhetsz.
- **„Folytatás mentés nélkül"** – A figyelmeztetés eltűnik, de a játék nem kerül mentésre.

---

## Fiók létrehozása és bejelentkezés

A fejléc jobb oldalán, a „💾 Login to save" gombra kattintva megnyílik a hitelesítési ablak.

### Regisztráció
1. Válaszd a **„Register"** / **„Regisztráció"** fület.
2. Add meg a felhasználónevedet, e-mail címedet és jelszavadat.
3. Kattints a **„Create account"** / **„Fiók létrehozása"** gombra.
4. Sikeres regisztráció után az alkalmazás automatikusan bejelentkeztet, és betölti a korábbi mentésedet (ha van).

### Bejelentkezés
1. Válaszd a **„Log in"** / **„Bejelentkezés"** fület.
2. Add meg az e-mail címedet és jelszavadat.
3. Kattints a **„Log in"** / **„Bejelentkezés"** gombra.

Ha hibás adatokat adsz meg, piros hibaüzenet jelenik meg a mezők alatt.

---

## A felület felépítése

Az alkalmazás három részre osztja a képernyőt:

```
┌─────────────────┬───────────────────────────┬──────────────────┐
│  Státuszoszlop  │         Kattintó          │  Egységek panel  │
│   (bal oldal)   │        (középen)          │   (jobb oldal)   │
└─────────────────┴───────────────────────────┴──────────────────┘
```

---

## Státuszoszlop (bal oldal)

A bal oldali panel valós időben mutatja a játékod aktuális állását:

| Statisztika | Leírás |
|---|---|
| **Tokens** | Jelenlegi token egyenleg |
| **Per Second** | Hány tokent termelnek az egységeid másodpercenként |
| **Per Click** | Hány tokent kapsz egy kattintásért |
| **Total Earned** | Az összes valaha szerzett token (nem csökken vásárlásnál) |
| **Total Clicks** | Az összes eddigi kattintásod száma |
| **Time Played** | Az eltelt játékidő |

A token/s érték a játék elején 0.00-ként jelenik meg, amíg az első egységeket meg nem veszed.

---

## Kattintó (középen)

A kép Dr. Zuti Pál portréját ábrázolja. Kattints rá a tokenek megszerzéséhez! Minden kattintásra:
- A kör rövid animációt játszik le.
- Egy lebegő „+1" (vagy nagyobb, ha szorzókat vásároltál) szám jelenik meg a kattintás helyén, majd felfele úszik és eltűnik.
- A token egyenleged azonnal növekszik.

---

## Egységek panel (jobb oldal)

### Szorzóválasztó

Az egységlista tetején öt gomb van: **1×, 5×, 10×, 50×, Max**. Ez határozza meg, hogy egyszerre hány egységet veszel meg, ha a „Buy" gombra kattintasz.

- A **Max** gomb automatikusan kiszámítja, hogy jelenlegi egyenlegedből mennyi egységet tudsz megvásárolni, és annyit vesz.

### Egységkártya

Minden egységnek saját kártyája van:

- **Bal oldal**: Az egység neve, száma (hány darabot birtok) és az egységenkénti termelés (token/s).
- **Jobb oldal**: A **Buy** gomb, rajta a szorzónak megfelelő mennyiség és az ár.
- Ha nincs elég tokened, a gomb szürkén jelenik meg és le van tiltva; a felirat „Need more tokens" / „Nincs elég token" lesz.

### Tooltip

Ha az egérkurzort egy egységkártya fölé viszed, egy kis ablak jelenik meg:
- **Cost**: Az aktuális vásárlás ára (a kiválasztott szorzónak megfelelő mennyiségre)
- **Income gain**: Mennyivel növekszik a másodpercenkénti termelésed a vásárlással
- **Each unit**: Egy egység termelése másodpercenként

### Az egységek láthatósága

Egy egység addig rejtett, amíg az összes szerzett tokened nem éri el az alap ára 10%-át. Minél több tokent szerzel, annál több egység jelenik meg a shopban.

---

## Mentés és szinkronizálás

Ha be vagy jelentkezve, a fejlécben megjelennek a mentési vezérlők:

### „Sync" gomb
Azonnali mentés. A jelenlegi játékállapot (tokenek, egységek, statisztikák) elküldésre kerül a szerverre. Sikeres mentés esetén a gomb „✓"-re vált néhány másodpercre.

### „Auto" gomb
Az automatikus mentés be- és kikapcsolása. Ha be van kapcsolva (kék szín), a rendszer a beállított időközönként automatikusan elmenti a játékot.

### Időközválasztó (15s / 30s / 1m / 5m)
Csak akkor látható, ha az autosave be van kapcsolva. Meghatározza, milyen sűrűn mentsen a rendszer automatikusan. Alapértelmezetten 30 másodperc.

### Felhasználói menü (`Felhasználónév`)
A felhasználónevedre kattintva legördülő menü jelenik meg:
- **„Delete save"** / **„Mentés törlése"**: Megerősítés után a mentési fájl véglegesen törlődik az adatbázisból. **Ez nem vonható vissza.**
- **„Log out"** / **„Kijelentkezés"**: Kijelentkezés a fiókból. A munkamenet megszűnik, de a játék helyben fut tovább (vendég módban).

---

## Téma és nyelv

A fejléc jobb szélén két gomb található:

- **Nyelv**: Angolra vagy magyarra váltás. Az összes szöveg azonnal megváltozik.
- **Téma**: Sötét és világos megjelenési mód közötti váltás.

---

## Bezárás előtt

Ha az oldalon van bármi haladásod (legalább egy kattintás történt), a böngésző figyelmeztet, ha megpróbálod bezárni vagy frissíteni az oldalt:

> „Biztosan el akarsz navigálni? Elveszítheted a módosításokat."

Ha be vagy jelentkezve és az autosave be van kapcsolva, a rendszer általában már elmenti az állapotot a figyelmeztetés megjelenése előtt. Ha nem, kattints a „Sync" gombra mielőtt bezárod az oldalt.
```
