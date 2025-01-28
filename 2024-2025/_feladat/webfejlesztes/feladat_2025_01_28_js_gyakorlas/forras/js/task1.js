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
