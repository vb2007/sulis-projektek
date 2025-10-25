"use strict";

const createSpan = (text, cssClasses = []) => {
  const span = document.createElement("span");
  span.textContent = text;

  cssClasses.forEach((cssClass) => span.classList.add(cssClass));

  return span;
};

const filmCountElement = document.getElementById("film-count");
filmCountElement.innerHTML = "";
const filmCountSpan = createSpan(`${films.length} film`, ["text-lg"]);
filmCountElement.append(filmCountSpan);

//feladatleírás itt is "film‑count"-ot írt, gondolom elírás
const filmLengthElement = document.getElementById("film-length");
filmLengthElement.innerHTML = "";
const filmLengthSpan = createSpan(`${films.length * 120} órányi élmény`, [
  "text-lg",
  "astrict",
]);
filmLengthElement.append(filmLengthSpan);

const sortedTickets = [...tickets].sort((a, b) => a[2] - b[2]);
const [name, type, price] = sortedTickets[0];

const cheapestTicketPriceElement = document.getElementById(
  "cheapest-ticket-price",
);
cheapestTicketPriceElement.innerHTML = "";
const cheapestPriceSpan = createSpan(`${price} forinttól`, [
  "text-lg",
  "double-astrict",
]);
cheapestTicketPriceElement.append(cheapestPriceSpan);

const cheapestTicketDetailsElement = document.getElementById(
  "cheapest-ticket-details",
);
const ticketDetailsSpan = createSpan(`${name} (${type})`, []);
cheapestTicketDetailsElement.append(ticketDetailsSpan);

const capitalize = (string) => {
  const [firstChar, ...restChars] = string;
  return firstChar.toUpperCase() + restChars.join("");
};

const createTicketCard = (name, type, price) => {
  const div = document.createElement("div");
  div.classList.add("ticket-card");

  const h3 = document.createElement("h3");
  h3.textContent = capitalize(name);

  const p1 = document.createElement("p");
  p1.textContent = type;
  p1.classList.add("ticket-type");

  const p2 = document.createElement("p");
  p2.textContent = `${price} forint`;
  p2.classList.add("ticket-price");

  div.append(h3, p1, p2);
  return div;
};

const generateTicketCards = () => {
  const cards = [];

  tickets.forEach((ticket) => {
    const [name, type, price] = ticket;
    const card = createTicketCard(name, type, price);
    cards.push(card);
  });

  const ticketsElement = document.getElementById("tickets");
  ticketsElement.replaceChildren(...cards);
};
generateTicketCards();

const createFilmCard = (name, image) => {
  const div = document.createElement("div");
  div.classList.add("film-card");

  const img = document.createElement("img");
  img.src = image;
  img.alt = name;

  const h3 = document.createElement("h3");
  h3.textContent = name;

  div.append(img, h3);
  return div;
};

const generateFilmCards = () => {
  const mappedFilms = films.map((film) => [
    film,
    `./src/assets/images/${film.replace(/ /g, "_")}.jpeg`,
  ]);

  const cards = [];

  const topFilms = mappedFilms.splice(0, 3);
  for (const [name, image] of topFilms) {
    const card = createFilmCard(name, image);
    cards.push(card);
  }

  const filmsElement = document.getElementById("films");
  filmsElement.replaceChildren(...cards);

  const images = [];

  const remainingFilms = mappedFilms.splice(0);
  for (const [name, image] of remainingFilms) {
    const img = document.createElement("img");
    img.src = image;
    images.push(img);
  }

  const otherFilmsElement = document.getElementById("other-films");
  otherFilmsElement.replaceChildren(...images);
};
generateFilmCards();
