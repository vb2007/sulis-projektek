import "@assets/app.css";
import { getBicycles } from "./js/bicycle.js";
import { generateCards } from "./js/helper.js";

const bicycles = await getBicycles();

console.log(bicycles);

generateCards(bicycles);
