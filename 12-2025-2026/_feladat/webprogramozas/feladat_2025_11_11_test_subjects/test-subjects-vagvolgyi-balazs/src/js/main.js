"use strict";

const capitalize = (text) => {
  return text.toUpperCase().slice(0, 1) + text.substring(1);
};

const userProfile = {
  name: "Balázs Vágvölgyi",
  position: "Unemployed",
};

for (const key in userProfile) {
  document.getElementById(`profile--${key}`).textContent = userProfile[key];
}

const createTableRow = (subject) => {
  const row = document.createElement("tr");
  row.dataset.id = subject.id;

  const id = document.createElement("td");
  id.textContent = subject.id;
  id.dataset.id = subject.id;

  const name = document.createElement("td");
  name.textContent = subject.name;
  name.dataset.name = subject.name;

  const statusWraper = document.createElement("td");
  const status = document.createElement("span");
  status.textContent = capitalize(subject.status);
  status.classList.add(subject.status);

  statusWraper.append(status);

  row.append(id, name, statusWraper);
  return row;
};

const showSubject = (subject) => {
  for (const key in subject) {
    const element = document.querySelector(
      `div#current-subject--info #current‑subject‑‑${key}`,
    );

    switch (key) {
      case "status":
        element.textContent = capitalize(subject[key]);
        element.classList.remove("alive", "terminated");
        element.classList.add(key);

        break;
      case "traits":
        let traitsArray = [];
        for (const trait in subject[key]) {
          const span = document.createElement("span");
          span.textContent = trait;
          traitsArray.push(span);
        }

        element.replaceChildren(traitsArray);

        break;
      default:
        element.textContent = subject[key];
        break;
    }
  }
};

const addEventListenersToRows = () => {
  table
    .querySelectorAll("tr")
    .forEach((x) =>
      x.addEventListener("click", (e) =>
        showSubject(subjects.find((y) => y.id == x.dataset.id)),
      ),
    );
};

const fillTable = (array) => {
  const rows = [];
  for (const subject of array) {
    rows.push(createTableRow(subject));
  }

  table.replaceChildren(...rows);
  addEventListenersToRows();
};

const table = document.querySelector("#list-of-subjects tbody");
fillTable(subjects);

const filterSubjects = (name) => {
  return subjects.filter((subject) =>
    subject.name.toLowerCase().includes(name.toLowerCase()),
  );
};

document.querySelector("#search").addEventListener("submit", (e) => {
  e.preventDefault();
  fillTable(filterSubjects(document.querySelector("#name").value));
});
