import { createBicycle, updateBicycle, deleteBicycle } from "./bicycle.js";

const bicycleDialog = document.getElementById("bicycle-dialog");
const bicycleFormDialog = document.getElementById("bicycle-form-dialog");
const bicycleForm = document.getElementById("bicycle-form");
const confirmDialog = document.getElementById("confirm-dialog");

let bicyclesRef = [];

export const setBicyclesRef = (bicycles) => {
    bicyclesRef = bicycles;
};

export const formatPrice = (price) => {
    return price.toLocaleString("hu-HU", {
        style: "currency",
        currency: "HUF",
        maximumFractionDigits: 0,
    });
};

export const createCard = (bicycle) => {
    const template = document.getElementById("bicycle-card");
    const clone = template.content.cloneNode(true);

    const card = clone.querySelector(".card");
    card.dataset.id = bicycle.id;

    const h3 = clone.querySelector("h3");
    h3.textContent = `${bicycle.manufacturer}: ${bicycle.name}`;

    const img = clone.querySelector("img");
    img.src = `images/${bicycle.id}.jpg`;
    img.alt = bicycle.name;

    const p = clone.querySelector("p");
    p.textContent = formatPrice(bicycle.price);

    const detailsBtn = clone.querySelector(".details");
    detailsBtn.addEventListener("click", () => {
        updateBicycleDialog(bicycle);
        bicycleDialog.showModal();
    });

    const editBtn = clone.querySelector(".edit");
    editBtn.addEventListener("click", () => {
        showUpdateDialog(bicycle);
    });

    const deleteBtn = clone.querySelector(".delete");
    deleteBtn.addEventListener("click", () => {
        confirmDialog.dataset.id = bicycle.id;
        showConfirmDialog();
    });

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
            value: formatPrice(bicycle.price),
        },
    ];

    data.forEach((item) => {
        const li = document.createElement("li");

        const span = document.createElement("span");
        span.className = "font-semibold text-gray-800";
        span.textContent = item.label + " ";

        li.append(span, item.value);
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

    //radio gomb reset
    const radios = document.querySelectorAll("[name=sex]");
    radios.forEach((radio) => (radio.checked = false));

    bicycleFormDialog.showModal();
};

export const showUpdateDialog = (bicycle) => {
    bicycleFormDialog.dataset.id = bicycle.id;

    const h1 = bicycleFormDialog.querySelector("h1");
    h1.textContent = bicycle.name;

    document.getElementById("manufacturer").value = bicycle.manufacturer;
    document.getElementById("name").value = bicycle.name;
    document.getElementById("wheel_size").value = bicycle.wheel_size;
    document.getElementById("speed").value = bicycle.speed;
    document.getElementById("type").value = bicycle.type;
    document.getElementById("color").value = bicycle.color;
    document.getElementById("price").value = bicycle.price;

    const radios = document.querySelectorAll("[name=sex]");
    radios.forEach((radio) => {
        radio.checked = radio.value === bicycle.sex;
    });

    bicycleFormDialog.showModal();
};

export const showConfirmDialog = () => {
    confirmDialog.showModal();
};

document
    .getElementById("add-button")
    .addEventListener("click", showCreateDialog);

bicycleForm.addEventListener("submit", async (e) => {
    e.preventDefault();

    const selectedSex = document.querySelector("[name=sex]:checked");

    const bicycleData = {
        manufacturer: document.getElementById("manufacturer").value,
        name: document.getElementById("name").value,
        wheel_size: parseFloat(document.getElementById("wheel_size").value),
        speed: parseInt(document.getElementById("speed").value),
        sex: selectedSex ? selectedSex.value : "",
        type: document.getElementById("type").value,
        color: document.getElementById("color").value,
        price: parseInt(document.getElementById("price").value),
    };

    const dialogId = bicycleFormDialog.dataset.id;

    if (!dialogId) {
        try {
            const newBicycle = await createBicycle(bicycleData);
            bicyclesRef.push(newBicycle);
            generateCards(bicyclesRef);
            bicycleFormDialog.close();
        } catch (error) {
            console.error(
                `Hiba a kerékpár létrehozása során:\n\t${error.message}`,
            );
        }
    } else {
        try {
            bicycleData.id = parseInt(dialogId);
            const updatedBicycle = await updateBicycle(bicycleData);

            const index = bicyclesRef.findIndex(
                (b) => b.id === updatedBicycle.id,
            );
            if (index !== -1) {
                bicyclesRef[index] = updatedBicycle;
            }

            generateCards(bicyclesRef);
            bicycleFormDialog.close();
        } catch (error) {
            console.error(
                `Hiba a kerékpár módosítása során:\n\t${error.message}`,
            );
        }
    }
});

const closeButton = bicycleFormDialog.querySelector("button[type='button']");
if (closeButton) {
    closeButton.addEventListener("click", () => {
        bicycleFormDialog.close();
    });
}

const confirmDeleteBtn = confirmDialog.querySelector(".delete");
if (confirmDeleteBtn) {
    confirmDeleteBtn.addEventListener("click", async (e) => {
        e.preventDefault();

        const id = parseInt(confirmDialog.dataset.id);

        try {
            await deleteBicycle(id);

            const index = bicyclesRef.findIndex((b) => b.id === id);
            if (index !== -1) {
                bicyclesRef.splice(index, 1);
            }

            generateCards(bicyclesRef);
            confirmDialog.close();
        } catch (error) {
            console.error(`Hiba a kerékpár törlése során:\n\t${error.message}`);
        }
    });
}

const confirmCancelBtn = confirmDialog.querySelector(".cancel");
if (confirmCancelBtn) {
    confirmCancelBtn.addEventListener("click", () => {
        confirmDialog.close();
    });
}
