import "@assets/app.css";
import { getProducts } from "./js/products.js";
import { generateProductCard } from "./js/cards.js";

const generateProductCards = (products) => {
    const productsGrid = document.getElementById("products-grid");
    products.forEach((product) => {
        const card = generateProductCard(product);
        productsGrid.appendChild(card);
    });
};

getProducts()
    .then((products) => {
        generateProductCards(products);
    })
    .catch((error) => {
        console.error("Hiba a termékek betöltése közben:", error);
    });
