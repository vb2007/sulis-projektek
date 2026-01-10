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
            const keys = key.split(".");
            let flightValue = flight;

            for (const nestedKey of keys) {
                if (!flightValue || !flightValue.hasOwnProperty(nestedKey)) {
                    return false;
                }
                flightValue = flightValue[nestedKey];
            }

            const flightValueStr = String(flightValue).toLowerCase();
            const filterValue = String(filter[key]).toLowerCase();

            return flightValueStr.includes(filterValue);
        });
    });

    if (sort && filteredFlights.length > 0) {
        filteredFlights.sort((a, b) => {
            const keys = sort.split(".");
            let aValue = a;
            let bValue = b;

            for (const nestedKey of keys) {
                aValue = aValue && aValue[nestedKey];
                bValue = bValue && bValue[nestedKey];
            }

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
