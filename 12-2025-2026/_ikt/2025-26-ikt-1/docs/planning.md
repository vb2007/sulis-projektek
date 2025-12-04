# Projektterv

## 1. Áttekintés

### Általános információk

- **Projekt neve**: Koboldüldözők
- **Projekt leírása**
  - A projekt természetes eseményeket szimulál egy konzol ablakban.
  - Célja, hogy az esetlegesen való életben is megjelenő problémákat, megoldásokat közelebb hozza a felhasználóihoz és megérttesse velük azok súlyosságát.

### Funkciók

- A program minden egyes indítás után egy bizonyos szintig randomizált szimulációt tár a felhasználó elé.
- A szimuláció egy .NET 9-es Console Appban implementált mátrix (rácsrendszer) segítségével van megjelenítve.
- Futás során különböző entitások különböző módon interaktálnak egymással (ez lent réstesebben ki van fejtve).

## 2. Szabályrendszer, modell

### Rácsrendszer működése

- A program egy **12x12**-es rácsrendszerben szimulálja az eseményeket.
- A rácsrendszer rögtön látható random generált entitásokkal indítás után.

### Fájlok, objektumok viselkedése

A szimulációban az alábbi objektumok fognak megjelenni:

- **Házak**
  - Ezekből 2 darab jelenik meg, egymástól minimum 4 négyzet távolságra.
  - Minden ház pontosan 2 négyzetet foglal el.
- **Pásztorok**
  - Ezekből 4 darab jelenik meg, 2-2 minden háznál.
  - Közvetlenül a házak melletti négyzetek jelennek meg.
  - Minden pásztor pontosan 1 négyzetet foglal el.
- **Barna koboldok**:
  - Ezek csapatosan (4-8 darab) jelennek meg a házaktól minimum 3 négyzet távolságra.
  - A minimum távolságon kívül bárhol megjelenhetnek a mátrixon.
  - Indítás után rögtön elindulnak egy védtelen pásztor háza felé megfenyegetni / kirabolni azt.
  - Háztól-házig járás közben pénzérméket gyűjtenek, amik hatására 2-4 utódot hoznak létre az anyagi körülményeknek köszönhetően.
  - Mindig együtt mozognak.
- **Zöld angyalok**:
  - Ezekből minden esetben **csak 2 darab** jelenik meg a mátrix **bal felső sarkában**.
  - Amint a koboldok egy házhoz érnek, megindulnak a ház felé.
  - Ha elérik a házat, elkezdik megsemmisíteni a koboldokat.

## 3. Architektúra

- A projekt **.NET 9**-ben lesz elkészítve.
- Tartalmazni fog:
  - Egy **Console App**-ot, ami függ a lent említett projekttől.
  - Egy **Class Library**-t.

- A Console App-ban nagyrészt function hívások lesznek a Class Library-ből, de lehet ott is lesz logika implementálva.
- A Class Library-ben lesznek implementálva az alábbi Class-ok tervei (OOP) és funkcionalitásuk:
  - Mátrixrendszer
  - Házak
  - Pénzérmék
  - Pásztorok
  - Barna koboldok
  - Zöld angyalok

## 4. Osztályok, entitások

- A felépítés és a főbb Class-ok a fenti bekezdésben már fel lettek sorolva.
- Lett készítve egy tervezett mappa & fájl struktúra [ezzel](https://ascii-tree-generator.com/) a tool-al.
- **Ez a struktúra a projekt fejlesztése közben valószínűleg változni fog.**

A projekt mappastruktúrája az alábbi:

```
Kobolduldozok/
├─ Kobolduldozok/
│  ├─ Program.cs
├─ KobolduldozokLib/
│  ├─ World/
│  ├─ ├─ Matrix.cs
│  ├─ Entities/
│  ├─ ├─ House.cs
│  ├─ ├─ Coin.cs
│  ├─ ├─ Farmer.cs
│  ├─ ├─ Kobold.cs
│  ├─ ├─ Angel.cs
```

## 5. Algoritmusok, konfliktuskezelés

- Framek-re lesz bontva a futási logika.
  - Jelenleg 1 másodpercenként fog frissülni a mátrix.
  - Ha ez túl lassú lesz:
    - Vagy a felhasználó által megszabhatók lesznek a framek (indítás után).
    - Vagy a frissítő function-ben ezt paraméterként lehet majd specifikálni.

Minden frissítésben az alábbi logika fog megvalósulni:

1. A barna koboldok közelítenek a legközelebbi ház felé, hogy megtámadják a védtelen fehér pásztorokat.
2. Háztól-házig mozgás közben aprópénzt gyűjtenek a földről. 2 érme felvétele után szaporodnak (+2-4 utód minimum).
3. A zöld angyalok a bal felső sarokban állnak, majd elindulnak a koboldok felé.
4. Ha az angyalok elérték a koboldokat, megsemmisítik őket.
5. Amennyiben túl sok kobold volt és az angyalok nem tudták mindet megsemmisíteni, azok megindulnak a következő ház felé.
6. Az angyalok elkezdik üldözni a koboldokat.
7. Amennyiben út közben nem sikerül nekik, a következő házhoz érve megsemmisítik az összeset.
8. A szimuláció akkor ér véget, mikor a zöld angyalok megtisztították a mátrixot a barna koboldoktól.
