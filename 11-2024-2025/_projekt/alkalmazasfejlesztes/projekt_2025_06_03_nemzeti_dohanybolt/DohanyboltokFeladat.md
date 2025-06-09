# Dohanyboltok Feladat

A feladata, hogy különböző Nemzeti Dohányboltok eladási és egyéb adatait az alábbi leírás alapján kezelje, módosítsa.

## Forrásfájl felépítése

A forrásfájl neve `tobaccostores.txt`, mely a következő oszlopokat tartalmazza:

- `Város`: **szöveg** - a város neve, ahol a dohánybolt található
- `Utca`: **szöveg** - az utca neve, ahol a dohánybolt található
- `Havi bevétel`: **egész szám** - a dohánybolt havi bevétele Ft-ban
- `Forgalom`: **egész szám** - a dohánybolt napi átlag látogatottsága (ember/nap)
- `Legnépszerűbb termék`: **szöveg** - a legtöbbet eladott termék a boltban

## Feladatok

1. Hozzon létre egy `TobaccoStores_XY` nevű C# Console alkalmazás projektet, ahol az `XY` a saját monogramja.
2. Hozzon létre egy `TobaccoStores_XY_Lib` nevű Class Library projektet, amit hozzácsatol a Console alkalmazáshoz. Továbbiakban ezt a projektet használja a releváns feladatok megoldására.
3. Hozzon létre egy `TobaccoStore` valamint egy `TobaccoStores` osztályt.
4. Hozzon létre egy `IProduct` interfészt, amely tartalmazza a következő változókat:
   - `Name`: **szöveg** - a termék neve
   - `Price`: **decimális** - a termék ára
   - `Category`: **szöveg** - a termék kategóriája
5. Hozzon létre egy `Cigarette` és egy `Cigar` osztályt, amelyek implementálják az `IProduct` interfészt. A `Cigarette` osztály tartalmazzon egy `NicotineContent` változót, míg a `Cigar` osztály tartalmazzon egy `Length` változót.
6. Hozzon létre egy `TobaccoFactory` osztályt, amelynek a konstruktora random **X** db dohányterméket generál.

### Minta

```shell
```
