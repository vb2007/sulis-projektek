# Használati eset diagram – Játékmenet

```mermaid
flowchart LR
    actor(["Felhasználó"])
    auto(["Játékmotor\n(automatikus)"])

    subgraph kliens ["Zuti Clicker – Játék kliens"]
        direction TB

        kor_kattintas(["Kör megnyomása"])
        float_szam(["Lebegő szám\nmegjelenítése"])
        token_szerzese(["Token jóváírása"])

        egyseg_vasarlas(["Egység vásárlása"])
        szorzo_valasztas(["Szorzó kiválasztása"])
        tooltip_nezet(["Tooltip megtekintése"])
        statisztika_nezet(["Statisztikák\nmegtekintése"])

        auto_termelel(["Automatikus\ntoken termelés"])
        tps_frissites(["Token/mp\nfrissítése"])

        kor_kattintas -.->|"«include»"| float_szam
        kor_kattintas -.->|"«include»"| token_szerzese
        egyseg_vasarlas -.->|"«include»"| szorzo_valasztas
        egyseg_vasarlas -.->|"«include»"| token_szerzese
        auto_termelel -.->|"«include»"| tps_frissites
        auto_termelel -.->|"«include»"| token_szerzese
    end

    actor --> kor_kattintas
    actor --> egyseg_vasarlas
    actor --> szorzo_valasztas
    actor --> tooltip_nezet
    actor --> statisztika_nezet
    auto -->|"20 tick/s"| auto_termelel
```

## Leírás

| Használati eset | Szereplő | Leírás |
|---|---|---|
| Kör megnyomása | Felhasználó | A középső körre kattintva a felhasználó tokeneket szerez. Minden kattintáskor lebegő `+N` animáció jelenik meg a kör felett, és a token egyenleg azonnal növekszik. |
| Egység vásárlása | Felhasználó | A jobb oldali panelen az elérhető egységek megvásárolhatók. Vásárlásnál a kiválasztott szorzónak megfelelő mennyiség kerül megvételre, ha a felhasználónak elegendő tokenje van. |
| Szorzó kiválasztása | Felhasználó | Az egységpanel tetején 1×, 5×, 10×, 50× és Max szorzók közül lehet választani. A Max szorzó az aktuális egyenlegből megvásárolható maximális mennyiséget jelöli. |
| Tooltip megtekintése | Felhasználó | Egységkártyára húzva az egérkurzort egy tooltip jelenik meg a vásárlás várható árával, az összes termelési növekedéssel és az egységenkénti termeléssel. |
| Statisztikák megtekintése | Felhasználó | A bal oldali státuszoszlop valós időben mutatja az aktuális token egyenleget, a másodpercenkénti termelést (token/s), kattintankénti hozamot, összes szerzett tokent, kattintások számát és az eltelt játékidőt. |
| Automatikus token termelés | Játékmotor | A megvásárolt egységek másodpercenként automatikusan tokeneket termelnek. A játékhurok 20 tick/s sebességgel fut és az összes termelési értéket folyamatosan frissíti. |
```
