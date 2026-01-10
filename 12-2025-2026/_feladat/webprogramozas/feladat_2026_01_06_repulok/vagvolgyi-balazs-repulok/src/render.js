import Table from "cli-table3";
import chalk from "chalk";

export default function renderCLITable(flights, column) {
    const colHeaderNames = [
        chalk.red("#"),
        chalk.red("Légitársaság"),
        chalk.red("Repülő"),
        chalk.red("Honnan"),
        chalk.red("Hova"),
    ];

    const table = new Table({
        head: colHeaderNames,
        colWidths: [7, 20, 15, 15, 15],
    });

    flights.forEach((flight) => {
        const { flightNumber, airline, airplane, departure, arrival } = flight;

        const rowData = [
            flightNumber,
            airline.name,
            airplane.name,
            departure.name,
            arrival.name,
        ];

        const rowDataColored = rowData.map((data, colIndex) => {
            if (colHeaderNames[colIndex] === column) {
                return chalk.blue(data);
            }

            return data;
        });

        table.push(rowDataColored);
    });

    return table.toString();
}
