"use strict"

//1. Feladat
function randomSzamok(tomb = []) {
    if (tomb.length === 0) {
        for (let i = 0; i < 5; i++) {
            let randomNum = Math.floor(Math.random() * 100) + 1;
            tomb.push(randomNum);
        }
    }

    return tomb;
}

//2. Feladat
let tomb = randomSzamok([]);

function negyzetGyokok(tomb = []) {
    let gyokokTomb = [];
    for (let i = 0; i < tomb.length; i++) {
        let gyok = Math.sqrt(tomb[i]).toFixed(2);
        gyokokTomb.push(gyok);
    }
    
    return gyokokTomb;
}

console.log(negyzetGyokok(tomb));

//3. Feladat
function getMinMax(tomb = [], tipus) {
    let value;
    switch (tipus) {
        case "max":
            for (let i = 0; i < tomb.length; i++) {
                if (tomb[i] > value) {
                    value = tomb[i];
                }
            }
            return `Legnagyobb szám: ${value}`;
        case "min":
            for (let i = 0; i < tomb.length; i++) {
                if (tomb[i] < value) {
                    value = tomb[i];
                }
            }
            return `Legkisebb szám: ${value}`;
        default:
            console.error("Hibás típus paraméter.");
            break;
    }
}


