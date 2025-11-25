<?php

require "en.php";

$en["jelszo"] = "abc";
$en["titok"] = "def";

if ($argc != 2) {
    echo "A szkript pontosan 1 paramétert vár!\n";
    exit(1);
}

if ($argv[1] == $en["jelszo"]) {
    echo "{$en['titok']}\n";
    exit(0);
}

foreach ($en as $kulcs => $ertek) {
    if ($kulcs == $argv[1]) {
        echo "{$ertek}\n";
        exit(0);
    }
}

echo "Ismeretlen paraméter!\n";
exit(2);
