<?php

require "../fuggvenyek.php";

if ($argc != 3) {
    echo "A script pontosan 2 paramétert vár!\n";
    exit(0);
}

$ertek = $argv[0];
$mertekegyseg = $argv[1];

if (!is_numeric($argv[0])) {
    echo "Az első paraméternek számnak kell lennie!\n";
    exit(0);
}

switch ($mertekegyseg) {
    case "c":
    case "C":
    case "celsius":
    case "Celsius":
    case "CELSIUS":
        $f = round(c2f($ertek), 2);
        echo "{$ertek} celsius = {$f} fahrenheit\n";
        exit(1);
    case "f":
    case "F":
    case "fahrenheit":
    case "Fahrenheit":
    case "FAHRENHEIT":
        $c = round(f2c($ertek), 2);
        echo "{$ertek} fahrenheit = {$c} celsius\n";
        exit(1);
}
