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

const generateTicketCards = () => {
  const cards = [];
};
generateTicketCards();

const generateFilmCards = () => {
  const cards = [];
  const mappedFilms = films;

  const images = [];
};
generateFilmCards();
