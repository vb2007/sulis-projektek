"use strict";

const haziCica = [
    250, 280, 260, 240, 270, 255, 265, 275, 245, 260,
    250, 270, 255, 265, 260, 280, 275, 250, 260, 270,
    245, 265, 255, 260, 275, 250, 265, 270, 280, 260
];

const maineCoonCica = [
    320, 310, 325, 315, 330, 320, 340, 325, 315, 335,
    320, 330, 310, 325, 335, 315, 320, 330, 340, 310,
    325, 315, 335, 320, 330, 325, 340, 315, 330, 320
];

const sziamiCica = [
    290, 300, 285, 295, 280, 290, 305, 295, 285, 300,
    290, 280, 295, 305, 285, 290, 300, 280, 295, 310,
    285, 295, 300, 290, 285, 305, 295, 280, 300, 290
];

const getCatNameByValue = (value) => {
    switch(value) {
        case "hazi":
            return "Házi cica";
        case "mainecoon":
            return "Maine Goon cica";
        case "sziami":
            return "Sziámi cica";
    }
}

const getListByCatValue = (value) => {
    switch(value) {
        case "hazi":
            return haziCica;
        case "mainecoon":
            return maineCoonCica;
        case "sziami":
            return sziamiCica;
    }
}

const getDailyConsumption = (day, cat) => {
    const list = getListByCatValue(cat);
    return list[day - 1];
}

const minimum = (list) => {
    let minIndex = 0;
    let minValue = list[0];

    for (let i = 0; i < list.length; i++) {
        if (list[i] < minValue) {
            minValue = list[i];
            minIndex = i;
        }
    }
    
    return minIndex;
}

const updateCard = (day, cat) => {
    const card = document.getElementById("card");
    card.classList.remove("hidden");
    card.style.display = "block";
    card.style.marginLeft = "auto";
    card.style.marginRight = "auto";

    const img = card.querySelector("img");
    img.src = `./images/${cat}.jpg`;

    const details = document.getElementById("details");
    details.innerHTML = "";

    const h3 = document.createElement("h3");
    h3.style.marginBottom = "0.5rem";
    h3.textContent = getCatNameByValue(cat);

    const p1 = document.createElement("p");
    p1.textContent = `A cica táplálék fogyasztása a(z) ${day}. napon: ${getDailyConsumption(day, cat)} gramm.`;

    const p2 = document.createElement("p");
    const minList = getListByCatValue(cat);
    const minListIndex = minimum(minList);
    p2.textContent = `A cica a legkevesebbet a(z) ${minListIndex + 1}. napon evett: ${minList[minListIndex]} gramm.`;

    details.append(h3, p1, p2);
}

document.querySelector("button").addEventListener("click", (event) => {
    event.preventDefault();

    const day = document.getElementById("day").value;
    const cat = document.querySelector('input[name=cat]:checked').value;

    updateCard(day, cat);
});