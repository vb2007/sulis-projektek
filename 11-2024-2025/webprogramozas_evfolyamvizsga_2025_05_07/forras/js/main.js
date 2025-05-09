"use strict";

const budafokiUt = [
    3450000, 2890000, 3100000, 2750000, 3200000, 2950000, 3400000, 3600000, 2800000, 3000000,
    3150000, 2900000, 3050000, 3250000, 3100000, 3350000, 3450000, 2950000, 3100000, 3300000,
    2850000, 3200000, 3000000, 3100000, 3350000, 2900000, 3050000, 3150000, 3400000, 3000000
];

const kerepesiUt = [
    3400000, 2950000, 3100000, 3250000, 3000000, 3150000, 3300000, 2850000, 3200000, 3050000,
    3100000, 3350000, 2900000, 3450000, 3000000, 3100000, 2950000, 3200000, 3400000, 2800000,
    3000000, 3150000, 2900000, 3050000, 3250000, 3100000, 3350000, 3450000, 2950000, 3100000
];

const thokolyUt = [
    3200000, 3000000, 3100000, 3350000, 2900000, 3050000, 3250000, 3100000, 3350000, 2950000,
    3400000, 2800000, 3000000, 3150000, 2800000, 3050000, 3250000, 3100000, 3350000, 3450000,
    2950000, 3100000, 3400000, 3000000, 3100000, 3350000, 3500000, 3050000, 3250000, 3150000
];

const becsiUt = [
    3400000, 2900000, 3000000, 3340000, 2800000, 3070000, 3200000, 3000000, 3400000, 2980000,
    3300000, 2900000, 3100000, 3100000, 2900000, 3200000, 3200000, 2800000, 3250000, 3550000,
    2850000, 3000000, 3350000, 2800000, 3000000, 3300000, 3300000, 2850000, 3300000, 2800000
];


const sum = (list) => {
    // let sum;
    // list.forEach(element => {
    //     sum += element;
    // });

    return Math.sumPrecise(list);
}

const getValueFromListByIndex = (list, index) => {
    return list[index];
}

const getListByStoreName = (storeName) => {
    switch(storeName) {
        case "budafokiUt":
            return budafokiUt;
        case "kerepesiUt":
            return kerepesiUt;
        case "thokolyUt":
            return thokolyUt;
        case "becsiUt":
            return becsiUt;
    }
}

const updateCard = (day, store) => {
    const storeName = store + "Ut";
    const storeList = getListByStoreName(storeName);
    // console.log(storeList)
    // console.log(getValueFromListByIndex(storeList, day))
    // console.log(sum(storeList))

    const card = document.getElementById("card");
    card.classList.toggle("hidden");
    card.style.display = "grid";
    card.style.marginLeft = "auto";
    card.style.marginRight = "auto";

    const img = document.querySelector("#card img");
    img.setAttribute("src", `./images/${store}.jpg`);

    const h3 = document.createElement("h3");
    h3.textContent = store;
    h3.style.marginBlock = "0.5rem";

    const dailyIncome = document.createElement("p");
    dailyIncome.textContent = `Az áruház bevétele a(z) ${day}. napon: ${getValueFromListByIndex(storeList, day)} forint.`;

    const monthlyIncome = document.createElement("p");
    monthlyIncome.textContent = `Az áruház bevétele az egész hónapban: ${sum(storeList)} forint.`;

    const details = document.getElementById("details");
    details.appendChild(h3, dailyIncome, monthlyIncome);
}

const submitButton = document.querySelector("button");

submitButton.addEventListener("click", submitBtnClick, false);

function submitBtnClick(event) {
    event.preventDefault();

    const day = document.getElementById("day").value;
    const store = document.getElementById("store").value;

    updateCard(day, store);
};