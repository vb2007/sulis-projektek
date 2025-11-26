import { offers, options } from "./data/data.js";

const createSortOptions = (options) => {
  const optionElements = [];

  options.forEach((option) => {
    const optionElement = document.createElement("option");
    optionElement.textContent = option.label;
    optionElement.value = option.value;

    optionElements.push(optionElement);
  });

  return optionElements;
};

const optionsDropdown = document.getElementById("sort-select");
optionsDropdown.append(...createSortOptions(options));

const isAvailable = (before, after) => {
  const current = Date.now();
  return before > current && after < current;
};
