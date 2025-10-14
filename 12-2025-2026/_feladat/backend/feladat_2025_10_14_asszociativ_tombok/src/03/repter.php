<?php

require "jaratok.php";

if ($argc > 2) {
    echo "Túl sok paraméter!";
    exit(4);
}

if ($argc == 1) {
    foreach ($jaratok as $jaratszam => $adat) {
        echo "{$jaratszam}\t{$adat['honnan']}-{$adat['hova']}\t{$adat['indul']}-{$adat['erkezik']}\n";
    }
}

if ($argc == 2) {
    $talalat = false;
    foreach ($jaratok as $jaratszam => $adat) {
        if ($jaratszam == $argv[1]) {
            $talalat = true;
            echo "{$jaratszam} {$adat['indul']}-{$adat['erkezik']} ({$adat['legitarsasag']})";
        }
    }
    if (!$talalat) {
        echo "A keresett járat ({$argv[1]}) nem található!";
    }
}
