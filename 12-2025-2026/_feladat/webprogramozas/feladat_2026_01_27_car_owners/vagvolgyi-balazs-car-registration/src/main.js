import "@assets/app.css";

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

function createCarElement({ plate, brand, model, year }) {
    // const el = carTemplate.content.cloneNode(true)

    const article = document.createElement("article");
    article.className =
        "rounded-2xl bg-white p-5 shadow-sm ring-1 ring-fuchsia-200";

    const h2 = document.createElement("h2");
    h2.className = "car-title text-base font-semibold text-fuchsia-900";
    h2.textContent = `${brand} ${model}`;

    const dl = document.createElement("dl");
    dl.className = "info mt-4 grid grid-rows-2 grid-cols-2 gap-3 text-sm";

    // ...
}

resetButton.addEventListener("click", (evt) => {
    errorElement.classList.add("hidden");
    searchInput.value = "";
    main.replaceChildren();
});
