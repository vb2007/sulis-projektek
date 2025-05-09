"use strict";

const belvaros = [
    345000, 289000, 310000, 275000, 320000, 295000, 340000, 360000, 280000, 300000,
    315000, 290000, 305000, 325000, 310000, 335000, 345000, 295000, 310000, 330000,
    285000, 320000, 300000, 310000, 335000, 290000, 305000, 315000, 340000, 300000
];

const andrassy = [
    340000, 295000, 310000, 325000, 300000, 315000, 330000, 285000, 320000, 305000,
    310000, 335000, 290000, 345000, 300000, 310000, 295000, 320000, 340000, 280000,
    300000, 315000, 290000, 305000, 325000, 310000, 335000, 345000, 295000, 310000
];

const vaci = [
    320000, 300000, 310000, 335000, 290000, 305000, 325000, 310000, 335000, 295000,
    340000, 280000, 300000, 315000, 280000, 305000, 325000, 310000, 335000, 345000,
    295000, 310000, 340000, 300000, 310000, 335000, 350000, 305000, 325000, 315000
];

const margit = [
    340000, 290000, 300000, 334000, 280000, 307000, 320000, 300000, 340000, 298000,
    330000, 290000, 310000, 310000, 290000, 320000, 320000, 280000, 325000, 355000,
    285000, 300000, 335000, 280000, 300000, 330000, 330000, 285000, 330000, 280000
];

const stores = {
    "Belváros": belvaros,
    "Andrássy": andrassy,
    "Váci": vaci,
    "Margit": margit
};

const sum = (arr) => {
    return arr.reduce((acc, curr) => acc + curr, 0);
};

const displayCard = (day, store) => {
    const monthData = stores[store];

    const card = document.getElementById("card");
    card.classList.remove("hidden");
    card.style.display = "block";
    card.style.marginLeft = "auto";
    card.style.marginRight = "auto";

    const img = card.querySelector("img");
    img.setAttribute("src", `src/images/${store}.jpg`);
    card.append(img);

    const cardBody = document.querySelector("#card-body");

    const h3 = document.createElement("h3");
    h3.textContent = store;
    h3.style.marginBottom = "0.5rem";

    const dailySales = document.createElement("p");
    dailySales.textContent = `Napi forgalom: ${monthData[day - 1]} Ft`;

    const monthlySales = document.createElement("p");
    monthlySales.textContent = `Havi forgalom: ${sum(monthData)} Ft`;

    cardBody.append(h3, dailySales, monthlySales);
};

document.querySelector("button").addEventListener("click", function(event) {
    event.preventDefault();

    const day = document.getElementById("day").value;
    const store = document.getElementById("store").value;

    displayCard(day, store);
});
