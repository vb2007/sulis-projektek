import { getTickets, createTicket } from "../../utils/tickets.js";

const ticketsContainer = document.getElementById("tickets");
const cardTemplate = document.getElementById("card-template");
const ticketDialog = document.getElementById("ticket-dialog");
const newTicketDialog = document.getElementById("new-ticket-dialog");
const newTicketForm = document.getElementById("new-ticket-form");

const today = new Date().toISOString().substring(0, 10);

const validInput = document.getElementById("valid");
if (validInput) {
    validInput.value = today;
    validInput.min = today;
}

const createCard = (ticket) => {
    const clone = cardTemplate.content.cloneNode(true);
    const card = clone.querySelector("div");

    card.dataset.id = ticket.id;

    card.querySelector(".route").textContent =
        `${ticket.from} - ${ticket.to}`.toUpperCase();
    card.querySelector(".via").textContent = ticket.via.toUpperCase();
    card.querySelector(".valid").textContent = ticket.valid.toUpperCase();

    if (ticket.valid >= today) {
        card.classList.add("bg-green-50", "border-green-500");
    } else {
        card.classList.add("bg-red-50", "border-red-500");
    }

    card.addEventListener("click", () => {
        ticketDialog.dataset.id = ticket.id;
        ticketDialog.showModal();
    });

    return clone;
};

const loadTickets = async () => {
    try {
        const tickets = await getTickets();
        ticketsContainer.innerHTML = "";

        tickets.forEach((ticket) => {
            const card = createCard(ticket);
            ticketsContainer.appendChild(card);
        });
    } catch (error) {
        console.error("Error loading tickets:", error);
    }
};

const btnPrint = document.getElementById("btn-print");
const btnCheck = document.getElementById("btn-check");
const btnCancel = document.getElementById("btn-cancel");

btnPrint?.addEventListener("click", () => {
    const ticketId = ticketDialog.dataset.id;
    window.location = `/src/pages/print.html?ticketId=${ticketId}`;
});

btnCheck?.addEventListener("click", () => {
    const ticketId = ticketDialog.dataset.id;
    window.location = `/src/pages/check.html?ticketId=${ticketId}`;
});

btnCancel?.addEventListener("click", () => {
    ticketDialog.close();
});

// New ticket dialog handlers
const newTicketBtn = document.getElementById("new-ticket");
const btnFormCancel = document.getElementById("btn-form-cancel");

newTicketBtn?.addEventListener("click", () => {
    newTicketDialog.showModal();
});

btnFormCancel?.addEventListener("click", () => {
    newTicketDialog.close();
});

newTicketForm?.addEventListener("submit", async (e) => {
    e.preventDefault();

    const formData = new FormData(newTicketForm);
    const data = {
        from: formData.get("from"),
        to: formData.get("to"),
        via: formData.get("via"),
        type: formData.get("type"),
        valid: formData.get("valid"),
        price: 0,
    };

    try {
        const newTicket = await createTicket(data);

        const card = createCard(newTicket);
        ticketsContainer.appendChild(card);

        newTicketDialog.close();
        newTicketForm.reset();
        validInput.value = today;
    } catch (error) {
        console.error("Error creating ticket:", error);
    }
});

loadTickets();
