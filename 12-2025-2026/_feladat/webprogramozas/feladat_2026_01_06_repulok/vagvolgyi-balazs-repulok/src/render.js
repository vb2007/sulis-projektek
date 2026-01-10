import { Table } from "cli-table3";
import chalk from "chalk";

export default renderCLITable = (flights, column) => {
    const colHeaderNames = ["#", "Légitársaság", "Repülő", "Honnan", "Hova"];

    const colHeaderNamesColored = colHeaderNames.map((col) => {
        if (col === column) {
            return chalk.blue(col);
        }

        return col;
    });

    const table = new Table({
        head: colHeaderNamesColored,
        colWidths: [5, 20, 15, 15, 15],
    });

    flights.forEach((flight, index) => {
        const { flightNumber, airline, airplane, departure, arrival } = flight;

        const rowData = [
            index + 1,
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
};
