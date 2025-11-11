<?php

require "adatok.php";

function vb() {
    global $versenyzok;

    $vbCount = 0;
    foreach ($versenyzok as $csapat => $resztvevok) {
        foreach ($resztvevok as $resztvevo) {
            $vbCount += $resztvevo["vb"];
        }
    }

    return $vbCount;
}

function dobogo($rajtszam) {
    global $versenyzok;

    foreach ($versenyzok as $csapat => $resztvevok) {
        foreach ($resztvevok as $resztvevo) {
            if ($resztvevo["rajtszam"] == $rajtszam) {
                return $resztvevo["dobogo"];
            }
        }
    }
}

if ($argc < 2) {
    foreach ($versenyzok as $csapat => $resztvevok) {
        foreach ($resztvevok as $resztvevo) {
            echo mb_strtoupper($resztvevo["nev"]) . " (" . $resztvevo["rajtszam"] . ") [" . $csapat . "]\n";
        }
    }

    exit();
}

if ($argv[1] == "vb") {
    echo vb() . "\n";
    exit();
}

if (is_int($argv[1]) || $argv[1] >= 1 || $argv[1] <= 100) {
    echo dobogo($argv[1]) . "\n";
    exit();
}
