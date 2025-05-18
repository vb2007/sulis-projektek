"use strict";

const artists = [
    { name: "Akkezdet Phiai", style: "rap-hiphop" },
    { name: "Cserihanna", style: "rap-hiphop" },
    { name: "Eminem", style: "rap-hiphop" },
    { name: "Krúbi", style: "rap-hiphop" },
    { name: "NKS", style: "rap-hiphop" },

    { name: "Fehér Krisztián", style: "electronic-experimental" },
    { name: "Keygen Church", style: "electronic-experimental" },
    { name: "VØJ", style: "electronic-experimental" },

    { name: "Gorillaz", style: "rock-alternative" },
    { name: "Ronnie Radke", style: "rock-alternative" },

    { name: "Alexandrov Kórus", style: "other" },
    { name: "Andrius Klimka", style: "other" },
    { name: "Halott Pénz", style: "other" }
];

const getStyleNameByValue = (styleValue) => {
    switch(styleValue) {
        case "rap-hiphop":
            return "Rap / Hip-Hop";
        case "electronic-experimental": 
            return "Elektronikus / Kísérleti";
        case "rock-alternative":
            return "Rock / Alternatív";
        case "other":
            return "Egyéb / Vegyes";
    }
}

const filterArtists = (style) => {
    return artists.filter(artist => artist.style === style);
};

const renderCard = (username, style) => {
    const card = document.getElementById("card");
    card.classList.add("active");
    card.style.display = "block";
    card.style.marginLeft = "auto";
    card.style.marginRight = "auto";

    const h3 = card.querySelector("h3");
    h3.textContent = `${username} zenei stílusa: ${getStyleNameByValue(style)}`;

    const cardDiv = card.querySelector("div");
    cardDiv.innerHTML = "";

    const img = document.createElement("img");
    img.src = `./src/img/${style}.jpg`;

    const ul = document.createElement("ul");
    let artists = filterArtists(style);

    artists.forEach(artist => {
        const li = document.createElement("li");
        li.textContent = artist.name;
        ul.append(li);
    });

    cardDiv.append(img, ul);
};

document.querySelector("button").addEventListener("click", (event) => {
    event.preventDefault();

    const name = document.getElementById("name").value;
    const style = document.getElementById("style").value;

    renderCard(name, style);
});