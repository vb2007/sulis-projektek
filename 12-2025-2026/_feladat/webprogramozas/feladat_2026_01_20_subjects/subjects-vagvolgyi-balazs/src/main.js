import "./app.css";
import subjects from "./data/subjects.js";

const body = document.querySelector("body");

const header = document.createElement("header");
header.classList.add("bg-[#931634]");

const h1 = document.createElement("h1");
h1.classList.add("text-white", "text-6xl", "font-light", "py-12", "pl-8");
h1.textContent = "Felvett tárgyak listája";

header.append(h1);
body.prepend(header);

const tbody = document.querySelector("tbody");
const thName = document.querySelector("th")[1];
const thCredit = document.querySelector("th")[2];

let sortDirName = "asc";
let sortDirCredit = "asc";

const renderTable = () => {
    tbody.innerHTML = "";

    //params: jelenlegi subject elem, index
    subjects.forEach((subj, i) => {
        const tr = document.createElement("tr");

        if (i != subjects.length - 1) {
            tr.classList.add("border-b-2", "border-solid", "border-[#931634]");
        }

        tr.classList.add("hover:bg-black/10");

        const tdCode = document.createElement("td");
        tdCode.textContent = subj.code;
        tdCode.classList.add("p-2");

        const tdSubject = document.createElement("td");
        tdSubject.textContent = subj.subject;
        tdSubject.classList.add("p-2", "font-bold");

        const tdCredit = document.createElement("td");
        tdCredit.textContent = subj.credit;
        tdCredit.classList.add("p-2");

        tr.append(tdCode, tdSubject, tdCredit);
        tbody.append(tr);
    });
};

thName.addEventListener("click", () => {
    subjects.sort((a, b) => {
        if (sortDirName === "asc") {
            return a.subject.localeCompare(b.subject);
        } else {
            return b.subject.localeCompare(a.subject);
        }
    });

    sortDirName = sortDirName === "asc" ? "desc" : "asc";

    renderTable();
});

thCredit.addEventListener("click", () => {
    subjects.sort((a, b) => {
        if (sortDirCredit === "asc") {
            return parseInt(a.credit) - parseInt(b.credit);
        } else {
            return parseInt(b.credit) - parseInt(a.credit);
        }
    });

    sortDirCredit = sortDirCredit === "asc" ? "desc" : "asc";

    renderTable();
});

renderTable();
