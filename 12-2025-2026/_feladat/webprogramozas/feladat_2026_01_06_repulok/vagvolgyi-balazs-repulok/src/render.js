import { Table } from "cli-table3";

export default {
    renderCLITable(flights, column) {
        const table = new Table({
            head: ["#", "Légitársaság", "Repülő", "Honnan", "Hova"],
            colWidths: [100, 200, 100, 100, 100],
        });

        return table.toString();
    },
};
