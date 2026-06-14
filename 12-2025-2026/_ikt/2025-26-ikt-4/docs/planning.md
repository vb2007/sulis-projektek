# Tervezés - Zuti Clicker

Az 5 elvetett és a 3 jobban kidolgozott ötletünk közül végül a **Zuti Clicker**-re esett a választás, ezt fogjuk megvalósítani.
Az alábbi bekezdésekben részletesen kifejtettük az elémeli, gyakorlati és technikai terveiknket.

## Áttekintés

Egy szimpla böngészőben futó *idle* játék, melyben a játékos feladata egyszerű:

  - Dr. Zuti Pál fejére kattingatni
  - Ebből tokeneket szerezni
  - Automatizálni a folyamatot

### Kontextus

**A játék egy volt tanárunk tiszteletére készül, aki már elhagyta a Neumannt.**

Olyan professzinális szakszavakat használt, melyek örökké az emlékeinkben maradtak, ezekre ezzel a projekttel is megemlékezünk.

**A felhasznált képek publikusak, nem sértenek személyiségi jogokat.** A projekt egy tiszteletteljes emlék volt tanárunknak.

## Játékmenet, felépítés

### Felhasználói elmény, lehetséges interakciók sorrendje

1. A játékos az oldal megnyitásakor Dr. Zuti Pál személyével találkozik egy körben ábrázolva.
2. A képre kattintáskor tokeneket gyűjthet.
3. A tokeneket különböző fejlesztésekre költheti, melyek **elősegítik a manuális tokenszerzést**, valamint **automatizálják ezt a folyamatot**.

## Technikai specifikációk

A lent található részletes bekezdések bemutatják, milyen technológiák használatával fogjuk megalósítani a projektet.

### Tech-stack

- **Frontend:** Vue.js
- **Backend (API)**: Express.js
- **Frontenden és backenden használt programozási nyelv:** TypeScript
- **Adatbázis:** MariaDB
- **ORM (Object-relational mapping / OOP):** Prisma
- **Csomagkezelő:** pnpm

### Tervezett mappastruktúra

```
zuti-clicker/
├── src/
│   ├── controllers/
│   │   ├── auth.ts
│   │   ├── ...
│   ├── helpers/
│   │   ├── index.ts
│   │   ├── text.ts
│   │   ├── ...
│   ├── router/
│   │   ├── auth.ts
│   │   ├── index.ts
│   │   ├── users.ts
│   │   ├── ...
│   ├── tests/
│   │   ├── auth.ts
│   │   ├── users.ts
│   │   ├── ...
│   └── index.ts
├── .env.example
├── .gitignore
├── .prettierignore
├── .prettierrc.json
├── jest.config.js
├── nodemon.json
├── package.json
├── pnpm-lock.yaml
└── tsconfig.json
```
