/**
 * A paraméterben megadott tömb alapján számold ki,
 * hogy a tömben található szavaknak, mekkora az átlagos
 * hosszuk. Az átlag a függvény visszatérési értéke legyen.
 */
function task01(arr) {
  let wordsLengthTotal = 0;
  arr.forEach((word) => (wordsLengthTotal += word.length));
  return wordsLengthTotal / arr.length;
}

/**
 * A paraméterben kapott tömbben található számokat alakítsd át
 * úgy, hogy minden számra vedd az abszolút értékét és oszd el hárommal,
 * ezután az eredményt kerekítsd. Az így kapott tömb legyen a függvény visszatérési értéke.
 */
function task02(arr) {
  //+ kerekítés 1 tizedesjegyre
  return arr.map((num) => Math.round(Math.abs(num) / 3).toFixed(1));
}

/**
 * Keresd meg azt az utolsó elemet a paraméterként kapott tömbben,
 * amelyik hárommal és öttel is osztható.
 */
function task03(arr) {}

/**
 * A paraméterben megadott tömbből add vissza annak az elemnek az indexét,
 * amelyik pontosan 5 karakter hosszú. Ha több ilyen is van akkor az első előfordulást.
 */
function task04(arr) {}
/**
 * A paraméterben megadott tömbből válogasd ki a pozitív páros számokat.
 */
function task05(arr) {}
