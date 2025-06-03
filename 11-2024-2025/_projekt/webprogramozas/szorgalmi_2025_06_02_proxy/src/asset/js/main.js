import { usageData } from "./data.js";

const calculateUsage = (calcType) => {
    switch (calcType) {
        case "sum":
            return usageData.reduce((sum, item) => sum + item.usage, 0);
        case "avg":
            const totalUsage = usageData.reduce((sum, item) => sum + item.usage, 0);
            return totalUsage / usageData.length;
        case "max":
            return Math.max(...usageData.map(item => item.usage));
        case "min":
            return Math.min(...usageData.map(item => item.usage));
        default:
            throw new Error("Invalid calculation type");
    }
}

const renderCard = (day, calcType) => {
    const card = document.getElementById("card");
    card.classList.remove("hidden");

    const h3 = card.querySelector("h3");
    h3.textContent = `Usage Data for ${day}`;

    const cardDiv = card.querySelector("div");
    cardDiv.innerHTML = "";

    const dailyUsage = document.createElement("p");
    dailyUsage.textContent = usageData.find(item => item.date === day)?.usage || 0;

    const calculatedUsage = document.createElement("p");
    calculatedUsage.textContent = `A ${calcType} érték: ${calculateUsage(calcType)}`;

    cardDiv.append(dailyUsage, calculatedUsage);
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