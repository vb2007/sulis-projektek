import { BASE_URL } from "./config.js";

export const fetchBases = async () => {
    const response = await fetch(`${BASE_URL}/bases`, {
        method: "GET",
        headers: { Accept: "application/json" },
    });
    const results = await response.json();

    return results.data || results;
};
