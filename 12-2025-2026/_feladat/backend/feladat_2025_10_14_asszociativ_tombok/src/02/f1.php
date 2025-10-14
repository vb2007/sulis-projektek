<?php

require "versenyzok.php";

if ($argc > 2) {
    echo "Túl sok paraméter!";
    exit(8);
}

if ($argc == 1) {
    echo "rajtsz.\tNév\tOrszág\tSzületési dátum\n";
    foreach ($versenyzok as $rajtszam => $adat) {
        echo "{$rajtszam}\t{$adat['nev']}\t{$adat['orszag']}\t{$adat['szulido']}\n";
    }
}

if ($argc == 2) {
    foreach ($versenyzok as $rajtszam => $adat) {
        if ($adat['orszag'] === $argv[1]) {
            echo "- $rajtszam : $adat[nev]\n";
        }
    }
}
