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
6. Írja ki a legmagasabb havi bevétellel rendelkező dohánybolt adatait.
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
13. Írja 

## Minta

Feladatok:

```shell
```

`.txt` fájl tartalma:

```txt
```
