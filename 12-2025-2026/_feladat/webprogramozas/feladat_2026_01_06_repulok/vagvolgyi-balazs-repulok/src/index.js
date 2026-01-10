import { createFlight, getFlights } from "./flights.js";
import renderCLITable from "./render.js";
import chalk from "chalk";

for (let i = 1; i < 200; i++) {
    createFlight();
}

// const sortedFlights = getFlights({}, "captain");
// console.log("Szortírozott járaok (kapitány alapján, ABC sorrendben):");
// console.log(sortedFlights);

const airbusFlights = getFlights({ "airplane.name": "Airbus" });
console.log(chalk.blue("Airbus") + " repülők:");
console.log(renderCLITable(airbusFlights, "Repülő"));
console.log();

const boeingAirFlights = getFlights(
    {
        "airplane.name": "Boeing",
        "airline.name": "Air",
    },
    "flightNumber",
);

console.log(
    chalk.green("Boeing") +
        " repülők az " +
        chalk.blue("Air") +
        " szót tartalmazó légitársaságoktól:",
);
console.log(renderCLITable(boeingAirFlights, "Légitársaság"));
