import { BASE_URL } from "./config.js";

export const getBicycles = async () => {
    try {
        const response = await fetch(`${BASE_URL}/bicycles`, {
            method: "GET",
        });

        if (!response.ok) {
            console.error(`Hiba a lekérés során: ${response.statusText}`);
        }

        const data = await response.json();

        return data.data;
    } catch (error) {
        console.error(
            `Nem sikerült betölteni a kerékpárokat:\n\t${error.message}`,
        );
    }
};

export const createBicycle = async (bicycle) => {
    const response = await fetch(`${BASE_URL}/bicycles`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            Accept: "application/json",
        },
        body: JSON.stringify(bicycle),
    });

    if (!response.ok) {
        console.error(
            `Hiba a kerékpár létrehozása során: ${response.statusText}`,
        );
    }

    const data = await response.json();

    return data.data;
};

export const updateBicycle = async (bicycle) => {
    const response = await fetch(`${BASE_URL}/bicycles/${bicycle.id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
            Accept: "application/json",
        },
        body: JSON.stringify(bicycle),
    });

    if (!response.ok) {
        console.error(
            `Hiba a kerékpár módosítása során: ${response.statusText}`,
        );
    }

    const data = await response.json();

    return data.data;
};

export const deleteBicycle = async (id) => {
    const response = await fetch(`${BASE_URL}/bicycles/${id}`, {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json",
            Accept: "application/json",
        },
    });

    if (!response.ok) {
        console.error(`Hiba a kerékpár törlése során: ${response.statusText}`);
    }

    return true;
};
