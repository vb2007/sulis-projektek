"use strict"

/**
 * Formats a number according to Hungarian localization.
 * @function
 * @param {number} num - The number to be formatted.
 */
const formatNumber = num => num.toLocaleString('hu-HU');

// 1. Feladat

const earbuds = ["Apple AirPods Pro (2nd Gen)", "Samsung Galaxy Buds 2 Pro", "Sony WF-1000XM5", "Bose QuietComfort Earbuds II", "Jabra Elite 7 Pro", "Beats Fit Pro", "Sennheiser Momentum True Wireless 3", "Google Pixel Buds Pro", "Anker Soundcore Liberty 4", "Nothing Ear (2)"];

const earbudsContainer = document.getElementById("earbuds")

earbuds.forEach(earbud => {
    const container = document.createElement('div')
    container.classList.add('p-2', 'bg-red-50', 'rounded-md', 'grow-1', 'text-center')
    container.textContent = earbud
    earbudsContainer.append(container)
}
)

// 2. Feladat

const words = [
    { german: "Haus", english: "House" },
    { german: "Baum", english: "Tree" },
    { german: "Auto", english: "Car" },
    { german: "Wasser", english: "Water" },
    { german: "Freund", english: "Friend" },
    { german: "Buch", english: "Book" },
    { german: "Stuhl", english: "Chair" },
    { german: "Tisch", english: "Table" },
    { german: "Hund", english: "Dog" },
    { german: "Katze", english: "Cat" },
    { german: "Sonne", english: "Sun" },
    { german: "Mond", english: "Moon" }
];

const wordsContainer = document.getElementById("words")

words.forEach(word => {
    const mainContainer = document.createElement("div")
    mainContainer.classList.add('grid', 'grid-cols-2', 'p-2', 'bg-red-50', 'rounded-md', 'text-center')

    const germanContainer = document.createElement("div")
    germanContainer.classList.add("font-bold")
    germanContainer.textContent = word.german

    const englishContainer = document.createElement("div")
    englishContainer.classList.add("italic")
    englishContainer.textContent = word.english

    mainContainer.append(germanContainer, englishContainer)
    wordsContainer.append(mainContainer)
}
)

// 3. Feladat

const properties = [
    { address: "Nagytétényi út 185", type: "house", baseSize: 64, price: 53100000, rooms: 2, image: "src/images/property_1.jpg" },
    { address: "Dózsa György út 47b", type: "house", baseSize: 43, price: 42200000, rooms: 2, image: "src/images/property_2.jpg" },
    { address: "Budafoki út 215", type: "apartment", baseSize: 44, price: 59600000, rooms: 3, image: "src/images/property_3.jpg" },
    { address: "Bartók Béla út 95", type: "apartment", baseSize: 56, price: 67200000, rooms: 2, image: "src/images/property_4.jpg" },
    { address: "Tétényi út 62", type: "house", baseSize: 75, price: 71000000, rooms: 3, image: "src/images/property_5.jpg" },
    { address: "Móricz Zsigmond körtér 2", type: "apartment", baseSize: 48, price: 52000000, rooms: 2.5, image: "src/images/property_6.jpg" },
    { address: "Szabadság utca 34", type: "house", baseSize: 90, price: 83000000, rooms: 4, image: "src/images/property_7.jpg" },
    { address: "Törökbálinti út 12", type: "house", baseSize: 82, price: 77000000, rooms: 3, image: "src/images/property_8.jpg" },
    { address: "Irinyi József utca 14", type: "apartment", baseSize: 60, price: 60000000, rooms: 3, image: "src/images/property_9.jpg" },
    { address: "Fehérvári út 198", type: "house", baseSize: 95, price: 85000000, rooms: 5, image: "src/images/property_10.jpg" },
    { address: "Fehérvári út 101", type: "apartment", baseSize: 40, price: 52000000, rooms: 2, image: "src/images/property_11.jpg" },
    { address: "Budafoki út 8", type: "apartment", baseSize: 53, price: 61000000, rooms: 3.5, image: "src/images/property_12.jpg" },
    { address: "Hunyadi János út 4", type: "house", baseSize: 88, price: 78000000, rooms: 4, image: "src/images/property_13.jpg" },
    { address: "Budafoki út 23", type: "apartment", baseSize: 50, price: 59000000, rooms: 3, image: "src/images/property_14.jpg" },
    { address: "Műegyetem rakpart 14", type: "house", baseSize: 102, price: 94000000, rooms: 5, image: "src/images/property_15.jpg" },
    { address: "Tétényi út 36", type: "apartment", baseSize: 45, price: 53000000, rooms: 2, image: "src/images/property_16.jpg" },
    { address: "Fehérvári út 9", type: "apartment", baseSize: 62, price: 68000000, rooms: 3, image: "src/images/property_17.jpg" },
    { address: "Tétényi út 3", type: "apartment", baseSize: 55, price: 61500000, rooms: 2.5, image: "src/images/property_18.jpg" },
    { address: "Margit körút 45", type: "house", baseSize: 97, price: 86000000, rooms: 4, image: "src/images/property_19.jpg" },
    { address: "Petzvál József utca 18", type: "apartment", baseSize: 58, price: 60000000, rooms: 3, image: "src/images/property_20.jpg" }
];

const propertiesElement = document.getElementById('properties');

properties.forEach(property => {
    const gridContainer = document.createElement('div');
    gridContainer.className = 'grid grid-rows-subgrid row-span-6 p-2 bg-red-50 rounded-md';

    const img = document.createElement('img');
    img.src = property.image;
    img.alt = property.address;
    gridContainer.appendChild(img);

    const title = document.createElement('h5');
    title.className = 'text-xl font-semibold';
    title.textContent = property.address;
    gridContainer.appendChild(title);

    const typeParagraph = document.createElement('p');
    typeParagraph.className = 'italic';
    typeParagraph.textContent = property.type === 'house' ? 'Ház' : 'Lakás';
    gridContainer.appendChild(typeParagraph);

    const areaParagraph = document.createElement('p');
    areaParagraph.innerHTML = `Alapterület: ${property.baseSize}m<sup>2</sup>`;
    gridContainer.appendChild(areaParagraph);

    const roomsParagraph = document.createElement('p');
    roomsParagraph.textContent = `Szobák száma: ${property.rooms}`;
    gridContainer.appendChild(roomsParagraph);

    const priceParagraph = document.createElement('p');
    priceParagraph.className = 'text-2xl font-bold';
    priceParagraph.textContent = formatNumber(property.price) + " Ft";
    gridContainer.appendChild(priceParagraph);

    propertiesElement.appendChild(gridContainer);
});