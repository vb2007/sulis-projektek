# 4. IKT Projektmunka tervezés

## Megvalósítási logika

Egy .NET 9-es Console app, melyben a bal oldalon egy 8x8-as játékpálya található meg, a jobb oldalon pedig a játékos adatai. Interakciók során szintén a jobb oldalon fognak megjelenni az egyéb menük (opcióválasztók, csata státuszát jelző menük, stb.)

## Játék folyamata

### Main objective

Gödöllőn minél több 50 Ft-os visszaváltós palackot kell gyűjtened, majd végül biztonságosan el kell jutnod a Nemzeti Dohánybolt melletti RePont-hoz.

### Ellenség(ek)

Jelenleg egy típusú ellenséget tervezünk a játékba, az pedig a kisebbségi roma állampolgár (köznyelven: *cigány*). Ezek az entitások a játék kezdetekor 5%-os eséllyel spawnolhatnak minden lépés után a játékos mellett közvetlenül vertikálisan vagy horizontálisan (átlósan nem) megtalálható egyik négyzetre. Ha a játékos felvesz egy visszaváltós palackot, ezen entitások spawn rate-je 5%-al nő.

#### Interakciók az ellenséggel

3 lehetséges interakció közül választhatsz, ha beléd köt egy ellenség:

1. Megtámadom: zsebkés nélkül (ököllel) a játékosnak 20% esélye van, hogy legyőzi az ellenséget. Zsebkéssel a támadás sikerességének esélye 75%-ra nő.
2. Elfutok: 80% esélye van a játékosnak elfutáskor, hogy sikeresen meneküljön anélkül, hogy az ellenség utolérné.
3. Beszólok neki: ezen opció választása gyakorlatilag öngyilkosság, mivel a beszólás után még 10 db ugyan olyan entitás fog spawnolni a játékos köré és onnan nincs menekvés, game over.

### Item-ek

- Az egyik, leggyakoribb item a fent említett 50 Ft-os palack. Ezekből a játékosnak minél többet kell gyűjtenie.
- A másik, kevésbé gyakori item a zsebkés. Ez segít az ellenségek legyőzésében felvétele után, viszont használat után hajlamos eltörni.
