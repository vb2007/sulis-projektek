"use strict"

let a3 = [];

while (true) {
    let temp = parseFloat(prompt("Add meg az árucikk árát."));
    if (isNaN(temp)) {
        break;
    }
    else {
        a3.push(temp);
    }
}

let sum = a3.reduce((acc, curr) => acc + curr, 0);
console.log(`A számok összege: ${sum}`);

let avg = sum / a3.length;
console.log(`A számok átlaga: ${avg.toFixed(2)}`);