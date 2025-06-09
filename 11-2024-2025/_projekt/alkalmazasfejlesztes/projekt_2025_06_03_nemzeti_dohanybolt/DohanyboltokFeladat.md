# Nemzeti Dohányboltok

A feladata, hogy különböző Nemzeti Dohányboltok adatait dolgozza fel, valamint később különféle dohánytermékekkel foglalkozzon.

A feladat megírása során:

- Dolgozzon a példa alapján
- Igyekezzen mindig a legmegfelelőbb osztályok, interfészek, változó típusok használatára
- Az ékezetmentes kiírás is elfogadott
- Ha szükséges, rendezze a fájlokat mappákba az átláthatóság érdekében

## Forrásfájl felépítése

A forrásfájl neve `tobaccostores.txt`, mely a következő oszlopokat tartalmazza:

- `Város`: **szöveg** - a város neve, ahol a dohánybolt található
- `Utca`: **szöveg** - az utca neve, ahol a dohánybolt található
- `Havi bevétel`: **egész szám** - a dohánybolt havi bevétele Ft-ban
- `Forgalom`: **egész szám** - a dohánybolt napi átlag látogatottsága (ember/nap)
- `Legnépszerűbb termék`: **szöveg** - a legtöbbet eladott termék a boltban

## Feladatok

### 1. Rész (fájlbeolvasás)

1. Hozzon létre egy `TobaccoStores_XY` nevű C# Console alkalmazás projektet, ahol az `XY` a saját monogramja.
2. Hozzon létre egy `TobaccoStores_XY_Lib` nevű Class Library projektet, amit hozzácsatol a Console alkalmazáshoz. Továbbiakban ezt a projektet használja a releváns feladatok megoldására.
3. Hozzon létre egy `TobaccoStore` valamint egy `TobaccoStores` osztályt, melyet a forrásfájl adatainak eltárolására fog használni.
4. Olvassa be a forrásfájlban található dohányboltok adatait a megfelelő osztály / osztályok segítségével.
5. Írja ki a konzolra, hogy összesen hány dohánybolt adatai vannak eltárolva a forrásfájlban.
6. Írja ki a dogányboltok összesített havi bevételét.
7. Írja ki a Budapesti dohányboltok Utcáinak nevét. Az utcanevek mellé írja ki a boltban található legnépszerűbb termék nevét is.
8. Írja ki annak a dohányboltnak az összes adatát, amelynek a legtöbb forgalma volt.

### 2. Rész (Interface, generálás, fájlbaírás)

9. Hozzon létre egy `IProduct` interfészt, amely tartalmazza a következő változókat:
    - `Name`: **szöveg** - a termék neve
    - `Price`: **egész szám** - a termék ára
    - `Category`: **szöveg** - a termék kategóriája (kizárólag "Cigarette", vagy "Cigar")
10. Hozzon létre egy `Cigarette` és egy `Cigar` osztályt, amelyek implementálják az `IProduct` interfészt. A `Cigarette` osztály tartalmazzon egy `NicotineContent` változót (egész szám, mg-ban értetendő), míg a `Cigar` osztály tartalmazzon egy `Length` változót (szintén egész szám, cm-ben értetendő).
11. Hozzon létre egy `TobaccoFactory` osztályt, amelynek a konstruktora random **X** db dohányterméket generál tetszőleges adatok alapján.
12. Az előbb elkészített konstruktor segítségével generáljon 20 dohányterméket.
13. Írja ki a kozolra a legolcsóbb dohánytermék kategóriáját, nevét és árát.
14. Írja ki fájlba a generált dohánytermékek kategóriáját, nevét és árát egy `products.txt` nevű fájlba. Először a `Cigarette`, később pedig a `Cigar` típusú termékeket írja ki. A kettő kategória között legyen egy üres sor. Minden termék új sorba kerüljön. A fájl formátuma legyen az alábbi:
    - `{Category}: {Name}, Ár: {Price} Ft`
15. Írja ki a legtöbb nikotint tartalmazó cigaretta nevét és nikotintartalmát. Szüksége lesz rá ezután a feladat megoldása után.

## Minta

Feladatok:

```txt
5. feladat: Összesen 30 dohánybolt adatai vannak eltárolva.
6. feladat: A dohányboltok összesített havi bevétele: 29200000 Ft
7. feladat: A Budapesti dohányboltok utcáinak nevei és legnépszerűbb termékeik:
        Kossuth Lajos utca 1 - Marlboro Gold
        Váci utca 42 - Camel sárga
        Andrássy út 66 - Marlboro Touch
        Rákóczi út 90 - Camel kék
        Üllői út 82 - Marlboro Crafted
8. feladat: A legformalmasabb dohánybolt adatai:
        Elhelyezkedése (város): Budapest
        Elhelyezkedése (utca): Andrássy út 66
        Havi bevétele: 2000000 Ft
        Forgalma: 350 ember/nap
        Legnépszerűbb terméke: Marlboro Touch
13. feladat: A legolcsóbb dohánytermék adatai:
        Kategória: Szivarka
        Név: Djarum Black Emerald
        Ár: 701 Ft
A termékek sikeresen kiírva a 'products.txt' fájlba.
15. feladat: Legtöbb nikotint tartalmazó cigaretta:
        Neve: Marlboro Gold
        Nikotintartalma: 16 mg
```

A `products.txt` fájl tartalma:

```txt
Cigaretta: Pall Mall Gold, Ár: 1878 Ft
Cigaretta: Marlboro Red, Ár: 1849 Ft
Cigaretta: Marlboro Red, Ár: 1688 Ft
Cigaretta: Pall Mall Gold, Ár: 1118 Ft
Cigaretta: Marlboro Gold, Ár: 1725 Ft
Cigaretta: Marlboro Gold, Ár: 2219 Ft
Cigaretta: Marlboro Red, Ár: 2385 Ft
Cigaretta: Marlboro Gold, Ár: 986 Ft
Cigaretta: Marlboro Red, Ár: 1249 Ft

Szivarka: Marlboro Leaf Beyond Blue, Ár: 2236 Ft
Szivarka: Djarum Black Ruby, Ár: 1561 Ft
Szivarka: Davidoff Demi Tasse, Ár: 1662 Ft
Szivarka: Djarum Black Ruby, Ár: 1987 Ft
Szivarka: Djarum Black Ruby, Ár: 1307 Ft
Szivarka: Djarum Black Emerald, Ár: 2445 Ft
Szivarka: Marlboro Leaf Beyond Blue, Ár: 2016 Ft
Szivarka: Djarum Black Emerald, Ár: 701 Ft
Szivarka: Davidoff Demi Tasse, Ár: 1024 Ft
Szivarka: Amigos Mini Filter, Ár: 735 Ft
Szivarka: Amigos Mini Filter, Ár: 1102 Ft
```

Keszült Magyarország Kormánya Megízásából (ha már ennyi adót behúz a monopolizált dohányboltokon a mocskos fidesz).
