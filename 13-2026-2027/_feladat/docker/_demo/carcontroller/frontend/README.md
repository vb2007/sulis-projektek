# Vue alap | 2627

> Az alap tartalmaz minden olyan csomagot amely az órai feladatok elkészítéséhez szükséges.

## Tartalom

- [Vue alap | 2627](#vue-alap-2627)
  - [Tartalom](#tartalom)
  - [Node és a Vite kezelése](#node-és-a-vite-kezelése)
    - [Telepítés](#telepítés)
    - [Fejlesztői szerver indítás](#fejlesztői-szerver-indítás)
    - [Közzétenni kívánt verzió előállítása](#közzétenni-kívánt-verzió-előállítása)
    - [Unit tesztek futtatása](#unit-tesztek-futtatása)
  - [Mappaszerkezet](#mappaszerkezet)
  - [Dokumentációk](#dokumentációk)

## Node és a Vite kezelése

### Telepítés

Első indítás alkalmával:

```bash
pnpm i
```

Egyéb csomagok telepítése:

```bash
pnpm i <csomag_neve>
```

Fejlesztői csomagok telepítése:

```bash
pnpm i -D <csomag_neve>
```

### Fejlesztői szerver indítás

A fejlesztői szervet a következő paranccsal tudod elnidítani. Ezt követően a jelzett linken éred el a szervert.

```bash
pnpm dev
```

### Közzétenni kívánt verzió előállítása

A következő parancs futtatásával egy olyan mappát állít elő a Vite, amit fel tudsz tölteni egy statikus tárhelyre (Pl. [Vercel](https://vercel.com/), [Netlify](https://www.netlify.com/)), ezzel elérhetővé téve az elkészült oldaladat. Az elkészült fájlokat a `dist` könyvtárban találod.

```bash
pnpm build
```

Ahhoz, hogy ellenőrizni tudd, hogy helyesen működik az alkalmazásod, a következő paranccsal egy olyan szervert tudsz elindítani, ami az elkészült fájlokat mutatja meg neked. Ekkor már fejlesztői eszközök nem fognak működni az oldalon.

```bash
pnpm preview
```

### Unit tesztek futtatása

A projekt Vitest-et használ a unit tesztekhez, a teszteket a `tests` mappában találod.

```bash
pnpm test
```

## Mappaszerkezet

- `components`: Újrahasnosítható komponensek
  - `layout`: Az oldal elrendezéséhez tartozó komponensek (Navbar, Footer)
  - `ui`: Shadcn/vue UI komponensek
- `layouts`: Az oldalakhoz tartozó layout komponensek
- `lib`: Segédfüggvények (pl. Shadcn/vue `cn` util)
- `locales`: Vue I18n fordítási fájlok
- `pages`: Az oldalakat tartalmazó komponensek
- `router`: Routerhez tartozó scriptek
  - `guards`: Router Guardokat tartalmazó scriptek
- `stores`: Pinia tárolók
- `utils`: Kiegészítő scriptek, pl.: Axios

A projekt gyökerében a `tests` mappa tartalmazza a unit teszteket.

## Dokumentációk

- Vite.js: [https://vite.dev](https://vite.dev)
- TailwindCSS: [https://tailwindcss.com](https://tailwindcss.com)
- Vue.js: [https://vuejs.org](https://vuejs.org)
- Vue Router: [https://router.vuejs.org](https://router.vuejs.org)
- Pinia: [https://pinia.vuejs.org](https://pinia.vuejs.org)
- Vee-Validate: [https://vee-validate.logaretm.com](https://vee-validate.logaretm.com)
- Zod: [https://zod.dev](https://zod.dev)
- Vue I18n: [https://vue-i18n.intlify.dev](https://vue-i18n.intlify.dev)
- Vitest: [https://vitest.dev](https://vitest.dev)
- Shadcn/vue: [https://www.shadcn-vue.com/](https://www.shadcn-vue.com/)
