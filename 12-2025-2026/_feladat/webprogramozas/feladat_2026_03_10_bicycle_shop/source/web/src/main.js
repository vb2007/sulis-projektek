import "@assets/app.css";
import { getBicycles } from "./js/bicycle.js";

const bicycles = await getBicycles();

console.log(bicycles);
