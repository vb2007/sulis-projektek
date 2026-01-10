import Table from "cli-table3";
import chalk from "chalk";

export default function renderCLITable(flights, column) {
    const columnNames = ["#", "Légitársaság", "Repülő", "Honnan", "Hova"];

    const headerNames = [
        chalk.red("#"),
        chalk.red("Légitársaság"),
        chalk.red("Repülő"),
        chalk.red("Honnan"),
        chalk.red("Hova"),
    ];

    const table = new Table({
        head: headerNames,
        colWidths: [6, 25, 20, 8, 6],
    });

    flights.forEach((flight) => {
        const { flightNumber, airline, airplane, departure, arrival } = flight;

        const rowData = [
            flightNumber,
            airline.name,
            airplane.name,
            departure.iataCode,
            arrival.iataCode,
        ];

        const rowDataColored = rowData.map((data, colIndex) => {
            if (columnNames[colIndex] === column) {
                return chalk.blue(data);
            }

            return data;
        });

        table.push(rowDataColored);
    });

    return table.toString();
}
