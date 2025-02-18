"use strict"

const students = [
    {
        name: 'Farkas Ferenc',
        groups: ['11.a', '11_SZFT2', '11_MA1', '11_AN3'],
        subjects: [
            {
                name: 'Webprogramozás',
                average: 4.78
            },
            {
                name: 'Asztali alkalmazások',
                average: 4.45
            },
            {
                name: 'Adatbázis',
                average: 5.00
            },
        ]
    },
    {
        name: 'Kiss Klára',
        groups: ['12.d', '12_SZFT5', '12_ANG4'],
        subjects: [
            {
                name: 'Webprogramozás',
                average: 4.25
            },
            {
                name: 'Backend programozás',
                average: 4.80
            },
            {
                name: 'Szoftvertesztelés',
                average: 4.60
            },
        ]
    },
    {
        name: 'Szabó István',
        groups: ['10.a', '10_PROG3', '10_ANG2'],
        subjects: [
            {
                name: 'Programozás alapok',
                average: 3.90
            },
            {
                name: 'Informatika alapok',
                average: 4.10
            },
            {
                name: 'Angol nyelv',
                average: 3.70
            },
        ]
    },
    {
        name: 'Nagy Emese',
        groups: ['13.b', '13_ANG5'],
        subjects: [
            {
                name: 'Frontend programozás',
                average: 4.85
            },
            {
                name: 'Backend programozás',
                average: 4.95
            },
            {
                name: 'Asztali alkalmazások',
                average: 4.70
            },
        ]
    },
    {
        name: 'Horváth Bence',
        groups: ['9.b', '9_PROG1', '9_ANG1'],
        subjects: [
            {
                name: 'Programozás alapok',
                average: 4.50
            },
            {
                name: 'Informatika alapok',
                average: 4.40
            },
            {
                name: 'Angol nyelv',
                average: 4.80
            },
        ]
    },
    {
        name: 'Tóth Anna',
        groups: ['11_SZFT4', '11.b', '11_ANG3'],
        subjects: [
            {
                name: 'Webprogramozás',
                average: 4.10
            },
            {
                name: 'Docker',
                average: 3.90
            },
            {
                name: 'Adatbázis',
                average: 4.00
            },
        ]
    },
    {
        name: 'Molnár László',
        groups: ['9.d', '9_PROG2', '9_ANG1'],
        subjects: [
            {
                name: 'Programozás alapok',
                average: 4.60
            },
            {
                name: 'Informatika alapok',
                average: 4.30
            },
            {
                name: 'Matematika',
                average: 4.50
            },
        ]
    },
    {
        name: 'Balogh Erika',
        groups: ['10_PROG1', '10.c', '10_ANG1'],
        subjects: [
            {
                name: 'Programozás alapok',
                average: 3.85
            },
            {
                name: 'Informatika alapok',
                average: 3.70
            },
            {
                name: 'Angol nyelv',
                average: 4.00
            },
        ]
    },
    {
        name: 'Varga Dávid',
        groups: ['12.a', '12_SZFT3', '12_ANG2'],
        subjects: [
            {
                name: 'Backend programozás',
                average: 4.90
            },
            {
                name: 'Szoftvertesztelés',
                average: 4.75
            },
            {
                name: 'Webprogramozás',
                average: 4.85
            },
        ]
    },
    {
        name: 'Juhász Katalin',
        groups: ['13.a', '13_SZFT6', '13_ANG4'],
        subjects: [
            {
                name: 'Frontend programozás',
                average: 4.70
            },
            {
                name: 'Backend programozás',
                average: 4.95
            },
            {
                name: 'Matematika',
                average: 4.60
            },
        ]
    },
];

// Feladatok

const container = document.getElementById("container");

students.forEach(student => {
    const cardContainer = document.createElement("div");
    cardContainer.classList.add("p-2");

    const studentName = document.createElement("h5");
    studentName.classList.add("font-semibold", "text-2xl");
    studentName.textContent = student.name;

    const studentGroups = document.createElement("div");
    studentGroups.classList.add("flex", "flex-wrap", "gap-2");
    student.groups.forEach(group => {
        const groupSpan = document.createElement("span");
        groupSpan.classList.add("p-1", "bg-sky-500", "text-white", "rounded-md");
        groupSpan.textContent = group;
        studentGroups.appendChild(groupSpan);
    });

    const table = document.createElement("table");
    table.classList.add("w-full", "mt-1");

    const thead = document.createElement("thead");
    thead.classList.add("bg-sky-500", "text-white");

    const tr = document.createElement("tr");

    const th1 = document.createElement("th");
    th1.textContent = "Tantárgy";
    th1.classList.add("p-1");

    const th2 = document.createElement("th");
    th2.textContent = "Átlag";
    th2.classList.add("p-1");

    tr.append(th1, th2);
    thead.append(tr);

    const tbody = document.createElement("tbody");

    let totalAverage = 0;

    student.subjects.forEach(subject => {
        const tr = document.createElement("tr");
        tr.classList.add("odd:bg-sky-200");

        const td1 = document.createElement("td");
        td1.textContent = subject.name;
        td1.classList.add("p-1");

        const td2 = document.createElement("td");
        td2.textContent = subject.average;
        td2.classList.add("p-1", "text-center");

        tr.append(td1, td2);
        tbody.appendChild(tr);

        totalAverage += subject.average;
    });

    totalAverage /= student.subjects.length;

    const trAverage = document.createElement("tr");
    trAverage.classList.add("bg-sky-300");

    const tdAverageLabel = document.createElement("td");
    tdAverageLabel.textContent = "Átlag:";
    tdAverageLabel.classList.add("p-1");

    const tdAverageValue = document.createElement("td");
    tdAverageValue.textContent = totalAverage.toFixed(2);
    tdAverageValue.classList.add("p-1", "text-center");

    trAverage.append(tdAverageLabel, tdAverageValue);
    tbody.appendChild(trAverage);

    table.append(thead, tbody);

    const averageDiv = document.createElement("div");
    averageDiv.textContent = "Átlag: ";
    averageDiv.classList.add("bg-sky-500", "p-1", "text-center", "text-white");
    const averageSpan = document.createElement("span");
    averageSpan.textContent = totalAverage.toFixed(2);
    averageSpan.classList.add("font-bold");3
    averageDiv.appendChild(averageSpan);

    cardContainer.append(studentName, studentGroups, table, averageDiv);
    container.append(cardContainer);
});
