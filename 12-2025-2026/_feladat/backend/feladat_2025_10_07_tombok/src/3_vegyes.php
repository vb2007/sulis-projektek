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
if (!is_numeric($param) && !is_string($param)) {
    echo "A paraméter csak 'szamok', 'egesz', 'valos' vagy 'szoveg' lehet.\n";
}
