# JS Alapok Gyakorló feladat tesztek

Teszt esetek a feladathoz.

## Előkészületek

Ha otthon futtatod, szükséges a Node.js és az npm telepítése!

1. Másold le a `.env.example` fájlt `.env` néven.

    ```bash
    cp .env.example .env
    ```

2. Írd át a `.env` fájlban a HTTP_PATH értékét a saját megoldásod elérési útvonalára (ne adj meg HTML fájlnevet, az útvonal végén mindig legyen `/`!)

    Példa, ha Live Servert használsz:

    ```bash
    HTML_PATH=http://127.0.0.1:5500/
    ```

    Példa, ha fájlból nyitod meg:

    ```bash
    HTML_PATH=file:///path/feladat_JS_alapok_gyakorlo
    ```

3. A teszteket a bash scriptek segítségével futtathatod. Előfordulhat, hogy azt írja, nincs jogosultságod futtatni. Használd az alábbi parancsot a terminálban:

    ```bash
    chmod +x task1.sh task2.sh task3.sh task4.sh all.sh
    ```

## Futtatás

1. A tesztek futtatásához indítsd el az adott bash scriptet.

    Lehet csak egy konkrét feladatét...

    ```bash
    ./task1.sh
    ```

    ...vagy az összesét egyszerre.

    ```bash
    ./all.sh
    ```

2. Ha `TimeoutError: Waiting for alert to be present` hibát kapsz, illetve a megnyilt böngészőben azt látod, hogy *"Cannot GET .../task1.html"*, akkor rossz a `HTTP_PATH` a `.env` fájlban.


3. Ha csak `TimeoutError: Waiting for alert to be present`, de az oldal megjelenik, akkor hiba van a megoldásodban (nem jelenik meg a prompt/alert amikor meg kellene.)
