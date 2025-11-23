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
  artistsSpan.textContent = artists.join(", ");
  artistsSpan.title = artists.join(", ");

  card.append(img, nameSpan, artistsSpan);

  card.addEventListener("click", () => {
    selectTrack(object);
  });
  return card;
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
const generatePaginator = () => {
  const totalPages = Math.ceil(tracks.length / ITEMS_PER_PAGE);
  paginator.innerHTML = "";

  for (let i = 1; i <= totalPages; i++) {
    const pageLink = document.createElement("a");
    pageLink.textContent = i;

    pageLink.addEventListener("click", () => {
      tracksContainer.dataset.page = i;
      generateCards(i);
    });

    paginator.append(pageLink);
  }
};
generatePaginator();

const generateCards = (page) => {
  const startIndex = page * ITEMS_PER_PAGE - ITEMS_PER_PAGE;
  const endIndex = startIndex + ITEMS_PER_PAGE;

  const tracksToShow = tracks.slice(startIndex, endIndex);

  tracksContainer.innerHTML = "";
  tracksToShow.forEach((track) => {
    const card = createCard(track);
    tracksContainer.append(card);
  });
};
generateCards(1);

const selectTrack = (object) => {
  const { name, artists, image } = object;

  const playingCover = document.getElementById("playing--cover");
  playingCover.src = image;

  const playingTrack = document.getElementById("playing--track");
  playingTrack.textContent = name;

  const playingArtists = document.getElementById("playing--artists");
  playingArtists.textContent = artists.join(", ");
};

const filterTracks = (value) => {
  tracks = data.filter((track) => {
    return (
      track.name.toLowerCase().includes(value.toLowerCase()) ||
      track.artists.some((artist) =>
        artist.toLowerCase().includes(value.toLowerCase()),
      )
    );
  });

  generateCards(tracksContainer.dataset.page);
  generatePaginator();
};

const resultsText = document.querySelector("#number-of-results");
document.querySelector("#search").addEventListener("input", (e) => {
  filterTracks(e.currentTarget.value);
  resultsText.textContent = e.currentTarget.value
    ? `${tracks.length} találat a(z) "${e.currentTarget.value}" kifejezésre:`
    : "";
});
