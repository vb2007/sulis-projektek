# Használati eset diagram – Hitelesítés

```mermaid
flowchart LR
    actor(["👤 Felhasználó"])

    subgraph rendszer ["Zuti Clicker – Hitelesítési alrendszer"]
        direction TB

        regisztracio(["Regisztráció"])
        bejelentkezes(["Bejelentkezés"])
        kijelentkezes(["Kijelentkezés"])
        session_check(["Munkamenet\nellenőrzése"])
        vendeg_mod(["Folytatás\nmentés nélkül"])
        hiba_uzenet(["Hibaüzenet\nmegjelenítése"])
        auth_modal(["Hitelesítési\nmodal megnyitása"])

        session_check -.->|"«include»"| bejelentkezes
        regisztracio -.->|"«include»"| bejelentkezes
        regisztracio -.->|"«extend»"| hiba_uzenet
        bejelentkezes -.->|"«extend»"| hiba_uzenet
        auth_modal -->|"tab: regisztráció"| regisztracio
        auth_modal -->|"tab: bejelentkezés"| bejelentkezes
    end

    subgraph szerver ["API szerver"]
        direction TB
        db_session(["Session token\ntárolása"])
        db_clear(["Session token\ninvalidálása"])
        cookie_set(["AUTH_TOKEN\ncookie beállítása"])
        cookie_clear(["AUTH_TOKEN\ncookie törlése"])

        cookie_set --> db_session
        cookie_clear --> db_clear
    end

    actor -->|"oldal betöltésekor"| session_check
    actor --> auth_modal
    actor --> vendeg_mod
    actor --> kijelentkezes

    bejelentkezes --> cookie_set
    kijelentkezes --> cookie_clear
```

## Leírás

| Használati eset | Szereplő | Leírás |
|---|---|---|
| Regisztráció | Felhasználó | Felhasználónév, e-mail és jelszó megadásával új fiók létrehozása. Sikeres regisztráció után automatikus bejelentkezés történik. |
| Bejelentkezés | Felhasználó | E-mail és jelszó ellenőrzése. Sikeres hitelesítés után `AUTH_TOKEN` session cookie kerül beállításra, és a mentés automatikusan betöltődik. |
| Kijelentkezés | Felhasználó | A session token invalidálása az adatbázisban és a cookie törlése a böngészőből. |
| Munkamenet ellenőrzése | Rendszer | Oldal betöltésekor a `GET /auth/me` endpoint hívásával az alkalmazás megvizsgálja, hogy a felhasználó már be van-e jelentkezve. |
| Folytatás mentés nélkül | Felhasználó | Ha a felhasználó nem kíván bejelentkezni, bezárhatja a figyelmeztető modalt és vendégként folytathatja a játékot munkamenet nélkül. |
| Hibaüzenet megjelenítése | Rendszer | Érvénytelen belépési adatok, foglalt e-mail cím vagy felhasználónév esetén az API által visszaadott hibaüzenet jelenik meg a modalban. |
```
