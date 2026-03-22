import { BASE_URL } from "./config.js";

export const getTickets = async () => {
    const response = await fetch(BASE_URL + "tickets", {
        method: "GET",
        headers: { Accept: "application/json" },
    }).json();

    return result.data || result;
};
