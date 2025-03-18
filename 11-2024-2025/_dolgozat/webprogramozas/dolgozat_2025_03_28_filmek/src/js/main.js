"use strict";

// Kártya törlése
function removeMovie(node) {
    node.remove();
}

//Fejléc és lábléc
const header = document.querySelector("header");
const h1 = document.createElement("h1");
h1.textContent = "Filmgyűjtemény";
h1.classList.add("text-3xl", "font-bold");
header.append(h1);

const footer = document.querySelector("footer");
const p = document.createElement("p");
p.textContent = "Készítette: Vágvölgyi Balázs";
footer.append(p);

//Kártyák
const container = document.getElementById("movies-container");

movies.forEach(movie => {
    const card = document.createElement("div");
    card.classList.add("bg-purple-900", "rounded-md", "p-2", "h-fit");

    const poster = document.createElement("img");
    poster.setAttribute("src", `src/images/${movie.poster}`);
    poster.setAttribute("alt", movie.title);
    poster.setAttribute("title", movie.title);
    poster.classList.add("w-full", "mb-2", "rounded-md");

    const title = document.createElement("h4");
    title.textContent = movie.title;
    title.classList.add("text-xl", "font-semibold");

    const genre = document.createElement("p");
    genre.textContent = movie.genre;
    genre.classList.add("italic", "text-purple-200");

    const rating = document.createElement("p");
    rating.textContent = `${movie.rating} ⭐`;

    const length = document.createElement("div");
    length.textContent = `${movie.runtime} perc`;
    const widthPercentage = (movie.runtime / 180) * 100;
    length.style.width = `${widthPercentage}%`;
    length.classList.add("bg-purple-200", "rounded-md", "p-1", "text-black", "font-bold", "mb-3");

    const deleteBtn = document.createElement("button");
    deleteBtn.textContent = "Törlés";
    deleteBtn.classList.add("bg-red-600", "rounded-md", "p-1", "cursor-pointer");

    card.append(poster, title, genre, rating, length, deleteBtn);
    container.append(card);
});

//Táblázat
const tbody = document.querySelector("tbody");

const averageLength = tbody.querySelector("tr:nth-child(1) td:nth-child(2)");
const averageLengthData = movies.reduce((sum, movie) => sum + movie.runtime, 0) / movies.length;
averageLength.textContent = `${averageLengthData} perc`;

const averageRating = tbody.querySelector("tr:nth-child(2) td:nth-child(2)");
const averageRatingData = movies.reduce((sum, movie) => sum + movie.rating, 0) / movies.length;
averageRating.textContent = averageRatingData;

const averageComedyLength = tbody.querySelector("tr:nth-child(3) td:nth-child(2)");
const comedyMovies = movies.filter(movie => movie.genre == "vígjáték");
const averageComedyLengthData = comedyMovies.reduce((sum, movie) => sum + movie.runtime, 0) / comedyMovies.length;
averageComedyLength.textContent = `${averageComedyLengthData} perc`;

const titleByHighestRating = tbody.querySelector("tr:nth-child(4) td:nth-child(2)");
const highestRatedMovie = movies.reduce((max, movie) => movie.rating > max.rating ? movie : max, movies[0]);
titleByHighestRating.textContent = highestRatedMovie.title;

// Az itt található kódot NE módosítsa, saját kódját fölé írja!
document.querySelectorAll('button').forEach(button => button.addEventListener('click', () => removeMovie(button.parentElement)));
