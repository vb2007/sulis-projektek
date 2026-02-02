import "@assets/app.css";
import { findCarByPlate } from "./data/cars.js";

const main = document.getElementById("main");
const errorElement = document.getElementById("error");
const resetButton = document.getElementById("reset");
const searchInput = document.getElementById("search");

function createStatCard({ label, value, valueClass = "" }) {
    const wrapper = document.createElement("div");
    wrapper.className = "rounded-xl bg-fuchsia-50 p-3";

    const dt = document.createElement("dt");
    dt.className =
        "text-xs font-semibold uppercase tracking-wide text-fuchsia-500";
    dt.textContent = label;

    const dd = document.createElement("dd");
    dd.className = `mt-1 font-medium text-fuchsia-900 ${valueClass}`.trim();
    dd.textContent = value;

    wrapper.append(dt, dd);

    return wrapper;
}

function createCarElement(car) {
    const { plate, brand, model, year } = car;

    const article = document.createElement("article");
    article.className =
        "rounded-2xl bg-white p-5 shadow-sm ring-1 ring-fuchsia-200";

    const h2 = document.createElement("h2");
    h2.className = "car-title text-base font-semibold text-fuchsia-900";
    h2.textContent = `${brand} ${model}`;

    const dl = document.createElement("dl");
    dl.className = "info mt-4 grid grid-rows-2 grid-cols-2 gap-3 text-sm";

    const yearCard = createStatCard({ label: "Year", value: year });
    const plateCard = createStatCard({ label: "Plate", value: plate });
    const ownerCard = createStatCard({
        label: "Owner",
        value: "Click here to show owner info",
    });

    ownerCard.addEventListener("click", (evt) => {
        const clickedElement = evt.currentTarget;
        clickedElement.remove();
    });

    dl.append(yearCard, plateCard, ownerCard);

    article.append(h2, dl);

    return article;
}

searchInput.addEventListener("input", () => {
    main.replaceChildren();

    findCarByPlate(searchInput.value)
        .then((car) => {
            errorElement.classList.add("hidden");
            const carElement = createCarElement(car);
            main.append(carElement);
        })
        .catch((err) => {
            const errorText = errorElement.querySelector("p");
            if (errorText) {
                errorText.textContent = err.message;
            }
            errorElement.classList.remove("hidden");
        });
});

resetButton.addEventListener("click", (evt) => {
    errorElement.classList.add("hidden");
    searchInput.value = "";
    main.replaceChildren();
});
