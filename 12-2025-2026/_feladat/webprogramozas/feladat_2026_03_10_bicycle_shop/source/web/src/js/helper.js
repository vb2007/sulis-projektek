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
};

export const generateCards = (bicycles) => {};
