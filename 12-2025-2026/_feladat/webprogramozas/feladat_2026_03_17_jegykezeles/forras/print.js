const typeText = {
    single: {
        hu: 'Menetjegy',
        en: 'Ticket',
    },
    return: {
        hu: 'Menettéri jegy',
        en: 'Return ticket',
    },
}

const ticketId = new URLSearchParams(location.search).get('ticketId') ?? null;