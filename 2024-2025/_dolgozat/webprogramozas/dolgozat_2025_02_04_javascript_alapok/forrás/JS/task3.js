"use strict";

function sortArr(arr=[2, 5, 3, 7, 4]){
    return arr.sort(function(a, b){return a-b});
}
// nézze meg mit ad vissza a meghívás: console.log(sortArr())
//Innentől lefelé írjon

let lista = [];
let temp;

do {
    temp = prompt("Adj meg egy számot.");
    lista.push(parseInt(temp));
}
while (!isNan(temp));

let szorzat = lista[0];
for (let i = 1; i < lista.length; i++) {
    szorzat = szorzat * lista[i];
}

console.log(`A számok szorzata: ${szorzat}`);

let szortirozott = sortArr(lista);
let szortirozottLength = szortirozott.length;
let median;

if (szortirozottLength % 2 == 0) {
    let felsoKozepIndex = szortirozottLength / 2;
    let alsoKozepIndex = felsoKozepIndex -1;
    median = (szortirozott[felsoKozepIndex] + szortirozott[alsoKozepIndex]) / 2;
}
else {
    let kozepsoIndex = Math.floor(szortirozottLength / 2);
    median = szortirozott[kozepsoIndex];
}

console.log(`A számok mediánja: ${median}`);
