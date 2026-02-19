import { getStore } from "./stores.js";

const openStoreDialog = (store) => {
    const dialog = document.getElementById("store-info");

    dialog.querySelector(".type").textContent = store.type;
    dialog.querySelector(".address").textContent = store.address;

    dialog.showModal();
};

export const openProductDialog = (product) => {
    const dialog = document.getElementById("product-info");

    const image = dialog.querySelector(".image");
    image.src = product.image;
    image.alt = product.name;

    dialog.querySelector(".category").textContent = product.category;
    dialog.querySelector(".brand").textContent = product.brand;
    dialog.querySelector(".name").textContent = product.name;
    dialog.querySelector(".volume").textContent = product.volume;

    dialog.querySelector(".price").textContent = product.price.toLocaleString(
        "de-DE",
        {
            style: "currency",
            currency: "EUR",
        },
    );

    const baseUnit = dialog.querySelector(".base-unit");
    const unitSpan = baseUnit.querySelector(".unit");
    const priceSpan = baseUnit.querySelector(".price");

    unitSpan.textContent = product.baseUnitPrice.unit;

    if (product.baseUnitPrice.price !== null) {
        priceSpan.textContent = product.baseUnitPrice.price.toLocaleString(
            "de-DE",
            {
                style: "currency",
                currency: "EUR",
            },
        );
    } else {
        priceSpan.textContent = "";
    }

    const storesList = document.getElementById("available-stores");
    storesList.innerHTML = "";

    product.availableStores.forEach((store) => {
        const li = document.createElement("li");
        li.textContent = store.name;
        li.classList.add("cursor-pointer");

        li.addEventListener("click", async () => {
            const freshStore = await getStore(store.id);
            openStoreDialog(freshStore);
        });

        storesList.appendChild(li);
    });

    dialog.showModal();
};
