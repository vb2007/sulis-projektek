<?php

function hetNapja(int $napSzama): string {
    switch($napSzama) {
        case 1:
            return "hétfő";
        case 2:
            return "kedd";
        case 3:
            return "szerda";
        case 4:
            return "csütörtök";
        case 5:
            return "péntek";
        case 6:
            return "szombat";
        case 7:
            return "vasárnap";
        default:
            return "Érvénytelen napszám.";
    }
}

function napSorszama(string $napNeve): int {
    switch($napNeve) {
        case "hétfő":
            return 1;
        case "kedd":
            return 2;
        case "szerda":
            return 3;
        case "csütörtök":
            return 4;
        case "péntek":
            return 5;
        case "szombat":
            return 6;
        case "vasárnap":
            return 7;
        default:
            return 0;
    }
}
