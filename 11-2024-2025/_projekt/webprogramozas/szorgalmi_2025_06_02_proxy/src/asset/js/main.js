import { usageData } from "./data";

const renderCard = (day, calcType) => {
    const card = document.getElementById("card");

    const h3 = card.querySelector("h3");


    const cardDiv = card.querySelector("div");
    cardDiv.innerHTML = "";

    const dailyUsage = document.createElement("p");
    dailyUsage.textContent = usageData.find(item => item.date === day)?.usage || 0;

    const calculatedUsage = document.createElement("p");
    if (calcType === "average") {
        const totalUsage = usageData.reduce((sum, item) => sum + item.usage, 0);
        const averageUsage = totalUsage / usageData.length;
        calculatedUsage.textContent = `Average Usage: ${averageUsage.toFixed(2)}`;
    } else if (calcType === "max") {
        const maxUsage = Math.max(...usageData.map(item => item.usage));
        calculatedUsage.textContent = `Max Usage: ${maxUsage}`;
    } else if (calcType === "min") {
        const minUsage = Math.min(...usageData.map(item => item.usage));
        calculatedUsage.textContent = `Min Usage: ${minUsage}`;
    }

    cardDiv.append(dailyUsage, calculatedUsage);
}

document.querySelector("button").addEventListener("click", (event) => {
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