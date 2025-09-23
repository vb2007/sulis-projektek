"use strict";

const headerEl = document.getElementById("header");
const dataEl = document.getElementById("data");

const title = () => {
  const h1 = headerEl.getElementsByTagName("h1")[0];
  const title = h1 ? h1.textContent : "Ismeretlen";

  const p = document.createElement("p");
  p.textContent("Cím: ");

  const span = document.createElement("span");
  span.textContent = title;

  p.append(span);
  return p;
};

const episodes = () => {
  let count = 0;
  let episodes = null;
  const listElements = document.getElementsByTagName("li");

  for (let i = 0; i < listElements.length; i++) {
    let strongs = listElements[i].getElementsByTagName("strong");

    if (strongs.length > 0) {
      const txt = strongs[0].textContent.trim();

      if ((txt = "Részek")) {
        episodes = listElements[i].getElementsByTagName("ul");
        break;
      }
    }
  }

  if (episodes) {
    count = episodes[0].getElementsByTagName("li").length;
  }

  const p = document.createElement("p");
  p.textContent = "Részek száma: ";

  const span = document.createElement("span");
  span.textContent = count;

  p.append(span);

  return p;
};

const pages = () => {
  let count = null;
  const listElements = document.getElementsByTagName("li");

  for (let i = 0; i < listElements.length; i++) {
    const strongs = listElements[i].getElementsByTagName("strong");

    if (strongs.length > 0) {
      const txt = strongs[0].textContent.trim();

      if (txt == "Oldalszám: ") {
        const spans = listElements[i].getElementsByTagName("span");

        if (spans.length > 0) {
          count = spans[0].textContent.trim();
          break;
        }
      }
    }
  }

  const p = document.createElement("p");
  p.textContent = "Első rész hossza: ";

  const span = document.createElement("span");
  span.textContent = count ? count : "Ismeretlen";

  p.append(span);

  return p;
};

const first = () => {
  let episodes = null;
  const listElements = document.getElementsByTagName("li");

  for (let i = 0; i < listElements.length; i++) {
    const strongs = listElements[i].getElementsByTagName("strong");

    if (strongs.length > 0) {
      const txt = strongs[0].textContent.trim();

      if (txt == "Részek") {
        const uls = listElements[i].getElementsByTagName("ul");
        if (uls.length > 0) {
          episodes = uls[0];
          break;
        }
      }
    }
  }

  if (episodes) {
    const items = episodes.getElementsByTagName("li");

    if (items.length > 0) {
      const firstItem = items[0];
      firstItem.classList.add("first");
    }
  }
};

const vdnh = () => {
  const li = document.createElement("li");
  li.textContent = "VDNH";

  const firstElement = stationsEl.firstElementChild;
  if (firstElement) {
    stationsEl.insertBefore(li, firstElement);
  }
};

const coverSwap = () => {
  const img = coverEl.getAttribute("src");

  if ((img = "2033.jpg")) {
    coverEl.setAttribute("src", "2033-new.jpg");
    coverEl.setAttribute("alt", "Metro 2033 új könyv borító");
    document.body.style.setProperty("--main-color", "#1b1b1b");
  } else {
    coverEl.setAttribute("src", "2033.jpg");
    coverEl.setAttribute("alt", "Metro 2033 könyv borító");
    document.body.style.setProperty("--main-color", "#005f5f");
  }
};
