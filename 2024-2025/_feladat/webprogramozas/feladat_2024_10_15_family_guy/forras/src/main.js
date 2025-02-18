"use strict"

function setCharacterWidths() {
    let width = document.querySelector('#content').offsetWidth;

    for (const element of document.querySelectorAll('.character')) {
        switch (element.classList[1]) {
            case 'peter':
                element.style.width = (width * 0.25) + "px";
                break;
            case 'lois':
                element.style.width = (width * 0.11) + "px";
                break;
            case 'chris':
                element.style.width = (width * 0.25) + "px";
                break;
            case 'meg':
                element.style.width = (width * 0.11) + "px";
                break;
            case 'brian':
                element.style.width = (width * 0.12) + "px";
                break;
            case 'stewie':
                element.style.width = (width * 0.13) + "px";
                break;
            case 'boat': 
                element.style.width = (width * 0.25) + "px";
                break;
            case 'explosion': 
                element.style.width = (width * 0.5) + "px";
                break;
            default:
                break;
        }
    }
}

setCharacterWidths();

setInterval(() => {
    setCharacterWidths();
}, 1000);