import "./app.css";
import subjects from "./data/subjects.js";

const body = document.querySelector("body");

const header = document.createElement("header");
header.classList.add("bg-[#931634]");

const h1 = document.createElement("h1");
h1.classList.add("text-white", "text-6xl", "font-light", "py-12", "pl-8");
h1.textContent = "Felvett tárgyak listája";

header.append(h1);
body.prepend(header);
