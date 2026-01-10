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
        return Object.entries(filter).every(([key, filterValue]) => {
            const flightValue = getNestedValue(flight, key);
            return (
                flightValue &&
                String(flightValue)
                    .toLowerCase()
                    .includes(String(filterValue).toLowerCase())
            );
        });
    });

    if (sort && filteredFlights.length > 0) {
        filteredFlights.sort((a, b) => {
            const aValue = getNestedValue(a, sort);
            const bValue = getNestedValue(b, sort);

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

const getNestedValue = (obj, path) => {
    return path.split(".").reduce((current, key) => current?.[key], obj);
};
