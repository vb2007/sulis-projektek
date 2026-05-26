import { BASE_URL } from "./config.js";

const dogbreeds = [
    "Tacsk ́o",
    "N ́emetjuh ́asz",
    "Golden retriever",
    "Bulldog",
    "Beagle"
];
let dogs = [];

export const getDogs = async () => {
    const response = await fetch(`${BASE_URL}/dogs`, {
        method: "GET",
        headers: { Accept: "application/json" },
    });

    if(!response.ok) {
        throw new Error(`A szerver ${response.status} kóddal válaszolt a(z) ${response.url} útvonalon`);
    }

    const results = await response.json();

    return results.data || results;
}

export const createDog = async (dog) => {
    const response = await fetch(`${BASE_URL}/dogs`, {
        method: "POST",
        body: JSON.stringify(dog),
        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json"
        },
    });

    if (!response.ok) {
        throw new Error(`A szerver ${response.status} kóddal válaszolt a(z) ${response.url} útvonalon`)
    }


}