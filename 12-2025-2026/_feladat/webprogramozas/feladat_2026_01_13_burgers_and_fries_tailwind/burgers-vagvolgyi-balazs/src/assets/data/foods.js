export const getFoodList = () => {
    return foodList;
};

export const getToppings = () => {
    return toppings;
};

const foodList = {
    burgers: {
        title: "Hamburgers",
        description: "100% fresh beef, no fillers or preservatives",
        items: [
            {
                name: "Hamburger",
                price: 11.4,
            },
            {
                name: "Cheeseburger",
                price: 12.4,
            },
            {
                name: "Bacon burger",
                price: 13.6,
            },
            {
                name: "Bacon Cheeseburger",
                price: 14.6,
            },
        ],
    },
    hotdogs: {
        title: "Dogs",
        items: [
            {
                name: "All beff hot dog",
                price: 8.2,
            },
            {
                name: "Cheese dog",
                price: 9.2,
            },
            {
                name: "Bacon dog",
                price: 10.4,
            },
            {
                name: "Bacon cheese dog",
                price: 11.4,
            },
        ],
    },
    sandwitches: {
        title: "Sandwitches",
        items: [
            {
                name: "Veggie sandwitch",
                price: 7.0,
            },
            {
                name: "Veggie sandwitch with cheese",
                price: 8.0,
            },
            {
                name: "Grilled cheese",
                price: 8.0,
            },
            {
                name: "BLT (Bacon, Lettuce, Tomato)",
                price: 9.9,
            },
        ],
    },
    fries: {
        title: "Fries",
        description: "Coocked in penaut oil",
        items: [
            {
                name: "Little",
                price: 5.9,
            },
            {
                name: "Regular",
                price: 7.2,
            },
            {
                name: "Large",
                price: 8.2,
            },
        ],
    },
};

const toppings = [
    "Mayo",
    "Lettuce",
    "Pickles",
    "Tomatoes",
    "Ketchup",
    "Mustard",
    "Grilled onions",
    "Grilled mushrooms",
    "Relish onions",
    "Green peppers",
    "Jalapeño peppers",
    "Steak sauce",
    "Bar-B-Que Sauce",
    "Hot sauce",
];
