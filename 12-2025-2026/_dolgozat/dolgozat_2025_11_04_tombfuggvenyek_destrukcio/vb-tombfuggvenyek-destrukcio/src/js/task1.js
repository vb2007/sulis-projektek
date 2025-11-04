"use strict";

const contrainer = document.querySelector("#items-container");

const foods = [
  ["Gulyásleves", 1800],
  ["Roston csirke cézársalátával", 2400],
  ["Hortobágyi palacsinta", 2200],
  ["Mogyoró", 0],
];

const createItem = (name, price) => {
  const li = document.createElement("li");
  li.classList.add("item");

  const liName = document.createElement("span");
  liName.textContent = name;

  const liPrice = document.createElement("span");
  liPrice.classList.add("item-price");
  price == 0
    ? (liPrice.textContent = "ingyenes")
    : (liPrice.textContent = price);

  li.append(liName, liPrice);
  return li;
};

const items = foods.map(([name, price]) => createItem(name, price));
contrainer.replaceChildren(...items);
