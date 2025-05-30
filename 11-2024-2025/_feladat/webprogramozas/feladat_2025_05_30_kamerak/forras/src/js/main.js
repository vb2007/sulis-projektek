import '../css/style.css';
import cameras from './data.mjs';

const types = {
    mirrorless: 'Tükör nélküli',
    dslr: 'DSLR',
    compact: 'Kompakt'
}

function generateCell(text) {
    const cell = document.createElement('td');
    cell.textContent = text;
    cell.classList.add('p-1', 'text-center');
    return cell;
}

function generateRow(camera) {
    const row = document.createElement('tr');

    row.appendChild(generateCell(camera.name));
    row.appendChild(generateCell(types[camera.type]));
    row.appendChild(generateCell(camera.price.toString()));

    return row;
}

function generateTable() {
    const tableBody = document.querySelector('tbody');
    tableBody.innerHTML = '';

    cameras.forEach(camera => {
        const row = generateRow(camera);
        tableBody.appendChild(row);
    });
}

generateTable();

document.querySelector('form').addEventListener('submit', event => {
    event.preventDefault();

    const form = event.target;
    const manufacturer = form.manufacturer.value;
    const name = form.name.value;
    const type = form.type.value;
    const price = parseInt(form.price.value, 10);

    cameras.push({
        manufacturer,
        name,
        type,
        price
    });

    generateTable();

    form.reset();
    form.type[0].checked = true;
});