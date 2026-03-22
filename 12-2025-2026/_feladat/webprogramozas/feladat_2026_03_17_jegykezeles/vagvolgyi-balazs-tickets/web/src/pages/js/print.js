import { getTicket } from "../../utils/tickets.js";

const typeText = {
    single: {
        hu: "Menetjegy",
        en: "Ticket",
    },
    return: {
        hu: "Menettéri jegy",
        en: "Return ticket",
    },
};

const ticketId = new URLSearchParams(location.search).get("ticketId") ?? null;

const loadTicket = async () => {
    if (!ticketId) {
        console.error("No ticket ID provided");
        return;
    }

    try {
        const ticket = await getTicket(ticketId);

        document.getElementById("type-hu").textContent =
            typeText[ticket.type].hu.toUpperCase();
        document.getElementById("type-en").textContent =
            typeText[ticket.type].en.toUpperCase();

        document.getElementById("from").textContent = ticket.from.toUpperCase();
        document.getElementById("to").textContent = ticket.to.toUpperCase();
        document.getElementById("via").textContent = ticket.via.toUpperCase();
        document.getElementById("date").textContent =
            ticket.valid.toUpperCase();

        const priceFormatter = new Intl.NumberFormat("de-DE", {
            style: "currency",
            currency: "EUR",
        });
        document.getElementById("price").textContent = priceFormatter
            .format(ticket.price)
            .toUpperCase();

        document.getElementById("qr").src =
            `https://quickchart.io/qr?text=${ticketId}`;
    } catch (error) {
        console.error("Error loading ticket:", error);
    }
};

loadTicket();
