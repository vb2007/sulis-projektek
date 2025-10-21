<?php

function hetNapja(int $napSzama): string {
    switch($napSzama){
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
            return ""
        default:
            return "Érvénytelen napszám.";
    }
}
