import { faker } from "@faker-js/faker";

const flights = [];

export const createFlight = () => {
    const flight = {
        flightNumber: faker.airline.flightNumber({ addLeadingZeros: true }),
        airline: faker.airline.airline(),
        airplane: faker.airline.airplane(),
        departure: faker.airline.airport(),
        arrival: faker.airline.airport(),
        date: faker.date.anytime(),
        captain: faker.person.fullName(),
    };

    flights.push(flight);
    return flight;
};

export const getFlights = (filter = {}, sort = "") => {
    let filteredFlights = flights.filter((flight) => {
        return Object.keys(filter).every((key) => {
            if (!flight.hasOwnProperty(key)) {
                return false;
            }

            const flightValue = String(flight[key]).toLowerCase();
            const filterValue = String(filter[key]).toLowerCase();

            return flightValue.includes(filterValue);
        });
    });

    if (
        sort &&
        filteredFlights.length > 0 &&
        filteredFlights[0].hasOwnProperty(sort)
    ) {
        filteredFlights.sort((a, b) => {
            const aValue = a[sort];
            const bValue = b[sort];

            if (aValue instanceof Date && bValue instanceof Date) {
                return aValue - bValue;
            }

            if (typeof aValue === "string" && typeof bValue === "string") {
                return aValue.toLowerCase().localeCompare(bValue.toLowerCase());
            }

            return aValue < bValue ? -1 : aValue > bValue ? 1 : 0;
        });
    }

    return filteredFlights;
};
