"use strict"

function capitalize(text) {
    return text.toUpperCase().slice(0, 1) + text.substring(1);
}

function createTableRow(subject) {
    const row = document.createElement('tr');
    
    
    const id = document.createElement('td');
    

    const name = document.createElement('td');
    

    const statusWraper = document.createElement('td')
    const status = document.createElement('span');
    
    
    statusWraper.append(status);

    row.append(id, name, statusWraper);
    return row;
}

function fillTable(array) {
    const rows = [];
    for (const subject of array) {
        rows.push(createTableRow(subject));
    }
    table.replaceChildren(...rows);
    addEventListenersToRows()
}

const table = document.querySelector('#list-of-subjects tbody');
fillTable(subjects);

function showSubject(subject) {
    
}

function addEventListenersToRows() {
    table.querySelectorAll('tr').forEach(x => x.addEventListener('click', e => 
        showSubject(subjects.find(y => true))
    ));
}

function filterSubjects(name) {
    
}

document.querySelector('#search').addEventListener('submit', e => {
    e.preventDefault();
    fillTable(filterSubjects(document.querySelector('#name').value));
});