import { BASE_URL } from "./config.js";

export const getBicycles = async () => {
    try {
        const response = await fetch(`${BASE_URL}/bicycles`);

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
