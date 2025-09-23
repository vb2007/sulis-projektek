"use strict";

const header = document.getElementById("header");

const title = () => {
  const h1 = header.getElementsByTagName("h1")[0];

  const title = h1 ? h1.textContent : "Ismeretlen";

  let p = document.createElement("p");
  p.textContent("Cím: ");

  let span = document.createElement("span");
  span.textContent = title;

  p.append(span);
  return p;
};
