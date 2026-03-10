export const fomatPrice = (price) => {
    return price.toLocaleString("hu-HU", {
        style: "currency",
        currency: "HUF",
        maximumFractionDigits: 0,
    });
};

export const createCard = (bicycle) => {
    const template = document.getElementById("bicycle-card");
    const card = template.content.cloneNode(true);

    card.id = bicycle.id;

    const h3 = document.createElement("h3");
    h3.textContent = `${bicycle.manufacturer}: ${bicycle.name}, ${bicycle.color}`;

    const img = document.createElement("img");
    img.src = `images/${bicycle.id}.jpg`;
    img.alt = `${bicycle.name}`;
    img.title = `${bicycle.name}`;

    const p = document.createElement("p");
    p.textContent = fomatPrice(bicycle.price);

    card.append(h3, img, p);
    return card;
};

export const generateCards = (bicycles) => {
    const container = document.getElementById("bicycles");

    bicycles.forEach((bicycle) => {
        const card = createCard(bicycle);
        container.appendChild(card);
    }
};
