import { BASE_URL } from "./config.js";

export const getBicycles = async () => {
    try {
        const response = await fetch(`${BASE_URL}/bicycles`, {
            method: "GET",
        });

        if (!response.ok) {
            console.error(`Hiba a lekérés során:\n\t${response.statusText}`);
        }

        const data = await response.json();

        return data.data;
    } catch (error) {
        console.error(
            `Nem sikerült betölteni a kerékpárokat:\n\t${error.message}`,
        );
    }
};

export const createBicycle = async () => {
    const response = await fetch(`${BASE_URL}/bicycles`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(bicycle),
    });

    if (!response.ok) {
        console.error(
            `Hiba a kerékpár létrehozása során:\n\t${response.statusText}`,
        );
    }

    const data = await response.json();

    return data.data;
};
