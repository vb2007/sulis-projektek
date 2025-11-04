"use strict";

const capitalize = (text) => {
  const [first, ...rest] = text;
  return first.toUpperCase() + rest.join("");
};

const paragraphs = document.querySelectorAll("p");
paragraphs.forEach((p) => {
  p.textContent = p.textContent
    .split(" ")
    .filter((word) => word.length > 0)
    .map(capitalize)
    .join(" ");
});
