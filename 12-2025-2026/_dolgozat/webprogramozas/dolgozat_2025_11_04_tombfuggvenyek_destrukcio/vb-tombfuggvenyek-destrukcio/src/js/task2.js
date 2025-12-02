"use strict";

const products = [
  [
    "Macskaeledel",
    800,
    [
      5, 7, 3, 6, 7, 4, 8, 9, 6, 5, 4, 7, 8, 6, 5, 7, 9, 5, 4, 8, 6, 5, 7, 8, 9,
      5, 6, 7, 4, 8,
    ],
  ],
  [
    "Kutyaeledel",
    1200,
    [
      10, 12, 9, 8, 11, 10, 14, 12, 13, 11, 10, 9, 12, 10, 11, 13, 14, 12, 11,
      10, 13, 12, 11, 10, 9, 13, 12, 11, 10, 12,
    ],
  ],
  [
    "Kutyanyakörv",
    2500,
    [
      2, 3, 1, 2, 3, 2, 4, 3, 2, 1, 3, 2, 2, 3, 4, 3, 2, 1, 3, 2, 4, 3, 2, 3, 2,
      1, 4, 2, 3, 2,
    ],
  ],
  [
    "Macskajáték",
    1500,
    [
      6, 7, 5, 6, 8, 7, 6, 5, 8, 7, 6, 5, 7, 8, 6, 5, 7, 8, 6, 5, 7, 8, 6, 5, 7,
      8, 6, 5, 7, 8,
    ],
  ],
  [
    "Haleleség",
    600,
    [
      8, 9, 7, 8, 9, 8, 7, 9, 8, 9, 8, 7, 9, 8, 7, 9, 8, 9, 7, 8, 9, 8, 7, 8, 9,
      8, 7, 9, 8, 7,
    ],
  ],
  [
    "Madáreleség",
    900,
    [
      5, 6, 5, 6, 5, 6, 7, 6, 5, 6, 5, 7, 6, 5, 6, 7, 6, 5, 6, 7, 6, 5, 6, 7, 5,
      6, 7, 6, 5, 7,
    ],
  ],
  [
    "Terrárium lámpa",
    4500,
    [
      1, 1, 0, 2, 1, 1, 1, 2, 1, 0, 2, 1, 1, 2, 1, 0, 2, 1, 1, 2, 1, 1, 0, 2, 1,
      1, 1, 2, 0, 1,
    ],
  ],
  [
    "Akvárium szűrő",
    8000,
    [
      1, 0, 1, 1, 2, 1, 1, 1, 0, 2, 1, 1, 1, 0, 1, 2, 1, 1, 0, 2, 1, 1, 1, 0, 2,
      1, 1, 1, 2, 1,
    ],
  ],
  [
    "Macskakarom-vágó",
    2200,
    [
      3, 2, 2, 3, 2, 4, 3, 2, 3, 2, 4, 3, 2, 3, 2, 4, 3, 2, 3, 2, 4, 3, 2, 3, 2,
      4, 3, 2, 3, 2,
    ],
  ],
  [
    "Kutyafésű",
    1800,
    [
      4, 5, 3, 4, 5, 4, 3, 5, 4, 3, 5, 4, 3, 4, 5, 4, 3, 5, 4, 3, 5, 4, 3, 5, 4,
      3, 4, 5, 4, 3,
    ],
  ],
  [
    "Hörcsögketrec",
    9500,
    [
      1, 1, 2, 0, 1, 1, 1, 2, 1, 0, 2, 1, 1, 1, 2, 0, 1, 1, 1, 2, 0, 1, 1, 2, 1,
      1, 1, 0, 2, 1,
    ],
  ],
  [
    "Madárkalitka",
    11000,
    [
      1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1,
      0, 1, 1, 0, 1,
    ],
  ],
];

const convertToHuf = (number) => {
  return `${number.toLocaleString("hu-HU")} FT`;
};

const createTableRow = (name, sum) => {
  const row = document.createElement("tr");

  for (const field of [name, sum]) {
    const cell = document.createElement("td");
    cell.textContent = !isNaN(+field) ? convertToHuf(field) : field;
    row.append(cell);
  }

  return row;
};

const createCard = (text, classes = []) => {
  const card = document.createElement("span");
  card.textContent = text;
  card.classList.add("card", ...classes);

  return card;
};

const averageSales = document.querySelector("#average-sales tbody");
const lowIncome = document.querySelector("#low-income > div");
const topPerformers = document.querySelector("#top-performers > div");
const overallIncome = document.querySelector("#overall-income span");
const findProduct = document.querySelector("#find-product span");

const mapped = products.map(([name, price, sales]) => {
  const totalRevenue =
    price * sales.reduce((sum, quantity) => sum + quantity, 0);

  return [name, price, sales, totalRevenue];
});

mapped.forEach(([name, , , revenue]) => {
  const row = createTableRow(name, revenue);
  averageSales.append(row);
});

const low = mapped.filter(([, , , revenue]) => revenue < 150000);
low.forEach(([name]) => {
  const row = createCard(name);
  lowIncome.append(row);
});

const best3 = [...mapped]
  .sort(([, , , revenueA], [, , , revenueB]) => revenueB - revenueA)
  .slice(0, 3);
best3.forEach(([name, , , revenue]) => {
  const classes = revenue >= 400000 ? ["star", "better-star"] : ["star"];
  const topPerformer = createCard(name, classes);
  topPerformers.append(topPerformer);
});

const sum = mapped.reduce((sum, [, , , revenue]) => sum + revenue, 0);
overallIncome.textContent = convertToHuf(sum);

document.querySelector("#find-product form").addEventListener("submit", (e) => {
  e.preventDefault();
  search(document.querySelector("#name").value);
});

// Javasolt megoldását ide írnia:

const search = (name) => {
  const product = mapped.find(([productName]) => productName === name);
  findProduct.textContent = product ? convertToHuf(product[1]) : "-";
};
