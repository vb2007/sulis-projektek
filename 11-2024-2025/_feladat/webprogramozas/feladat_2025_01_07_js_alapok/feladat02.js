"use strict"
//2. Feladat
for (let i = 1; i <= 100; i++) {
    console.log(`A(z) ${i} szám ${i % 2 == 0 ? "páros" : "páratlan"}`)
}

//3. + 4. Feladat
let a1
let b1

while (true) {
    a1 = prompt("Adj meg egy számot:")
    if (!isNaN(a1)) {
        a1 = parseFloat(a1)
        break
    } else {
        alert("Érvénytelen szám, próbáld újra!")
    }
}

while (true) {
    b1 = prompt("Adj meg még egy számot:")
    if (!isNaN(b1)) {
        b1 = parseFloat(b1)
        break
    } else {
        alert("Érvénytelen szám, próbáld újra!")
    }
}

alert(`A két szám összege: ${parseFloat(a1) + parseFloat(b1)}`)

//5. Feladat
const pi = Math.PI

//6. Feladat
let radius

while (true) {
    radius = prompt("Add meg egy körnek a sugarát:")
    if (!isNaN(radius)) {
        radius = parseFloat(radius)
        break
    } else {
        alert("Érvénytelen szám, próbáld újra!")
    }
}

console.log(`A kör kerülete: ${2 * radius * pi}`)
console.log(`A kör területe: ${radius ** 2 * pi}`)

//7. Feladat
let month

while (true) {
    month = prompt("Add meg egy hónap számát:")
    if (isNaN(month)) {
        alert("Érvénytelen szám, próbáld újra!")
    }
    else if (month < 0 && month > 12) {
        alert("Érvénytelen hónap, próbáld újra! (1-12)")
    }
    else {
        switch (parseInt(month)) {
            case 1:
            case 2:
            case 12:
                alert("Ez egy téli hónap")
                break
            case 3:
            case 4:
            case 5:
                alert("Ez egy tavaszi hónap")
                break
            case 6:
            case 7:
            case 8:
                alert("Ez egy nyári hónap")
                break
            case 9:
            case 10:
            case 11:
                alert("Ez egy őszi hónap")
                break
            default:
                alert("Nem ismerem ezt a hónapot!")
        }
        break
    }
}

//8. Feladat
let lower
let upper

while (true) {
    lower = prompt("Adj meg egy alsó értéket:")
    upper = prompt("Adj meg egy felső értéket:")

    if (!isNaN(lower) && !isNaN(upper) && lower.trim() !== "" && upper.trim() !== "") {
        lower = parseFloat(lower);
        upper = parseFloat(upper);

        if (lower < upper) {
            break;
        } else {
            alert("Az alsó érték nem lehet nagyobb, vagy egyenlő, mint a felső érték.");
        }
    } else {
        alert("Érvénytelen szám, próbáld újra!");
    }
}

let count = 0;
let sum = 0;
let product = 1;

for (let i = lower; i <= upper; i++) {
    count++;
    sum += i;
    product *= i;
}

let average = sum / count;

alert(`A két szám közötti számok száma: ${count}`);
alert(`A két szám közötti számok összege: ${sum}`);
alert(`A két szám közötti számok átlaga: ${average}`);
alert(`A két szám közötti számok szorzata: ${product}`);