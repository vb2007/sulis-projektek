import { createFlight, getFlights } from "./flights.js";

for (let i = 1; i < 200; i++) {
    createFlight();
}

// const sortedFlights = getFlights({}, "captain");
// console.log("Szortírozott járaok (kapitány alapján, ABC sorrendben):");
// console.log(sortedFlights);
