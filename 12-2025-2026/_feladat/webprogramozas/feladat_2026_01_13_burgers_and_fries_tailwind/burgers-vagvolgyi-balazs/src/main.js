import "./assets/app.css";
import { getFoodList, getToppings } from "./assets/data/foods.js";

const container = document.querySelector(".container");

function createGroup({ title = null, description = null, items = [] }) {
    const articleEl = document.createElement("article");
    articleEl.className = "grid";

    const titleEl = document.createElement("h1");
    titleEl.className =
        "font-bold uppercase text-xl text-center text-red-700 py-4";
    titleEl.textContent = title;
    articleEl.append(titleEl);

    if (null !== description) {
        const descriptionEl = document.createElement("p");
        descriptionEl.className = "-mt-4 mb-4 italic text-center";
        descriptionEl.textContent = description;
        articleEl.append(descriptionEl);
    }

    const ul = document.createElement("ul");
    ul.className = "mt-auto";

    for (const item of items) {
        const liEl = document.createElement("li");
        liEl.className = "flex flex-row justify-between mb-1";

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
    titleEl.className =
        "font-bold uppercase text-xl text-center text-red-700 py-4";
    titleEl.textContent = "Toppings";

    const ulEl = document.createElement("ul");
    ulEl.className = "flex flex-row flex-wrap justify-center gap-2";

    for (let topping of getToppings()) {
        const liEL = document.createElement("li");
        liEL.className =
            "px-4 py-2 uppercase border border-red-700 text-red-700 hover:bg-red-700 hover:text-red-100 cursor-pointer";
        liEL.textContent = topping;
        ulEl.append(liEL);
    }
    toppingsEl.append(titleEl, ulEl);
    return toppingsEl;
}

const foodList = getFoodList();
const foodsEl = document.createElement("div");
foodsEl.className = "grid gap-4 md:grid-cols-2 xl:grid-cols-4 px-4";

foodsEl.append(
    ...Object.keys(foodList).map((group) => createGroup(foodList[group])),
);

container.replaceChildren(foodsEl, createToppings());
