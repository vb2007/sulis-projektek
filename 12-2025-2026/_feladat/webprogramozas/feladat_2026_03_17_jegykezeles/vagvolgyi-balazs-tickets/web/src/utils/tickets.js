import { BASE_URL } from "./config.js";

export const getTickets = async () => {
    const response = await fetch(BASE_URL + "tickets", {
        method: "GET",
        headers: { Accept: "application/json" },
    });
    const result = await response.json();

    return result.data || result;
};

export const getTicket = async (id) => {
    const response = await fetch(BASE_URL + "tickets/" + id, {
        method: "GET",
        headers: { Accept: "application/json" },
    });
    const result = await response.json();

    return result.data || result;
};

export const createTicket = async (data) => {
    const response = await fetch(BASE_URL + "tickets", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data),
    });
    const result = await response.json();

    return result.data || result;
};
