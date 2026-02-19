import { getProduct } from "./products.js";
import { openProductDialog } from "./dialogs.js";

export const generateProductCard = (product) => {
    const template = document.getElementById("product-card");
    const card = template.content.cloneNode(true);

    const image = card.querySelector(".image");
    image.src = product.image;
    image.alt = product.name;

    card.querySelector(".name").textContent = product.name;
    card.querySelector(".volume").textContent = product.volume;

    card.querySelector(".price").textContent = product.price.toLocaleString(
        "de-DE",
        {
            style: "currency",
            currency: "EUR",
        },
    );

    const baseUnit = card.querySelector(".base-unit");
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

    const button = card.querySelector("button");
    button.addEventListener("click", async () => {
        const freshProduct = await getProduct(product.id);
        openProductDialog(freshProduct);
    });

    return card;
};
