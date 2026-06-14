# Fejlesztői dokumentáció – Zuti Clicker

## Projektstruktúra

A projekt két önálló alkalmazásból áll, amelyek egy közös repository gyökér alatt helyezkednek el:

```
zuti-clicker/
--> api/
--> frontend/
--> docs/
```

---

## Előfeltételek

| Eszköz | Verzió |
|---|---|
| Node.js | ≥ 20.19 |
| pnpm | ≥ 10 |
| MariaDB | ≥ 10.6 |

---

## API szerver

### Beállítás

```bash
cd api
cp .env.example .env   # ha van példafájl, különben hozd létre manuálisan
pnpm install
```

A `.env` fájl kötelező mezői:

```env
IP=localhost
PORT=2710

DATABASE_URL="mysql://felhasználó:jelszó@host:3306/zutiClicker"
SHADOW_DATABASE_URL="mysql://felhasználó:jelszó@host:3306/zutiClickerShadow"
DATABASE_USER=felhasználó
DATABASE_PASSWORD=jelszó
DATABASE_NAME=zutiClicker
DATABASE_HOST=host
DATABASE_PORT=3306

CRYPTO_SECRET_KEY=<min. 64 karakteres véletlen string>
```

A shadow adatbázis a Prisma migrációk validálásához szükséges; ugyanazon a szerveren kell lennie, de üres adatbázisként.

### Adatbázis migráció

```bash
pnpm prisma migrate deploy   # meglévő migrációk futtatása
pnpm prisma generate         # Prisma client újragenerálása (sémaváltozás után)
```

### Indítás

```bash
pnpm start    # nodemon + tsx – fejlesztői mód, automatikus újraindítás
```

Az API elérhető: `http://localhost:2710`  
Swagger docs: `http://localhost:2710/docs`

### Tesztek futtatása

A tesztekhez az API-nak futnia kell (a tesztek élő szerver ellen dolgoznak):

```bash
pnpm test
```

A tesztek a `tests/` mappában találhatók. Az összes teszt a `TestData` osztályból veszi az adatokat (`tests/test-data.ts`); a belépési adatokat minden futtatás véletlenszerűen generálja, a mentési payloadok hardkódoltak.

---

## Frontend

### Beállítás

```bash
cd frontend
pnpm install
```

### Indítás

```bash
pnpm dev # Vite dev szerver, Hot Module Replacement
```

A frontend elérhető: `http://localhost:5173`

A Vite dev szerver proxy-n keresztül kapcsolódik az API-hoz: minden `/api/*` kérés automatikusan `http://localhost:2710/*` -ra irányítódik. Az API-nak futnia kell a frontend megfelelő működéséhez.

### Build

```bash
pnpm build # type-check + bundle
pnpm preview # a build előnézete lokálisan
```

---

## Architektúra áttekintő

### API rétegek

```
router/ → controllers/ → database/models/ → Prisma → MariaDB
              ↑
         middlewares/  (isAuthenticated)
```

- **`router/`** – Express route regisztráció (`authentication.ts`, `save.ts`)
- **`controllers/`** – Request/response kezelés, validáció, Swagger JSDoc
- **`database/models/`** – Adatbázis műveletek (Prisma hívások)
- **`middlewares/`** – `isAuthenticated`: session token ellenőrzés, `req.identity` feltöltése
- **`helpers/`** – HMAC-SHA256 hitelesítés, random token generálás
- **`constants/responses.ts`** – Centralizált HTTP válaszkódok és üzenetek

### Frontend state management

```
App.vue
  ├── useGameLoop()          → gameStore.tick() 20x/s
  ├── authStore              → session check, login/register/logout
  ├── saveStore              → load/sync/reset, autosave timer
  ├── uiStore                → modal állapotok
  └── gameStore              → tokenek, egységek, statisztikák
```

A `saveStore` a `authStore`-tól függ: az autosave timer automatikusan elindul/leáll amikor `isLoggedIn` megváltozik.

---

## Új egység hozzáadása

1. Szerkeszd a `frontend/src/utils/gameConstants.ts` fájlt, adj hozzá egy új elemet a `UNIT_DEFINITIONS` tömbhöz:

```typescript
{ id: "iota", baseCost: 5_000_000_000, baseProduction: 150_000, costGrowth: 1.15 }
```

2. Adj hozzá fordítási kulcsokat mindkét i18n fájlhoz (`src/i18n/en.ts`, `hu.ts`):

```typescript
names: { ..., iota: "Iota" },
descriptions: { ..., iota: "Leírás..." }
```

Az egység azonnal megjelenik a shopban (a láthatóság automatikusan számított: `totalTokensEarned >= baseCost * 0.1`).

---

## Új API endpoint hozzáadása

1. Hozd létre a controller függvényt `src/controllers/` mappában (Swagger JSDoc kommenttel együtt).
2. Regisztráld a route-ot a megfelelő `src/router/*.ts` fájlban.
3. Ha szükséges, adj hozzá új válaszkódokat a `src/constants/responses.ts`-be.
4. Írj teszteket a `tests/` mappában.

---

## Fontos tudnivalók fejlesztőknek

- A projekt `"type": "module"` (ESM). CommonJS `require()` nem működik; minden import ESM `import` szintaxist használ.
- A lodash CJS named import (`import { merge } from "lodash"`) az ESM miatt hibát okoz; kerüld a használatát.
- A Prisma client a `generated/prisma/` mappában van, nem a szokásos `node_modules/@prisma/client` helyen. A `pnpm prisma generate` futtatása után commitolni kell a generált fájlokat is.
- A `CORS_ORIGIN_URLS` environment változó nincs beállítva a `.env`-ben; fejlesztési módban a Vite proxy kezeli a cross-origin kéréseket, így CORS konfiguráció nem szükséges.
- A session tokenek az `Authentication.sessionToken` mezőben tárolódnak. Kijelentkezéskor ez üres stringre áll vissza, nem törlődik a rekord.
```
