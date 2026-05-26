import "@assets/app.css";
import { dogbreeds, getDogs, createDog } from "@assets/js/dogs.js";

let dogs = [];

const templateEl = document.getElementById("dog-card");
const dogsContainerEl = document.getElementById("dogs-container");
const breedSelectEl = document.getElementById("breed");
const dialogEl = document.getElementById("dog-dialog");
const createDogButtonEl = document.getElementById("create-dog-button");
const dogFormEl = document.getElementById("dog-form");

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
};

const displayCards = (dogs) => {
    dogsContainerEl.innerHTML = "";
    dogs.forEach((dog) => {
        const card = createCard(dog);
        dogsContainerEl.append(card);
    });
};

const populateBreeds = () => {
    dogbreeds.forEach((breed) => {
        const option = document.createElement("option");
        option.value = breed;
        option.textContent = breed;
        breedSelectEl.append(option);
    });
};

createDogButtonEl.addEventListener("click", () => {
    dialogEl.showModal();
});

dogFormEl.addEventListener("submit", async (event) => {
    event.preventDefault();

    const formData = new FormData(dogFormEl);
    const dog = {
        name: formData.get("name"),
        breed: formData.get("breed"),
        age: parseInt(formData.get("age"), 10),
        owner: formData.get("owner"),
    };

    if (!dog.name || !dog.breed || !dog.age || !dog.owner) {
        alert("Minden űrlapelem kitöltése kötelező!");
        return;
    }

    if (dog.age < 2) {
        alert("A kor mező értéke nem lehet kevesebb, mint 2!");
        return;
    }

    const result = await createDog(dog);
    dogs.push(result);
    
    displayCards(await getDogs());
    dogFormEl.reset();
    dialogEl.close();
});

populateBreeds();

dogs = await getDogs();
displayCards(dogs);