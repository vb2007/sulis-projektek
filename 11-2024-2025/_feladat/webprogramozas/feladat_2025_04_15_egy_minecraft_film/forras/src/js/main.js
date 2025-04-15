"use strict"

const quotes = [
    {
        hu: 'Én, Steve vagyok!',
        en: 'I am Steve!',
        image: 'quotes/i_am_steve.png',
    },
    {
        hu: 'Csirke Zsoké!',
        en: 'Chicken Jockey!',
        image: 'quotes/chicken_jockey.png',
    },
    {
        hu: 'Tűz szerszám!',
        en: 'Flint and steel!',
        image: 'quotes/flint_and_steel.png',
    },
    {
        hu: 'Az Alvilág!',
        en: 'The Nether!',
        image: 'quotes/the_nether.png',
    },
    {
        hu: 'Ez egy barkácsasztal!',
        en: 'This is a crafting table!',
        image: 'quotes/crafting_table.png',
    },
    {
        hu: 'Forrá láva és csirke!',
        en: 'Hot lava and chicken!',
        image: 'quotes/hot_lava_and_chicken.png',
    },
    {
        hu: 'Gyémánt páncél, teljes szett!',
        en: 'Diamond armor, full set!',
        image: 'quotes/diamond_armor.png',
    },
    {
        hu: 'Kiengedés!',
        en: 'Release!',
        image: 'quotes/release.png',
    },
    {
        hu: 'Forrón jövök be!',
        en: 'Coming in hot!',
        image: 'quotes/coming_in_hot.png',
    },
];

const ticketsSold = [56, 34, 23, 45, 67, 89, 12, 34, 56, 78,];

const selectableLanguages = ['en', 'hu'];

const randomQuote = () => {
    let randomIndex = Math.floor(Math.random() * quotes.length);
    return quotes[randomIndex];
}

const displaySumOfTickets = (sum) => {
    const sumElement = document.getElementById('sum');
    sumElement.textContent = `Összesen eladott jegyek száma: ${sum}`;
};

let sum = 0;
for (let i = 0; i < ticketsSold.length; i++) {
    sum += ticketsSold[i];
}

displaySumOfTickets(sum);

const submitButton = document.querySelector("#quote button");

submitButton.addEventListener("click", function(event) {
    event.preventDefault();

    const name = document.getElementById("name").value;
    const selectedLanguage = document.getElementById("language").value;
    
    if (!selectableLanguages.includes(selectedLanguage)) {
        alert("Hiba: A kiválasztott nyelv nem támogatott!");
        return;
    }

    const quote = randomQuote();

    const quoteCard = document.getElementById("quote-card");
    quoteCard.classList.remove("hidden");

    const quoteImg = document.querySelector("#quote-card img");
    quoteImg.setAttribute("src", `./src/images/${quote.image}`);
    quoteImg.setAttribute("alt", "Masszív aurával rendelkező fotográfia a bányabarkács filmből");

    const quoteCardBody = document.getElementById("quote-card-body");
    quoteCardBody.innerHTML = "";

    const h3 = document.createElement("h3");
    h3.style.textAlign = "center";
    h3.textContent = name;

    const p = document.createElement("p");

    p.textContent = selectedLanguage === "en" ? quote.en : quote.hu;
    p.style.textAlign = "center";
    p.style.fontStyle = "italic";

    quoteCardBody.append(h3, p);
});