"use strict"

const date = new Date();

const items = [
    {
        name: "Monitor",
        qty: 14,
        person: "Kiss Lajos",
        date: new Date(date.setDate(date.getDate() - 10)).toJSON().split('T')[0],
        quality: 'Nagyon jó',
    },
    {
        name: "Íróasztal",
        qty: 9,
        person: "Molnár Judit",
        date: new Date(date.setDate(date.getDate() - 4)).toJSON().split('T')[0],
        quality: 'Jó',
    },
    {
        name: "Golyós toll",
        qty: 3,
        person: "Gimesi Anna",
        date: new Date(date.setDate(date.getDate() - 1)).toJSON().split('T')[0],
        quality: 'Közepes',
    },
    {
        name: "Fénymásoló papír",
        qty: 20,
        person: "Zentai Álmos",
        date: date.toJSON().split('T')[0],
        quality: 'Nagyon rossz',
    },
];

const people = [
    "Kiss Lajos",
    "Molnár Judit",
    "Gimesi Anna",
    "Zentai Álmos",
    "Disznóhús János",
    "Gyermeked Gronk",
    "Duke Dénes",
];
