"use strict";

const objektumok = [
    { id: 1, nev: "Hold", tipus: "Természetes hold", kep: "moon.png" },
    { id: 2, nev: "Mars", tipus: "Bolygó", kep: "mars.png" },
    { id: 3, nev: "Androméda", tipus: "Galaxis", kep: "andromeda.png" },
    { id: 4, nev: "Orion-köd", tipus: "Köd", kep: "orion.jpg" },
    { id: 5, nev: "Föld", tipus: "Bolygó", kep: "earth.png" },
    { id: 6, nev: "Halley-üstökös", tipus: "Üstökös", kep: "halley.jpg" }
];

//Innentől lefelé írjon, figyeljen a megfelelő változónevekre, ahol külön kitér rá a feladatsor. Nem megfelelő változónevek esetén a tesztelés nem fog sikerülni.

//Fejléc
let megfigyeltObjektumok = [];
let torolObjektumok = [];

document.body.classList.add("bg-slate-900", "min-h-screen");

const header = document.createElement("header");
header.classList.add('bg-slate-800', 'border-b', 'border-slate-700', 'py-4');

const h1 = document.createElement("h1");
h1.textContent = "Csillagászati Objektumok";
h1.classList.add('text-3xl', 'font-bold', 'text-center', 'text-teal-400');

const p = document.createElement("p");
p.textContent = "Megfigyelt objektumok: ";
p.classList.add('text-center', 'text-teal-200', 'mt-2');

const span = document.createElement("span");
span.setAttribute("id", "szamlalo");
span.textContent = "0";

p.append(span);
header.append(h1, p);
document.body.append(header);

//Fő tartalom
const main = document.createElement("main");
main.classList.add('container', 'mx-auto', 'px-4', 'py-8');

const kartyaContainer = document.createElement("div");
kartyaContainer.classList.add('grid', 'grid-cols-1', 'md:grid-cols-2', 'lg:grid-cols-3', 'gap-6');

main.append(kartyaContainer);
document.body.append(main);

//Lábléc
const footer = document.createElement("footer");
footer.textContent = "Készítette: Vágvölgy Balázs"
footer.classList.add('bg-slate-800', 'text-teal-200', 'text-center', 'py-4', 'mt-8');

document.body.append(footer);

//Kártyák megjelenítése
function letrehozKartya(objektum) {
    if (torolObjektumok.includes(objektum.id)) {
        return;
    }

    //Figyelem, az itt hagyott két sor alá is kell írni, azt a két sort az oldal működése miatt hagytam benne, figyeljen a megfelelő változónevekre
    const kartya = document.createElement("div");
    kartya.classList.add('bg-slate-800', 'rounded-lg', 'shadow-xl', 'p-4');

    const img = document.createElement("img");
    img.setAttribute("src", `img/${objektum.kep}`);
    img.classList.add('w-full', 'h-48', 'object-cover', 'rounded-lg', 'mb-4');

    const h2 = document.createElement("h2");
    h2.textContent = objektum.nev;
    if (megfigyeltObjektumok.includes(objektum.id)) {
        h2.classList.add('text-teal-400', 'line-through', 'text-xl');
    }
    else {
        h2.classList.add('text-white', 'text-xl');
    }

    const p = document.createElement("p");
    p.textContent = objektum.tipus;
    p.classList.add('text-slate-300');

    const gombok = document.createElement("div");
    gombok.classList.add('flex', 'gap-2', 'mt-4');
    
    const megfigyelesGomb = document.createElement("button");
    megfigyelesGomb.onclick = () => valtMegfigyelesAllapot(objektum.id);
    if (megfigyeltObjektumok.includes(objektum.id)) {
        megfigyelesGomb.classList.add('bg-slate-600', 'text-white', 'px-3', 'py-1', 'rounded');
        megfigyelesGomb.textContent = "Visszavon"
    }
    else {
        megfigyelesGomb.classList.add('bg-teal-600', 'text-white', 'px-3', 'py-1', 'rounded');
        megfigyelesGomb.textContent = "Megfigyel";
    }

    const torlesGomb = document.createElement("button");
    torlesGomb.onclick = () => torolObjektum(objektum.id);
    torlesGomb.textContent = "Töröl";
    torlesGomb.classList.add('bg-orange-600', 'text-white', 'px-3', 'py-1', 'rounded');

    gombok.append(megfigyelesGomb, torlesGomb);
    kartya.append(img, h2, p, gombok);

    return kartya;
}

function frissitMegjelenites() {
    while (kartyaContainer.firstChild) {
        kartyaContainer.removeChild(kartyaContainer.firstChild);
    }

    for (let i = 0; i < objektumok.length; i++) {
        const kartya = letrehozKartya(objektumok[i]);
        if (kartya) kartyaContainer.append(kartya);
    }

    document.getElementById('szamlalo').textContent = megfigyeltObjektumok.length;
}

function valtMegfigyelesAllapot(id) {
    if (megfigyeltObjektumok.includes(id)) {
        var index = megfigyeltObjektumok.indexOf(id);
        if (index !== -1) {
            megfigyeltObjektumok.splice(index, 1);
        }
    }
    else {
        megfigyeltObjektumok.push(id);
    }

    //Ezt hagyja itt, e főlé írjon csak
    frissitMegjelenites();
}

function torolObjektum(id) {
    if (!torolObjektumok.includes(id)) {
        torolObjektumok.push(id);
    }
    
    if (megfigyeltObjektumok.includes(id)) {
        var index = megfigyeltObjektumok.indexOf(id);
        if (index !== -1) {
            megfigyeltObjektumok.splice(index, 1);
        }
    }

    //Ezt hagyja itt, e főlé írjon csak
    frissitMegjelenites();
}

frissitMegjelenites();
