export const fomatPrice = (price) => {
    return price.toLocaleString("hu-HU", {
        style: "currency",
        currency: "HUF",
        maximumFractionDigits: 0,
    });
};

export const createCard = (bicycle) => {
    const template = document.getElementById("bicycle-card");
    const clone = template.content.cloneNode(true);

    const card = clone.querySelector("*");
    card.dataset.id = bicycle.id;

    const h3 = clone.querySelector("h3");
    h3.textContent = `${bicycle.manufacturer}: ${bicycle.name}, ${bicycle.color}`;

    const img = clone.querySelector("img");
    img.src = `images/${bicycle.id}.jpg`;
    img.alt = `${bicycle.name}`;
    img.title = `${bicycle.name}`;

    const p = clone.querySelector("p");
    p.textContent = fomatPrice(bicycle.price);

    return clone;
};

export const generateCards = (bicycles) => {
    const container = document.getElementById("bicycles");

    bicycles.forEach((bicycle) => {
        const card = createCard(bicycle);
        container.appendChild(card);
    }
};
