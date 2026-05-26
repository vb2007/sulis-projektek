import { BASE_URL } from "./config.js";

let dogs = [];

export const getDogs = async () => {
    const response = await fetch(`${BASE_URL}/dogs`, {
        method: "GET",
        headers: { Accept: "application/json" },
    });
    
    const results = await response.json();

    return results.data || results;
}
