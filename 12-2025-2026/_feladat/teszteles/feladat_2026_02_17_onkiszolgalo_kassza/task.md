# Tesztelés, 3. heti feladatsor

A mai órán a feladat egy önkiszolgáló kassza megvalósítása és tesztelése. A kasszának a következő funkciókat kell megvalósítania:

- Új bevásárlás megkezdése
- Termék beolvasása
- Termék törlése (sztornózása)
- Végösszeg kiszámítása
- Tárolt tételek kilistázása
- Fizetés (visszajáró kiszámítása)

1. Készíts SelfCheckout nevű Solution-t, amibe három projekt kerül:
  - egy Console Application (manuális teszteléshez)
  - egy Class Library (ide kerül az implementáció)
  - egy Unit Test (MSTest, a unit teszteknek)
2. A Class Librarybe hozd létre a Cash Register osztályt! Az osztályba a fenti feladat alapján hozd létre statikus metódusokkal az interfészt, amit tesztelni fogunk!
3. Készíts unit tesztet a különböző részfeladatokhoz!
4. Készíts a konzol alkalmazásban egy konzolos felületet menüvel, ahol a különböző
funkciókat megvalósítod! Figyelj rá, hogy csak a megfelelő állapotban lehessen végrehajtani a funkciókat! (Az új bevásárlás megkezdése csak akkor lehetséges, ha az előzőt befejezeték, Termék beolvasása, törlése, stb csak akkor lehetséges, ha bevásárlás éppen aktív!)
