# ByteFriend - Felhasználói Dokumentáció

## Áttekintés

A ByteFriend egy virtuális kisállat-gondozó szimulátor, lehetőséged van 3 különböző állat közül választani és felnevelni maximum 10 darabot egyszerre, egészen baba korától felnőttig. A játék "valós" (rendszeridőben) fog történni és végezni a számításokat.

## Menük

### Főmenü

Az alábbi menüpontokat lehet választani a menüben, sorrendben:

1. Új állatot tudsz csinálni, ha rányomsz a következő 3 állat közül tudsz választani: majom, aranyhal, macska. Kiválasztás után nevet is tudsz adni az állatodnak, ha egy állat már létezik a megadott névvel, új nevet kell adnod (az állat nevére gondolok)
2. Amennyiben már van minimum 1 megkezdett játékod, azt itt tudod betölteni és tovább játszani, maximum 10 állatod lehet
3. A "Segítség" menüpont arra van, ha valamit nem értenél a játék kezelőfelületével kapcsolatban **Itt keresd**
4. A játék elhagyását teszi lehetővé

### Halálképernyő

- Kiírja az életkort, ameddig élt a kiskedvenced
- Megjeleníti a fejlődési szakaszát, amiben meghalt
- Egy gomb megnyomása esetén visszatérsz a főmenübe

## Játéktér

### Univerzális

 - Minden állatnak kiírja fölül a nevét, aktuális életszakaszát és életkorát
 - Amennyiben az "Éhség" mérő eléri a 100-at, az állat meghal, ezt az "Etetés" opcióval lehet megakadályozni
 - A "Boldogság" mérő az állat elégedettségét méri, idővel ha nem törődsz vele és nem lépsz be a játékba elkezd lemenni
 - Az állat "Állapota" lehet "Egészséges" és "Beteg", ha beteg megjelenik egy "Gyógyítás" opció az alsó kiválasztható lehetőségek között
 - A "Mentés" opció lehetővé teszi a betöltést, amit elmentett egy külön JSON fájlban
 - A "Kilépés"-sel visszatérsz a főmenübe
 
### Majom

- Lehet banánnal is etetni
- A "Barátkozás" opcióval megy fel a boldogságmérője

### Aranyhal

- Az "Akvárium földhöz vágása" opció után sajnos (a képzeletbeli nyakán keresztül) nem kap levegőt és meghal
- Az "Akvárium takarítása" opcióval megy fel a boldogságmérője

### Macska

- A "Simogatás" és a "Szőr kefélése"  opciókkal a boldogságmérő és az éhségmérő is feljebb megy csak más értékekkel
