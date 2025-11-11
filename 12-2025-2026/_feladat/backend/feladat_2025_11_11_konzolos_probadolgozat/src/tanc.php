<?php

require "adatok.php";

if ($argc > 2) {
    echo "Túl sok paraméter!\n";
    exit(4);
}

$arrCount = count($parok);

if ($argc == 1) {
    for ($i = 0; $i < $arrCount; $i+=2) {
        echo $parok[$i] . " - " . $parok[$i + 1] . "\n";
    }
}

switch ($argv[1]) {
    case "fiuk":
        for ($i = 1; $i < $arrCount; $i+=2) {
            $split = explode(" ", $parok[$i]);
            echo "- " . $split[0] . "\n"; //vezetéknevek
        }

        break;
    case "lanyok":
        $girlFirstnames = [];
        for ($i = 0; $i < $arrCount; $i+=2) {
            $split = explode(" ", $parok[$i]);
            array_push($girlFirstnames, $split[1]);
        }

        $commaSeparated = implode(", ", $girlFirstnames);
        print_r($commaSeparated);
        echo "\n";

        break;
    case "utolso":
        $lastGirl = $parok[$arrCount - 2];
        $lastBoy = $parok[$arrCount - 1];
        echo $lastGirl . " - " . $lastBoy . "\n";

        break;
    case "letszam":
        echo $arrCount / 2 . "\n";

        break;
    default:
        echo "Ismeretlen paraméter!\n";
        exit(3);
}
