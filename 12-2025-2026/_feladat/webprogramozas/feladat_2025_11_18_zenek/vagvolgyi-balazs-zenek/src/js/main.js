"use strict";

const user = {
  username: "vbalazs",
  nickname: "Balázs",
};

//kifejezetten destrukciot kért, user.* nem elég
const { username, nickname } = user;

document.getElementById("username").textContent = username;
document.getElementById("nickname").textContent = nickname;

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
