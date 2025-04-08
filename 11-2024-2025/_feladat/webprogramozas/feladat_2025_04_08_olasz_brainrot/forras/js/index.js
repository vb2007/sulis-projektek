"use strict";

const button = document.querySelector("button");

button.addEventListener("click", function(event) {
    event.preventDefault();

    const resultCard = document.querySelector(".result");
    resultCard.classList.remove("hidden");

    const brainrotAnimals = ['Tralalero Tralala', 'Bombardiro Crocodilo', 'Lirili Larila', 'Bomborito Bandito'];
    const randomIndex = Math.floor(Math.random() * brainrotAnimals.length);
    const selectedAnimal = brainrotAnimals[randomIndex];

    const img = resultCard.querySelector("img");
    img.src = `img/brainrots/${selectedAnimal}.png`;
    img.alt = selectedAnimal;
    img.title = selectedAnimal;

    const resultBody = resultCard.querySelector(".result-body");
    const name = document.querySelector("#name").value || "Kedves Látogató";
    resultBody.innerHTML = `
        <h3> Kedves ${name}!</h3>
        <p>A te Brainrot állatod: ${selectedAnimal}</p>
    `;

    resultCard.style.margin = "1.5rem auto";
    resultCard.style.padding = "0.3rem";
    resultCard.style.backgroundColor = "green";
    resultCard.style.color = "white";

    const paragraph = resultBody.querySelector("p");
    paragraph.style.textAlign = "center";
});