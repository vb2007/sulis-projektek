"use strict";

const createSpan = (text, cssClasses) => {
  const span = document.createElement("span");
  span.textContent = text;

  cssClasses.foreach((cssClass) => span.classList.add(cssClass));

  return span;
};

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
