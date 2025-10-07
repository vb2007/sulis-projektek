<?php
//1.
$vegyes = [5, 9, "Hello", 11.2, "Béla", 33, "Márta", 48.98, 7];

//2.
if ($argc != 2) {
    echo "A szkript pontosan egy paramétert vár!\n";
    return;
}

//3.
$param = $argv[1];
if ($param != "szamok" && $param != "egesz" && $param != "valos" && $param != "szoveg") {
    echo "A paraméter csak 'szamok', 'egesz', 'valos' vagy 'szoveg' lehet.\n";
    return;
}

switch($param) {
    //4.
    case "szamok":
        $szamok = [];
        for ($i = 0; $i < count($vegyes); $i++) {
            if (is_numeric($vegyes[$i])) {
                array_push($szamok, $vegyes[$i]);
            }
        }

        for ($i = 0; $i < count($szamok); $i++) {
            echo $i + 1 . ". szám: " . $szamok[$i] . "\n";
        }

        break;
    case "egesz":
        $egesz = [];
        for ($i = 0; $i < count($vegyes); $i++) {
            if (is_int($vegyes[$i])) {
                array_push($egesz, $vegyes[$i]);
            }
        }

        for ($i = 0; $i < count($egesz); $i++) {
            echo $i + 1 . ". egész szám: " . $egesz[$i] . "\n";
        }

        break;
    case "valos":
        $valos = [];
        for ($i = 0; $i < count($vegyes); $i++) {
            if (is_float($vegyes[$i])) {
                array_push($valos, $vegyes[$i]);
            }
        }

        for ($i = 0; $i < count($valos); $i++) {
            echo $i + 1 . ". valós szám: " . $valos[$i] . "\n";
        }

        break;
    case "szoveg":
        $szoveg = [];
        for ($i = 0; $i < count($vegyes); $i++) {
            if (is_string($vegyes[$i])) {
                array_push($szoveg, $vegyes[$i]);
            }
        }

        for ($i = 0; $i < count($szoveg); $i++) {
            echo $i + 1 . ". szöveg: " . $szoveg[$i] . "\n";
        }

        break;
}
