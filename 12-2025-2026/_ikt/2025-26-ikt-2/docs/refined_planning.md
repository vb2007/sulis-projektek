# Állatmenhely adminisztrációs alkalmazás

Az elsődlegesen elkészített változat a tanárunk által szabott követelményeknek nem felelt meg, így újratervezés után <ins>ez a **végelegsített** tervezési dokumentáció.</ins>

A **funkcionalitás** bekezdés **minimálisan változott**, míg a **tech-stack** jelentősen, gyakorlatilag **teljesen**.

Az elkövetkezendő projektben egy állatmenhelynek fogunk lefejleszteni egy **full-stack** távolról managelhető alkalmazást.

## Funkciók

Az alábbi funkciók lesznek használhatók az alkalmazásban:

- Állatok kezelése (admin jogosultság)
  - Új állat felvétele
  - Meglévő állatok adatainak módosítása
  - Meglévő állat törlése a rendszerből
  - Minden foglalt időpont megtekintése (állatonként)
  - Minden foglalt időpont törlése (állatonként)
- Időpontfoglalás kezelés (felhasználói jogosultság)
  - Állatok megtekintése, minden egyes új állathoz:
    - Új időpontfoglalás feljegyzése
    - Saját foglalt időpontok megtekintése
    - Saját foglalt időpontok módosítása
    - Saját foglalt időpontok törlése

Természetesen a fent felsorolt feature-ökhöz sok egyéb ellenőrzés szükséges.

Ezeket lent felsorolom, de fejlesztés során ezek módosulhatnak:

- Új regisztrációk felhasználók számára, emellé:
  - Saját adatok módosítása
  - Felhasználói fiók törlése (összes foglalt időponttal együtt)
- Felhasználók admin-ná változtatása adatbázisból (manuálisan, általunk)
- Egy user egyszerre csak egy állathoz foglalhat időpontot, ennek validálása releváns felületeken

## Tech-stack

Az alábbi tech-stack segítségével fogjuk megvalósítani a projektet:

- Frontend: **ASP.NETs**
- Backend: **szimpla .NET REST API stdlib-ek használatával**
- Adatbázis: **MsSQL** (kompatibilitás kedvéért)
  - Az itthoni szervert fogom felhasználni (nem akarok cloudért fizetni)
  - Az ER-Diagram tervezésében (és megvalósításába) segít a DBeaver
