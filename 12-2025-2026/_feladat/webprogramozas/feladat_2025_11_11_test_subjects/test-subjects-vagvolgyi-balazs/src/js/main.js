"use strict";

const capitalize = (text) => {
  return text.toUpperCase().slice(0, 1) + text.substring(1);
};

const createTableRow = (subject) => {
  const row = document.createElement("tr");
  row.dataset.id = subject.id;

  const id = document.createElement("td");
  row.dataset.id = subject.id;

  const name = document.createElement("td");
  row.dataset.name = subject.name;

  const statusWraper = document.createElement("td");
  const status = document.createElement("span");
  status.textContent = capitalize(subject.status);
  status.classList.add(subject.status);

  statusWraper.append(status);

  row.append(id, name, statusWraper);
  return row;
};

const addEventListenersToRows = () => {
  table
    .querySelectorAll("tr")
    .forEach((x) =>
      x.addEventListener("click", (e) =>
        showSubject(subjects.find((y) => true)),
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

const showSubject = (subject) => {};

const filterSubjects = (name) => {};

const userProfile = {
  name: "Balázs Vágvölgyi",
  position: "Unemployed",
};

for (const key in userProfile) {
  document.getElementById(`profile--${key}`).textContent = userProfile[key];
}

document.querySelector("#search").addEventListener("submit", (e) => {
  e.preventDefault();
  fillTable(filterSubjects(document.querySelector("#name").value));
});
