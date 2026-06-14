# Használati eset diagram – Mentés kezelése

```mermaid
flowchart LR
    actor(["Felhasználó"])
    timer(["Autosave\nidőzítő"])

    subgraph kliens ["Zuti Clicker – Mentési alrendszer"]
        direction TB

        manualis_sync(["Manuális\nszinkronizálás"])
        auto_sync(["Automatikus\nszinkronizálás"])
        autosave_toggle(["Autosave\nbe/kikapcsolása"])
        interval_valtas(["Szinkronizálási\nidőköz módosítása"])
        mentes_torles(["Mentés törlése"])
        megerosites(["Törlés megerősítése"])
        vendeg_figy(["Vendégfigyelmeztetés\nmegjelenítése"])

        auto_sync -.->|"«include»"| manualis_sync
        mentes_torles -.->|"«include»"| megerosites
        autosave_toggle -.->|"«extend»"| interval_valtas
    end

    subgraph szerver ["API szerver + Adatbázis"]
        direction TB

        save_load(["Mentés\nbetöltése"])
        save_store(["Mentés\ntárolása"])
        save_reset(["Mentés\ntörlése"])

        db_gamesave(["GameSave\nbejegyzés"])
        db_unitsave(["UnitSave\nbejegyzések"])

        save_store --> db_gamesave
        save_store --> db_unitsave
        save_load --> db_gamesave
        save_reset --> db_gamesave
    end

    actor --> manualis_sync
    actor --> autosave_toggle
    actor --> interval_valtas
    actor --> mentes_torles
    timer -->|"30s / beállított időköz"| auto_sync

    manualis_sync --> save_store
    mentes_torles --> save_reset

    vendeg_figy -.->|"bejelentkezés után"| save_load
```

## Leírás

| Használati eset | Szereplő | Leírás |
|---|---|---|
| Manuális szinkronizálás | Felhasználó | A fejléc „Sync" gombjára kattintva a teljes játékállapot (tokenek, egységek, statisztikák) azonnal elküldésre kerül a `PUT /save` endpointnak. A gomb rövid ideig „✓" jelzést mutat sikeres mentés esetén. |
| Automatikus szinkronizálás | Autosave időzítő | Ha az autosave be van kapcsolva, a rendszer a beállított időközönként (alapértelmezetten 30 másodperc) automatikusan szinkronizálja az állást a szerverrel. |
| Autosave be/kikapcsolása | Felhasználó | Az „Auto" gombra kattintva az automatikus mentés be- vagy kikapcsolható. Kikapcsolt állapotban az időzítő leáll, az intervallum-választó eltűnik. |
| Szinkronizálási időköz módosítása | Felhasználó | Autosave bekapcsolt állapotában a legördülő menüből 15s, 30s, 1m vagy 5m közül választható az automatikus mentés időköze. |
| Mentés betöltése | Rendszer | Bejelentkezés vagy sikeres session ellenőrzés után a `GET /save` endpoint lekéri a mentett állapotot, és visszatölti a játékba (tokenek, egységek száma, eltelt idő stb.). |
| Mentés törlése | Felhasználó | A felhasználói legördülő menüből elérhető „Mentés törlése" opció egy megerősítő dialógust nyit meg. Megerősítés után a `DELETE /save` endpoint meghívásra kerül, és a mentés véglegesen törlődik. |
| Vendégfigyelmeztetés megjelenítése | Rendszer | Ha a munkamenet-ellenőrzés nem talál aktív bejelentkezést, az oldal egy figyelmeztető modalt jelenít meg, amely bejelentkezésre ösztönöz, vagy a felhasználó választhatja a mentés nélküli folytatást is. |
```
