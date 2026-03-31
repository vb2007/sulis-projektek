# NGiNX és PHP 8.4 webszerver docker alapokon

## Előkészítés



1. Készítsen másolatot az `.env-example` fájlról `.env` néven.

## Indítás

Az indításhoz futtassa az alábbi parancsot a projektmappában állva:

```bash
docker compose up -d
```

- Az `up` indítja el a konténereket, ha még nem volt build, akkor a build is lefut.

- A `-d` hatására a háttérben indul, visszakapjuk a konzolt.

- A parancs kiadásához abban a mappában kell lenni, ahol a .env fájlt található, hogy az abban lévő környezeti változókat használja!

## Leállítás és törlés


```bash
docker compose stop
```

- A `stop` leállítja az éppen futó konténereket.

```bash
docker compose down
```

- A `down` nem csak leállítja, hanem törli is a konténereket.

## Csatlakozás a konténerhez

```bash
docker compose exec app fish
```

- A fenti parancs az `app` nevű szolgáltatáshoz tartozó konténeren belül futtatja a `fish` nevű shellt. Ezen belül lehet elérni többek között a `composer`-t.

- Az `app` helyére a szolgáltatása neve kerül: `app` vagy `web` attól függően, hogy melyik konténert szeretnénk elérni.

- Kilépni az `exit` paranccsal lehet.

## Hibakeresés és logolás

A futó konténerek ellenőrzése:

```bash
docker compose ps
```

- Amennyiben nem fut a kettő (`web`,`app`) közül az egyik, úgy érdemes megnézni a logfájlokat.

```bash
docker compose logs
```

- A fenti parancs az összes konténer által logolt adatot megmutatja.

```bash
docker compose logs web -f
```

- A fenti parancs folyamatosan mutatja a `web` szolgáltatása, azaz a webszerver log adatait.
- Itt látható, ha valaki betölti valamelyik oldalt.
- Kilépni a `ctrl`+`c` billentyűkombinációval lehet.