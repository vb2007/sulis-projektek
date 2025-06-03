import { usageData } from "./data.js";

const calculateUsage = (calcType) => {
    switch (calcType) {
        case "sum":
            return usageData.reduce((sum, item) => sum + item.usage, 0);
        case "avg":
            const totalUsage = usageData.reduce((sum, item) => sum + item.usage, 0);
            return Math.round(totalUsage / usageData.length * 100) / 100; //kerekítés 2 tizedesjegyre
        case "max":
            return Math.max(...usageData.map(item => item.usage));
        case "min":
            return Math.min(...usageData.map(item => item.usage));
        default:
            throw new Error("Invalid calculation type");
    }
}

const formattedCalculationType = (calcType) => {
    switch (calcType) {
        case "sum":
            return "Havi összesített használat: ";
        case "avg":
            return "Havi átlagos használat: ";
        case "max":
            return "Havi maximális használat: ";
        case "min":
            return "Havi minimális használat: ";
        default:
            throw new Error("Érvénytelen számítási típus");
    }
}

const renderCard = (day, calcType) => {
    const card = document.getElementById("card");
    card.classList.remove("hidden");

    const h3 = card.querySelector("h3");
    h3.textContent = `Használat a(z) ${day}. napon: ${usageData[day - 1].usage} MB`;

    const cardDiv = card.querySelector("div");
    cardDiv.innerHTML = "";

    const calculatedUsage = document.createElement("p");
    calculatedUsage.textContent = `${formattedCalculationType(calcType)} ${calculateUsage(calcType)} MB`;

    cardDiv.append(calculatedUsage);
}

const form = document.querySelector("form");
document.querySelector("button").addEventListener("click", (event) => {
    //visszahozza a html validációt (required, min, max, stb.)
    if (!form.checkValidity()) {
        return;
    }
    event.preventDefault();

    const day = document.getElementById("day").value;
    const calcType = document.getElementById("calcType").value;

    //habár napot mindenképpen kéne a felhasználónak választania a html validáció miatt, de azért ellenőrizzük mindkettő értéket...
    if (!day || !calcType) {
        alert("Kérlek válassz napot és számítási típust.");
        return;
    }

    renderCard(day, calcType);
});