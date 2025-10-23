<?php

//Egyszerű függvények

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

function datumIdo(string $idoTipus) :string {
    date_default_timezone_set("UTC");

    switch($idoTipus) {
        case "év":
            return date("Y");
        case "hónap":
            return date("m");
        case "nap":
            return date("d");
        case "óra":
            return date("H");
        case "perc":
            return date("i");
        case "másodperc":
            return date("s");
        default:
            return "Érvénytelen időtípus.";
    }
}

//Függvények tömbökön

function utolso(array $tomb) :int {
    return $tomb[count($tomb) - 1];
}

function osszeg(array $tomb) :int {
    return array_sum($tomb);
}

function szorzat(array $tomb) :int {
    $szorzat = 1;
    foreach ($tomb as $szam) {
        $szorzat *= $szam;
    }

    return $szorzat;
}

function parosDb(array $tomb) :int {
    $db = 0;
    foreach($tomb as $szam) {
        parosE($szam) ? $db++ : null;
    }

    return $db;
}

function parosOsszeg(array $tomb) :int {
    $sum = 0;
    foreach($tomb as $szam) {
        parosE($szam) ? $sum += $szam : null;
    }

    return $sum;
}

function elsoNOsszeg(array $tomb, int $n) :int {
    $sum = 0;
    for ($i = 0; $i < $n; $i++) {
        $sum += $tomb[$i];
    }

    return $sum;
}

//Fokváltó

function f2c(int $f) :float {
    return ($f - 32) / 1.8;
}

function c2f(int $c) :float {
    return $c * 1.8 + 32;
}
