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

//prog tétellel:
function getMinMax1(tomb = [], tipus) {
    let value;
    switch (tipus) {
        case "max":
            value = Number.NEGATIVE_INFINITY;
            for (let i = 0; i < tomb.length; i++) {
                if (tomb[i] > value) {
                    value = tomb[i];
                }
            }
            return `Legnagyobb szám: ${value}`;
        case "min":
            value = Number.POSITIVE_INFINITY;
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

//min, max függvényekkel:
function getMinMax2(numbers, tipus) {
    if (tipus === "min") {
        return Math.min(...numbers);
    } else if (tipus === "max") {
        return Math.max(...numbers);
    } else {
        console.error("Hibás típus paraméter.");
    }
}

console.log(getMinMax1(tomb, "max"));
console.log(getMinMax1(tomb, "min"));

console.log(`Legnagyobb szám: ${getMinMax1(tomb, "max")}`);
console.log(`Legkisebb szám: ${getMinMax1(tomb, "min")}`);

//4. Feladat
function atlagSzamitas(tomb = []) {
    //for ciklus helyett
    let sum = tomb.reduce((acc, num) => acc + num, 0);
    let average = sum / tomb.length;
    return Math.round(average);
}

console.log(`Átlag: ${atlagSzamitas(tomb)}`)

//5. Feladat
function parosParatlan(tomb = []) {
    let paratlan = [];
    let paros = [];

    for (let i = 0; i < tomb.length; i++) {
        if (tomb[i] % 2 === 0) {
            paros.push(tomb[i])
        }
        else {
            paratlan.push([tomb[i]])
        }
    }

    console.log(`Páros számok: ${paros}`)
    console.log(`Páratlan számok: ${paratlan}`)
}

parosParatlan(tomb)

//6. Feladat
function hatvanyozas(tomb = []) {
    let hatvany = [];

    for (let i = 0; i < tomb.length; i++) {
        hatvany.push(Math.pow(tomb[i], 2));
    }

    return hatvany;
}

console.log(`Számok hatványai: ${hatvanyozas(tomb)}`)

//7. Feladat
function kategorizalas(tomb = []) {
    let alacsony = [];
    let kozepes = [];
    let magas = [];

    for (let i = 0; i < tomb.length; i++) {
        if (tomb[i] < 30) {
            alacsony.push(tomb[i]);
        } else if (tomb[i] >= 30 && tomb[i] <= 69) {
            kozepes.push(tomb[i]);
        } else {
            magas.push(tomb[i]);
        }
    }

    console.log(`Alacsony számok: ${alacsony}`);
    console.log(`Közepes számok: ${kozepes}`);
    console.log(`Magas számok: ${magas}`);
}

kategorizalas(tomb);