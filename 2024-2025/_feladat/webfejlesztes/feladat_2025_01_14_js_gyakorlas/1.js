"use strict"

function randomSzamok(tomb = []) {
    if (tomb.length === 0) {
        for (let i = 0; i < 5; i++) {
            let randomNum = Math.floor(Math.random() * 100) + 1;
            tomb.push(randomNum);
        }
    }

    return tomb;
}

console.log(randomSzamok([]))