//2. Feladat
for (let i = 1; i <= 100; i++) {
    console.log(`A(z) \"${i}\"szám ${i % 2 == 0 ? "páros" : "páratlan"}`)
}

//3. + 4. Feladat
let a1
let b1

while (true) {
    a1 = prompt("Adj meg egy számot:");
    if (!isNaN(a1) && a1.trim() !== "") {
        a1 = parseFloat(a1);
        break;
    } else {
        alert("Érvénytelen szám, próbáld újra!");
    }
}

while (true) {
    b1 = prompt("Adj meg még egy számot:");
    if (!isNaN(b1) && b1.trim() !== "") {
        b1 = parseFloat(b1);
        break;
    } else {
        alert("Érvénytelen szám, próbáld újra!");
    }
}

alert(`A két szám összege: ${parseFloat(a1) + parseFloat(b1)}`)
