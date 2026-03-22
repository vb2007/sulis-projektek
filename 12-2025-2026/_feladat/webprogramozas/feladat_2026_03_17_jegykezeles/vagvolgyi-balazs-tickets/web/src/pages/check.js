import { getTicket } from "../utils/tickets.js";

const typeText = {
    single: "Menetjegy",
    return: "Menettéri jegy",
};

const ticketId = new URLSearchParams(location.search).get("ticketId") ?? null;

const loadTicket = async () => {
    if (!ticketId) {
        console.error("No ticketId provided");
        return;
    }

    try {
        const ticket = await getTicket(ticketId);

        document.getElementById("from").textContent = ticket.from.toUpperCase();
        document.getElementById("to").textContent = ticket.to.toUpperCase();
        document.getElementById("via").textContent = ticket.via.toUpperCase();
        document.getElementById("date").textContent =
            ticket.valid.toUpperCase();
        document.getElementById("type").textContent =
            typeText[ticket.type].toUpperCase();

        const today = new Date().toISOString().substring(0, 10);
        const isValidElement = document.getElementById("is-valid");

        if (ticket.valid === today) {
            isValidElement.textContent = "ÉRVÉNYES";
            isValidElement.classList.remove("bg-red-600");
            isValidElement.classList.add("bg-green-600");
        } else {
            isValidElement.textContent = "ÉRVÉNYTELEN";
            isValidElement.classList.remove("bg-green-600");
            isValidElement.classList.add("bg-red-600");
        }
    } catch (error) {
        console.error("Error loading ticket:", error);
    }
};

loadTicket();
