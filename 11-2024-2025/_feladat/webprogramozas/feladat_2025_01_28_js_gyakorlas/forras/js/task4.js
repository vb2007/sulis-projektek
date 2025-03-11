"use strict"

let months = ["január", "február", "március", "április", "május", "június", "július", "augusztus", "szeptember", "október", "november", "december"];
let month;

month = parseFloat(prompt("Add meg egy hónap számát."));
if (month > 12 || month < 1) {
    alert("Érvénytelen hónap!");
}
else {
    let monthName = months[month - 1];
    console.log(`A hónap neve ${monthName}`);

    let season;
    if (month === 12 || month <= 2) {
        season = "Téli";
    } else if (month >= 3 && month <= 5) {
        season = "Tavaszi";
    } else if (month >= 6 && month <= 8) {
        season = "Nyári";
    } else {
        season = "Őszi";
    }
    console.log(`${season} hónap`);

    let parity = (month % 2 === 0) ? "páros" : "páratlan";
    console.log(`A hónap sorszáma ${parity}.`);

    let days;
    if (month === 2) {
        days = 28;
    } else if ([4, 6, 9, 11].includes(month)) {
        days = 30;
    } else {
        days = 31;
    }
    console.log(`A hónap ${days} napos`);
}