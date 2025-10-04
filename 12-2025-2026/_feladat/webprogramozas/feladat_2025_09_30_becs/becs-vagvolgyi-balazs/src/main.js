"use strict";

const buses = 166200000;
const ubahn = 352400000;
const trams = 273400000;

const walking = "32%: sétáló";
const publicTransit = "32%: tömegközelekedő";
const cycling = "10%: biciklista";
const driving = "26%: autós";

const passengers = document.getElementById("passengers");
passengers.textContent = `${Math.round(buses + ubahn + trams, 1) / 1000000} millió`;

const createBar = (width, text) => {
  const barWrapper = document.createElement("div");

  const bar = document.createElement("div");
  bar.classList.add("bar");
  bar.textContent = width;

  barWrapper.append(bar, text);

  return barWrapper;
};

const diagram = document.getElementById("diagram");
diagram.innerHTML = "";

const splitterString = "%: ";

const walkingSplit = walking.split(splitterString);
diagram.append(createBar(walkingSplit[0], walkingSplit[1]));

const publicTransitSplit = publicTransit.split(splitterString);
diagram.append(createBar(publicTransitSplit[0], publicTransitSplit[1]));

const cyclingSplit = cycling.split(splitterString);
diagram.append(createBar(cyclingSplit[0], cyclingSplit[1]));

const drivingSplit = driving.split(splitterString);
diagram.append(createBar(drivingSplit[0], drivingSplit[1]));
