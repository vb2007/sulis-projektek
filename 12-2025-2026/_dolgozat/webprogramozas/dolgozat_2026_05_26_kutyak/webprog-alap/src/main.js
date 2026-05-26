import "@assets/app.css";
import { getDogs } from "@assets/js/dogs.js";

const templateEl = document.getElementById("dog-card");
const dogsContainerEl = document.getElementById("dogs-container");

const createCard = (dog) => {
    const clone = templateEl.content.cloneNode(true);

    const h3 = clone.querySelector(".name");
    h3.textContent = dog.name;

    const span = clone.querySelector(".breed");
    span.textContent = dog.breed;

    const age = clone.querySelector(".age");
    age.textContent = dog.age;

    const owner = clone.querySelector(".owner");
    owner.textContent = dog.owner;

    return clone;
}

const displayCards = (dogs) => {
    for (let i = 0; i < dogs.length; i++) {
        const card = createCard(dogs[i]);
        dogsContainerEl.append(card);
    }
}

displayCards(await getDogs());