<?php

function hetNapja(int $napSzama) :string {
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

function napSorszama(string $napNeve) :int {
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

function parosE(int $szam) :bool {
    return ($szam % 2 == 0) ? true : false;
}

function paratlanE(int $szam) :bool {
    return ($szam % 2 == 0) ? false : true;
}

function oszthatoE(int $osztando, int $oszto) :bool {
    return ($osztando % $oszto == 0) ? true : false;
}

function negativE(int $szam) :bool {
    return ($szam < 0) ? true : false;
}

function szignum(int $szam) :int {
    if ($szam == 0) {
        return 0;
    }

    return ($szam > 0) ? 1 : -1;
}
