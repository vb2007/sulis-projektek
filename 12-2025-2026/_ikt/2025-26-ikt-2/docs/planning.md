# Állatmenhely adminisztrációs alkalmazás

Az elkövetkezendő projektben egy állatmenhelynek fogunk lefejleszteni egy **full-stack** távolról managelhető alkalmazást.

## Funkciók

Az alábbi funkciók lesznek használhatók az alkalmazásban:

- Állatkezelés (admin jogosultság)
  - Új állat felvétele
  - Meglévő állatok adatainak módosítása
  - Meglévő állat törlése a rendszerből
- Időpontfoglalás kezelés (felhasználói jogosultság)
  - Új időpont foglalása állat látogatására
  - Saját foglalt időpontok megtekintése
  - Időpontfoglalás törlése

Természetesen a fent felsorolt feature-ökhöz sok egyéb ellenőrzés szükséges.

Ezeket lent felsorolom, de fejlesztés során ezek módosulhatnak:

- Új regisztrációk felhasználók számára
- Felhasználók admin-ná változtatása adatbázisból (manuálisan, általunk)
- Egy user egyszerre csak egy állathoz foglalhat időpontot
- Már lefoglalt időpontok lekezelése (pl. ugyan arra az időpontra csak egy felhasználó foglalhat)

## Tech-stack

Az alábbi tech-stack segítségével fogjuk megvalósítani a projektet:

- Frontend: **Vue.js**
  - Node.js
  - TypeScript
  - Esetlegesen Pinia state kezelésre
  - Egyéb npm csomagfüggőségek
- Backend: **Express.js**
  - Node.js
  - TypeScript
  - Egyéb npm csomagfüggőségek
- Adatbázis: **MongoDB**
  - Valószínűleg az itthoni szerverre telepített MongoDB szervert fogjuk használatba venni
