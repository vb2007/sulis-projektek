"use strict"

const VAT = 0.27;

let a2 = prompt("Add meg az árucikk nevét.");
let b2;

while (true) {
    b2 = parseFloat(prompt("Add meg az árucikk árát."));
    if (isNaN(b2)) {
        alert("Ez nem egy érvényes szám.");
    }
    else {
        break;
    }
}

let arAFAval = b2 + b2 * VAT;

console.log(`A(z) ${a2} ára ÁFÁ-val: ${arAFAval} forint.`);