import "./assets/app.css";
import { getFoodList, getToppings } from "./assets/data/foods.js";

const container = document.querySelector(".container");

function createGroup({ title = null, description = null, items = [] }) {
    const articleEl = document.createElement("article");

    const titleEl = document.createElement("h1");
    titleEl.textContent = title;
    articleEl.append(titleEl);

    if (null !== description) {
        const descriptionEl = document.createElement("p");
        descriptionEl.textContent = description;
        articleEl.append(descriptionEl);
    }

    const ul = document.createElement("ul");

    for (const item of items) {
        const liEl = document.createElement("li");

        const productEl = document.createElement("span");

        productEl.textContent = item.name;
        const priceEl = document.createElement("span");
        priceEl.textContent = item.price.toLocaleString("de-DE", {
            style: "currency",
            currency: "EUR",
        });

        liEl.append(productEl, priceEl);
        ul.append(liEl);
    }
    articleEl.append(ul);

    return articleEl;
}

function createToppings() {
    const toppingsEl = document.createElement("div");

    const titleEl = document.createElement("h1");
    titleEl.textContent = "Toppings";

    const ulEl = document.createElement("ul");

    for (let topping of getToppings()) {
        const liEL = document.createElement("li");
        liEL.textContent = topping;
        ulEl.append(liEL);
    }
    toppingsEl.append(titleEl, ulEl);
    return toppingsEl;
}

const foodList = getFoodList();
const foodsEl = document.createElement("div");

foodsEl.append(
    ...Object.keys(foodList).map((group) => createGroup(foodList[group])),
);

container.replaceChildren(foodsEl, createToppings());
