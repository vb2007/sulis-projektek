"use strict"

//1. Feladat
function random(alsohatar = 1, felsohatar = 10) {
    return Math.floor(Math.random() * (felsohatar - alsohatar + 1)) + alsohatar;
}

let a1 = parseInt(prompt("Add meg az alsó határt."));
let b1;

while (true) {
    b1 = prompt("Add meg a felső határt.");
    if (b1 < a1) {
        b1 = parseInt(b1);
        alert("A felső határ nem lehet kisebb, mint az alsó határ.");
    }
    else {
        break;
    }
}

alert(`A random szám: ${random(a1, b1)}`);

//2. Feladat
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

//3. Feladat