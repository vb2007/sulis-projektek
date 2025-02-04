"use strict";

function randomFloat(alsoHatar = 69, felsoHatar = 420) {
    return (Math.random() * (felsoHatar - alsoHatar) + alsoHatar).toFixed(1);
}

let a = parseFloat(prompt("Add meg az alsó határt."));
let b;
while (true) {
    b = parseFloat(prompt("Add meg a felső határt."));
    if (a < b) {
        break;
    }
    else {
        alert("A felső határnak nagyobbnak kell lennie, mint az alsó határ!");
    }
}

alert(`A létrehozott random float: ${randomFloat(a, b)}`);