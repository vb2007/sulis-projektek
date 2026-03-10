export const fomatPrice = (price) => {
    return price.toLocaleString("hu-HU", {
        style: "currency",
        currency: "HUF",
        maximumFractionDigits: 0,
    });
};

export const createCard = (bicycle) => {};

export const generateCards = (bicycles) => {};
