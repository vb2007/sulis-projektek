import "@assets/app.css";
import { getBicycles } from "./js/bicycle.js";
import { generateCards, setBicyclesRef } from "./js/helper.js";

const bicycles = await getBicycles();

console.log(bicycles);

//tömb -> helper.js
setBicyclesRef(bicycles);

generateCards(bicycles);
