let users = [];
const registrationForm = document.getElementById('registrationForm');
const showBtn = document.getElementById('showBtn');
const hideBtn = document.getElementById('hideBtn');
const refreshBtn = document.getElementById('refreshBtn');
const usersTableContainer = document.getElementById('usersTableContainer');

registrationForm.addEventListener('submit', function(e) {
    e.preventDefault();
    
    if (validateForm()) {
        const newUser = {
            email: document.getElementById('email').value,
            password: document.getElementById('password').value,
            name: document.getElementById('name').value,
            birthdate: document.getElementById('birthdate').value,
            group: document.getElementById('group').value
        };
        
        users.push(newUser);
        
        registrationForm.reset();
        
        alert('Sikeres regisztráció!');
        
        //ki van kommentelve, hogy legyen értelme a refresh gombnak
        // if (usersTableContainer.innerHTML !== '') {
        //     displayUsers();
        // }
    }
});

showBtn.addEventListener('click', function() {
    displayUsers();
});

hideBtn.addEventListener('click', function() {
    usersTableContainer.innerHTML = '';
});

refreshBtn.addEventListener('click', function() {
    if (usersTableContainer.innerHTML !== '') {
        displayUsers();
        alert('Adatok frissítve!');
    }
});

function displayUsers() {
    if (users.length === 0) {
        usersTableContainer.innerHTML = '<p>Nincsenek még regisztrált felhasználók.</p>';
        return;
    }
    
    //undorító, de egyszerűbb, mint egyesével létrehozni az elementeket és beállítani az értékeiket
    let tableHTML = `
        <table>
            <thead>
                <tr>
                    <th>#</th>
                    <th>Név</th>
                    <th>Email</th>
                    <th>Születési dátum</th>
                    <th>Osztály</th>
                </tr>
            </thead>
            <tbody>
    `;
    
    users.forEach((user, index) => {
        const date = new Date(user.birthdate);
        const formattedDate = `${date.getFullYear()}. ${date.getMonth() + 1}. ${date.getDate()}.`;
        
        tableHTML += `
            <tr>
                <td>${index + 1}</td>
                <td>${user.name}</td>
                <td>${user.email}</td>
                <td>${formattedDate}</td>
                <td>${user.group}</td>
            </tr>
        `;
    });
    
    tableHTML += `
            </tbody>
        </table>
    `;
    
    usersTableContainer.innerHTML = tableHTML;
}

function validateForm() {
    let isValid = true;
    
    const email = document.getElementById('email');
    const emailError = document.getElementById('emailError');
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/; //auuuugh regex
    
    if (!emailRegex.test(email.value)) {
        emailError.textContent = 'Kérjük, adjon meg egy érvényes email címet!';
        isValid = false;
    } else {
        emailError.textContent = '';
    }
    
    const password = document.getElementById('password');
    const passwordError = document.getElementById('passwordError');
    
    if (password.value.length < 6) {
        passwordError.textContent = 'A jelszónak legalább 6 karakter hosszúnak kell lennie!';
        isValid = false;
    } else {
        passwordError.textContent = '';
    }
    
    const name = document.getElementById('name');
    const nameError = document.getElementById('nameError');
    
    if (name.value.trim() === '') {
        nameError.textContent = 'A név megadása kötelező!';
        isValid = false;
    } else {
        nameError.textContent = '';
    }
    
    const birthdate = document.getElementById('birthdate');
    const birthdateError = document.getElementById('birthdateError');
    
    if (birthdate.value === '') {
        birthdateError.textContent = 'A születési dátum megadása kötelező!';
        isValid = false;
    } else {
        birthdateError.textContent = '';
    }
    
    const group = document.getElementById('group');
    const groupError = document.getElementById('groupError');
    
    if (group.value === '') {
        groupError.textContent = 'Kérjük, válasszon egy osztályt!';
        isValid = false;
    } else {
        groupError.textContent = '';
    }
    
    return isValid;
}