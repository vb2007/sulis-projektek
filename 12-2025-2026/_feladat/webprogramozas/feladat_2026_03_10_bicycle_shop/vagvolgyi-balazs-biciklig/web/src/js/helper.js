import { createBicycle } from "./bicycle.js";

const bicycleDialog = document.getElementById("bicycle-dialog");
const bicycleFormDialog = document.getElementById("bicycle-form-dialog");
const bicycleForm = document.getElementById("bicycle-form");

export const fomatPrice = (price) => {
    return price.toLocaleString("hu-HU", {
        style: "currency",
        currency: "HUF",
        maximumFractionDigits: 0,
    });
};

export const createCard = (bicycle) => {
    const template = document.getElementById("bicycle-card");
    const clone = template.content.cloneNode(true);

    const card = clone.querySelector("*");
    card.dataset.id = bicycle.id;

    const h3 = clone.querySelector("h3");
    h3.textContent = `${bicycle.manufacturer}: ${bicycle.name}`;

    const img = clone.querySelector("img");
    img.src = `images/${bicycle.id}.jpg`;
    img.alt = `${bicycle.name}`;
    img.title = `${bicycle.name}`;

    const p = clone.querySelector("p");
    p.textContent = fomatPrice(bicycle.price);

    const details = clone.querySelector(".details");
    details.onclick = () => {
        updateBicycleDialog(bicycle);
        bicycleDialog.showModal();
    };

    return clone;
};

export const generateCards = (bicycles) => {
    const container = document.getElementById("bicycles");
    container.innerHTML = "";

    bicycles.forEach((bicycle) => {
        const card = createCard(bicycle);
        container.append(card);
    });
};

export const updateBicycleDialog = (bicycle) => {
    const h1 = bicycleDialog.querySelector("h1");
    h1.textContent = `${bicycle.manufacturer}: ${bicycle.name}`;

    const img = bicycleDialog.querySelector("img");
    img.src = `images/${bicycle.id}.jpg`;

    const ul = bicycleDialog.querySelector("ul");
    ul.innerHTML = "";

    const data = [
        {
            label: "Kerék méret:",
            value: `${bicycle.wheel_size} col`,
        },
        {
            label: "Váltó:",
            value: `${bicycle.speed} sebességes`,
        },
        {
            label: "Nem:",
            value: bicycle.sex,
        },
        {
            label: "Típus:",
            value: bicycle.type,
        },
        {
            label: "Szín:",
            value: bicycle.color,
        },
        {
            label: "Ár:",
            value: fomatPrice(bicycle.price),
        },
    ];

    data.forEach((value) => {
        const li = document.createElement("li");

        const span = document.createElement("span");
        span.className = "font-semibold text-gray-800";
        span.textContent = value.label + " ";

        li.append(span, value.value);
        ul.append(li);
    });
};

export const showCreateDialog = () => {
    bicycleFormDialog.dataset.id = "";

    const h1 = bicycleFormDialog.querySelector("h1");
    h1.textContent = "Új kerékpár";

    const fields = [
        "manufacturer",
        "name",
        "wheel_size",
        "speed",
        "type",
        "color",
        "price",
    ];

    fields.forEach((field) => {
        document.getElementById(field).value = "";
    });

    bicycleFormDialog.showModal();
};

document.getElementById("add-button").onclick = showCreateDialog;
bicycleForm.onsubmit = async (e) => {
    e.preventDefault();

    const bicycleData = {
        manufacturer: document.getElementById("manufacturer").value,
        name: document.getElementById("name").value,
        wheel_size: parseInt(document.getElementById("wheel_size").value),
        speed: parseInt(document.getElementById("speed").value),
        sex: document.getElementById("sex").value,
        type: document.getElementById("type").value,
        color: document.getElementById("color").value,
        price: parseInt(document.getElementById("price").value),
    };

    if (!bicycleData.dataset.id) {
        try {
            const newBicycle = await createBicycle(bicycleData);
            bicycles.push(newBicycle);
            generateCards(bicycles);
            bicycleFormDialog.close();
        } catch (error) {
            console.error(
                `Hiba a kerékpár létrehozása során:\n\t${error.message}`,
            );
        }
    }
};
