<?php

if ($argc > 3) {
    echo "Túl sok paraméter!\n";
    exit(0);
}

if ($argc < 2) {
    echo "Hiányzó 1. paraméter!\n";
    exit(0);
}

$szam = $argv[1];
if (!is_numeric($szam)) {
    echo "Az első paraméter csak szám lehet!\n";
    exit(0);
}

$mod = isset($argv[2]) ? $argv[2] : null;
switch ($mod) {
    case "fel":
        echo felKerekites((float)$szam) . "\n";
        break;
    case "le":
        echo leKerekites((float)$szam) . "\n";
        break;
    case "ft":
        echo ftKerekites((int)$szam) . "\n";
        break;
    case "bankar":
        echo bankarKerekites((float)$szam) . "\n";
        break;
    case null:
        echo matematikaiKerekites((float)$szam) . "\n";
        break;
    default:
        echo "Ismeretlen kerekítési mód!\n";
        exit(0);
}

function felKerekites(float $x): int {
    return (int)ceil($x);
}

function leKerekites(float $x): int {
    return (int)floor($x);
}

function matematikaiKerekites(float $x): int {
    return (int)round($x);
}

//1,2 -> lefelé
//8,9 -> felfelé
//3,4,6,7 -> 5-re végződő számra
function ftKerekites(int $x): int {
    $utolsoJegy = $x % 10;

    switch ($utolsoJegy) {
        case 1:
        case 2:
            return $x - $utolsoJegy;
        case 8:
        case 9:
            return $x + (10 - $utolsoJegy);
        case 3:
        case 4:
        case 6:
        case 7:
            return $x - $utolsoJegy + 5;
        default:
            return $x; //0 vagy 5
    }
}

function bankarKerekites(float $x): int {
    $also = (int)floor($x);
    $felso = (int)ceil($x);

    if ($x == $also) {
        return $also;
    }

    $alsoParos = ($also % 2 == 0) ? $also : $also - 1;
    $felsoParos = ($felso % 2 == 0) ? $felso : $felso + 1;

    $alsoTavolsag = abs($x - $alsoParos);
    $felsoTavolsag = abs($x - $felsoParos);

    if ($alsoTavolsag < $felsoTavolsag) {
        return $alsoParos;
    }
    elseif ($felsoTavolsag < $alsoTavolsag) {
        return $felsoParos;
    }
    else {
        return $felsoParos;
    }
}
