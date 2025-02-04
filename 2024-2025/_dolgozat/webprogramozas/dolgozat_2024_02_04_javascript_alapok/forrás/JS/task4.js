"use strict";

let daysInWeek = ["hétfő", "kedd", "szerda", "csütörtök", "péntek", "szombat", "vasárnap"];

let index = prompt("Add meg egy nap sorszámát.");

if (index < 1 || index > 7) {
    alert("Érvénytelen nap.");
}
else {
    console.log(`A nap neve: ${daysInWeek[index - 1]}`);

    if (index == 6 || index == 7) {
        console.log("Hétvége");
    }
    else {
        console.log("Hétköznap");
    }

    if (index % 2 == 0) {
        console.log("A nap sorszáma páros.");
    }
    else {
        console.log("A nap sorszáma páratlan.");
    }
}
