import { faker } from "@faker-js/faker";

export const flights = [];

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
};
