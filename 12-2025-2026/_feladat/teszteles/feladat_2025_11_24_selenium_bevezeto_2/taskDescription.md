1. Feladat (Órai kód kiegészítése):

- Navigálj az oldal egyik kategóriájára, ahol több oldalon keresztül szerepelnek könyvek. (pl.: „Fantasy”)
- Összegezd az adott kategórián belül szereplő ÖSSZES könyv árát. A készlet mennyiségével nem kell foglalkozni, minden könyv ára egyszer szerepeljen. (lapozni kell az oldalakat a kategórián belül).
- Ellenörizd, hogy annyi-e az összérték, mint amennyit mondunk. (Fantasy esetében 1900.51)

2. Feladat (Bonyolultabb):

- Navigálj az oldal egyik kategóriájára, ahol több oldalon keresztül szerepelnek könyvek. (pl.: „Fantasy”)
- Összegezd, hogy az adott kategóriában összesen hány darab könyv van készleten. (Minden könyvre, minden oldalon megnézed a készlet mennyiségét. Rá kell kattintani minden könyvre.)
- Ellenőrizd, hogy annyi-e az összesített könyv készlet mennyisége, mint amennyit mondunk. (Fantasy esetében 372)

Segítség:
- Az adott kategórián belül az utolsó oldalon nincs Next gomb. (Egyel kevesebbszer kell a next-re menni, mint amennyi oldal van.)
- Visszalépni a böngészőben:  driver.Navigate().Back();
- A második feladatnál a foreach nem fog működni, sima for ciklust használj.
- A második feladatnál a belső cikluson belül kell lekérni a könyvek listáját. (Amennyi könyv van, annyiszor lesz lekérve az összes könyv.)
