"use strict";

// const main = document.querySelector("main");

// const form = document.createElement("form");

// const name = document.createElement("input");
// name.setAttribute("type", "text");
// name.setAttribute("required", "true");
// name.setAttribute("placeholder", "Név");
// form.append(name);

// const amount = document.createElement("input");
// amount.setAttribute("type", "number");
// amount.setAttribute("required", "true");
// amount.setAttribute("min", "1");
// amount.setAttribute("placeholder", "Darabszám");
// form.append(amount);

// const select = document.createElement("select");
// const placeholderOption = document.createElement("option");
// placeholderOption.setAttribute("value", "");
// placeholderOption.textContent = "Válassza ki a személyt...";
// select.append(placeholderOption);
// form.append(select);

// const dateInput = document.createElement("input");
// dateInput.setAttribute("type", "date");
// dateInput.setAttribute("required", "true");
// form.append(dateInput);

// const statuses = ["Nagyon rossz", "Rossz", "Közepes", "Jó", "Nagyon jó"];
// statuses.forEach((status, index) => {
//     const label = document.createElement("label");
//     const radio = document.createElement("input");

//     radio.setAttribute("type", "radio");
//     radio.setAttribute("name", "status");
//     radio.setAttribute("value", status);

//     if (index === 2) {
//         radio.setAttribute("checked", "true");
//     }

//     label.append(radio, document.createTextNode(status));
//     form.append(label);
// });

// const submitButton = document.createElement("button");
// submitButton.setAttribute("type", "submit");
// submitButton.textContent = "Felvétel";
// form.append(submitButton);

// main.append(form);

const peopleSelect = document.getElementById("person");

people.forEach(person => {
    const option = document.createElement("option");
    option.value = person;
    option.textContent = person;
    peopleSelect.append(option);
});

const tbody = document.querySelector("table tbody");

items.forEach(item => {
    const row = document.createElement("tr");

    const nameCell = document.createElement("td");
    nameCell.textContent = item.name;

    const qtyCell = document.createElement("td");
    qtyCell.textContent = item.qty;

    const personCell = document.createElement("td");
    personCell.textContent = item.person;

    const dateCell = document.createElement("td");
    const dateSpan = document.createElement("span");
    dateSpan.classList.add("tag");
    dateSpan.textContent = item.date;
    dateCell.append(dateSpan);

    const qualityCell = document.createElement("td");
    qualityCell.textContent = item.quality;

    row.append(nameCell, qtyCell, personCell, dateCell, qualityCell);
    tbody.append(row);
});

function validateForm() {
    const name = document.getElementById("name").value.trim();
    const quantity = parseInt(document.getElementById("quantity").value, 10);
    const person = document.getElementById("person").value;
    const date = document.getElementById("date").value.trim();
    const status = document.querySelector('input[name="status"]:checked');

    if (!name || !quantity || !person || !date || !status) {
        showError("Minden mezőt ki kell tölteni!");
        return false;
    }

    if (!people.includes(person)) {
        showError("A 'Bejegyezte' mező értéke érvénytelen!");
        return false;
    }

    if (quantity <= 0) {
        showError("A darabszámnak nagyobbnak kell lennie, mint 0!");
        return false;
    }

    if (date.length !== 10) {
        showError("A dátumnak pontosan 10 karakter hosszúnak kell lennie!");
        return false;
    }

    return true;
}

function showError(message) {
    const dialog = document.querySelector("dialog");
    dialog.querySelector("p").textContent = message;
    dialog.showModal();
}

document.querySelector("form").addEventListener("submit", (event) => {
    event.preventDefault();

    if (validateForm()) {
        const name = document.getElementById("name").value.trim();
        const quantity = parseInt(document.getElementById("quantity").value, 10);
        const person = document.getElementById("person").value;
        const date = document.getElementById("date").value.trim();
        const status = document.querySelector('input[name="status"]:checked').value;

        const newItem = { name, qty: quantity, person, date, quality: status };
        items.push(newItem);

        const tbody = document.querySelector("table tbody");
        const row = document.createElement("tr");

        const nameCell = document.createElement("td");
        nameCell.textContent = newItem.name;

        const qtyCell = document.createElement("td");
        qtyCell.textContent = newItem.qty;

        const personCell = document.createElement("td");
        personCell.textContent = newItem.person;

        const dateCell = document.createElement("td");
        const dateSpan = document.createElement("span");
        dateSpan.classList.add("tag");
        dateSpan.textContent = newItem.date;
        dateCell.append(dateSpan);

        const qualityCell = document.createElement("td");
        qualityCell.textContent = newItem.quality;

        row.append(nameCell, qtyCell, personCell, dateCell, qualityCell);
        tbody.append(row);

        document.querySelector("form").reset();
        document.querySelector('input[name="status"][value="Közepes"]').checked = true;
    }
});