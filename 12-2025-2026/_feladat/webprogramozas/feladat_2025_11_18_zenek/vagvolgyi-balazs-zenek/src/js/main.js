"use strict";

const user = {
  username: "vbalazs",
  nickname: "Balázs",
};

//kifejezetten destrukciot kért, user.* nem elég
const { username, nickname } = user;

document.getElementById("username").textContent = username;
document.getElementById("nickname").textContent = nickname;

const createCard = (object) => {
  const { name, artists, image, explicit } = object;

  const card = document.createElement("div");
  card.classList.add("card");

  const img = document.createElement("img");
  img.classList.add("card--cover");
  img.src = image;

  const nameSpan = document.createElement("span");
  nameSpan.classList.add("card--track");
  nameSpan.textContent = name;
  nameSpan.title = name;

  const artistsSpan = document.createElement("span");
  explicit ?? artistsSpan.classList.add("card--explicit");
  artistsSpan.classList.add("card--artists");
  artistsSpan.textContent = artists.split(", ");
  artistsSpan.title = artists.split(", ");
};

const ITEMS_PER_PAGE = 20;

let tracks = [...data];

const tracksContainer = document.querySelector("#tracks");

document.querySelector("#next-page").addEventListener("click", (e) => {
  if (tracksContainer.dataset.page > data.length / ITEMS_PER_PAGE) return;
  tracksContainer.dataset.page = +tracksContainer.dataset.page + 1;
  generateCards(tracksContainer.dataset.page);
});

document.querySelector("#prev-page").addEventListener("click", (e) => {
  if (tracksContainer.dataset.page <= 1) return;
  tracksContainer.dataset.page = +tracksContainer.dataset.page - 1;
  generateCards(tracksContainer.dataset.page);
});

const paginator = document.querySelector("#page-numbers");
function generatePaginator() {}
generatePaginator();

function generateCards(page) {}
generateCards(1);

function filterTracks(value) {
  generateCards(tracksContainer.dataset.page);
  generatePaginator();
}

const resultsText = document.querySelector("#number-of-results");
document.querySelector("#search").addEventListener("input", (e) => {
  filterTracks(e.currentTarget.value);
  resultsText.textContent = e.currentTarget.value
    ? `${tracks.length} találat a(z) "${e.currentTarget.value}" kifejezésre:`
    : "";
});
