<?php

require "adatok.php";

if ($argc > 2) {
    echo "Túl sok paraméter!\n";
    exit(4);
}

if ($argc == 1) {
    for ($i = 0; $i < count($parok); $i+=2) {
        echo $parok[$i] . " - " . $parok[$i + 1] . "\n";
    }
}

switch ($argv[1]) {
    case "fiuk":
        for ($i = 1; $i < count($parok); $i+=2) {
            $split = explode(" ", $parok[$i]);
            echo "- " . $split[0] . "\n"; //vezetéknevek
        }

        break;
    case "lanyok":
        $girlFirstnames = [];
        for ($i = 0; $i < count($parok); $i+=2) {
            $split = explode(" ", $parok[$i]);
            array_push($girlFirstnames, $split[1]);
        }

        $commaSeparated = implode(", ", $girlFirstnames);
        print_r($commaSeparated);
        echo "\n";

        break;
    case "utolso":
        break;
    case "letszam":
        break;
    default:
        echo "Ismeretlen paraméter!\n";
        exit(3);
}
