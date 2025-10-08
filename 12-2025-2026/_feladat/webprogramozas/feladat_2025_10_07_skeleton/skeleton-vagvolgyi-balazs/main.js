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
  return arr.map((num) => Math.round(Math.abs(num) / 3));
  //+ így lenne 1 tizedesjegyre fixen kerekítve
  //return arr.map((num) => Math.round(Math.abs(num) / 3).toFixed(1));
}

/**
 * Keresd meg azt az utolsó elemet a paraméterként kapott tömbben,
 * amelyik hárommal és öttel is osztható.
 */
function task03(arr) {
  const divisibleBy3And5 = arr.filter((num) => num % 3 == 0 && num % 5 == 0);
  return divisibleBy3And5.length > 0
    ? divisibleBy3And5[divisibleBy3And5.length - 1]
    : undefined;
}

/**
 * A paraméterben megadott tömbből add vissza annak az elemnek az indexét,
 * amelyik pontosan 5 karakter hosszú. Ha több ilyen is van akkor az első előfordulást.
 */
function task04(arr) {
  //ha a feladat a valós indexet kéri és nem a szemmel olvashatót (akkor +1 lenne)
  return arr.findIndex((num) => num.length == 5);
  //+ így adná vissza az értékét
  //const lengthIs5 = arr.filter((num) => num.length == 5);
  //return lengthIs5.length > 0 ? lengthIs5[0] : undefined;
}

/**
 * A paraméterben megadott tömbből válogasd ki a pozitív páros számokat.
 */
function task05(arr) {
  return arr.filter((num) => num > 0 && num % 2 == 0);
}
