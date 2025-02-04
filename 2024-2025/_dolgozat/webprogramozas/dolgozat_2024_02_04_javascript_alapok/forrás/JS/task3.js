"use strict";

function sortArr(arr=[2, 5, 3, 7, 4]){
    return arr.sort(function(a, b){return a-b});
}
// nézze meg mit ad vissza a meghívás: console.log(sortArr())
//Innentől lefelé írjon

console.log(sortArr());

let lista = [];
let temp;

do {
    temp = prompt("Adj meg egy számot.");
    lista.push(parseInt(temp));
}
while (!isNan(temp));

console.log(lista);

let szorzat;
console.log(lista.length);
for (let i = 0; i < lista.length - 1; i++) {
    if (i == 0) {
        szorzat = lista[i] * lista[i + 1];
    }
    else {
        szorzat = szorzat * lista[i + 1];
    }
}

console.log(`A számok szorzata: ${szorzat}`);

let szortirozott = sortArr(lista);
let median;
if (szortirozott % 2 != 0) {
    median = szortirozott[szortirozott.length / 2];
}

console.log(`A számok mediánja: ${median}`);
