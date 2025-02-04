"use strict";

const DISCOUNT = 0.15;

let termekNeve = prompt("Add meg a termék nevét.");
let termekAra;

while (true) {
    termekAra = prompt("Add meg a termék eredeti árát.");
    if (!isNaN(termekAra)) {
        break;
    }
}

let kedvezmenyesAr = (termekAra - termekAra * DISCOUNT);

console.log(`${termekNeve} kedvezményes ára: ${Math.round(kedvezmenyesAr, 2)} forint`);