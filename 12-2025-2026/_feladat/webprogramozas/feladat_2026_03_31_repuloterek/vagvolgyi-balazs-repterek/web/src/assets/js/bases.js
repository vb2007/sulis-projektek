import { fetchBases, createBase } from "./data.js";

const renderBases = async () => {
    const bases = await fetchBases();
    const tbody = document.querySelector("#baseTableBody");
    tbody.innerHTML = "";

    if (!bases || bases.length === 0) {
        const tr = document.createElement("tr");
        const td = document.createElement("td");
        td.setAttribute("colspan", "3");
        td.classList.add("p-10", "text-center", "text-slate-400");
        td.textContent = "Nincs adat az adatbázisban";
        tr.appendChild(td);
        tbody.appendChild(tr);
        return;
    }

    for (const base of bases) {
        const tr = document.createElement("tr");
        tr.classList.add("hover:bg-slate-50");

        const tdCity = document.createElement("td");
        tdCity.classList.add("px-6", "py-4");

        const cityNameDiv = document.createElement("div");
        cityNameDiv.classList.add("font-bold", "text-slate-800");
        cityNameDiv.textContent = base.city;

        const cityIdDiv = document.createElement("div");
        cityIdDiv.classList.add("text-xs", "text-slate-400", "font-mono");
        cityIdDiv.textContent = `#${base.id}`;

        tdCity.appendChild(cityNameDiv);
        tdCity.appendChild(cityIdDiv);

        const tdIcao = document.createElement("td");
        tdIcao.classList.add("px-6", "py-4");

        const icaoDiv = document.createElement("div");
        icaoDiv.classList.add("flex", "items-center");

        const icaoSpan = document.createElement("span");
        icaoSpan.classList.add(
            "bg-blue-100",
            "text-blue-700",
            "px-2",
            "py-1",
            "rounded",
            "font-mono",
            "text-sm",
            "font-bold",
        );
        icaoSpan.textContent = base.icao_airport_code;

        const runwaySpan = document.createElement("span");
        runwaySpan.classList.add("text-slate-400", "text-sm", "italic");
        runwaySpan.textContent = `${base.max_runway_length} m`;

        icaoDiv.appendChild(icaoSpan);
        icaoDiv.appendChild(runwaySpan);
        tdIcao.appendChild(icaoDiv);

        const tdAirline = document.createElement("td");
        tdAirline.classList.add("px-6", "py-4", "text-slate-600", "font-medium");
        tdAirline.textContent = base.airline ? base.airline.name : "";

        tr.appendChild(tdCity);
        tr.appendChild(tdIcao);
        tr.appendChild(tdAirline);
        tbody.appendChild(tr);
    }
};

const form = document.querySelector("#baseForm");
form.addEventListener("submit", async (e) => {
    e.preventDefault();

    const formData = new FormData(form);

    await createBase(formData);

    form.reset();
    await renderBases();
});

renderBases();
