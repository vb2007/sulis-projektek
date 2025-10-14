<?php

require "jaratok.php";

if ($argc > 3) {
    echo "Túl sok paraméter!\n";
    exit(4);
}

if ($argc == 1) {
    foreach ($jaratok as $jaratszam => $adat) {
        echo "{$jaratszam}\t{$adat['honnan']}-{$adat['hova']}\t{$adat['indul']}-{$adat['erkezik']}\t{$adat['legitarsasag']}\n";
    }
}

if ($argc == 2) {
    $talalat = false;
    foreach ($jaratok as $jaratszam => $adat) {
        if ($jaratszam == $argv[1]) {
            $talalat = true;
            echo "{$adat['honnan']}-{$adat['hova']} {$adat['indul']}-{$adat['erkezik']} ({$adat['legitarsasag']})\n";
        }
    }

    if (!$talalat) {
        echo "A keresett járat ({$argv[1]}) nem található!\n";
        exit(7);
    }
}

if ($argc == 3) {
    switch ($argv[1]){
        case "legitarsasag":
            $jaratszam = 0;
            foreach ($jaratok as $adat) {
                if ($adat['legitarsasag'] == $argv[2]) {
                    $jaratszam++;
                }
            }

            echo "A(z) {$argv[2]} légitársaságnak {$jaratszam} járata van az adatok között.\n";
            break;
        case "repter":
            $repterszam = 0;
            foreach ($jaratok as $adat) {
                if ($adat['honnan'] == $argv[2] || $adat['hova'] == $argv[2]) {
                    $repterszam++;
                }
            }

            echo "A(z) {$argv[2]} azonosítójú reptér {$repterszam}x szerepel az adatok között.\n";
            break;
        default:
            echo "Ismeretlen paraméter '$argv[2]'\n";
            exit(9);
    }
}
